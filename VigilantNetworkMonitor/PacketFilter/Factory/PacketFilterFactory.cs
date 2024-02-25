using VigilantNetworkMonitor.Comparator.Base;
using VigilantNetworkMonitor.Comparison.Factory;
using VigilantNetworkMonitor.Condition.Service;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.VariableComparison;
using VigilantNetworkMonitor.PacketFilter.VariableComparison.Base;
using VigilantNetworkMonitor.PacketVariable.Base;
using VigilantNetworkMonitor.PacketVariable.Factory;

namespace VigilantNetworkMonitor.PacketFilter.Factory {
    public interface IPacketFilterFactory {
        public IPacketFilter? ParseString(string filterString);
    }

    public class PacketFilterFactory : IPacketFilterFactory {
        private readonly IConditionFactory _conditionFactory;
        private readonly IPacketVariableFactory _packetVariableFactory;

        public PacketFilterFactory(IConditionFactory conditionFactory, IPacketVariableFactory packetVariableFactory) {
            _conditionFactory = conditionFactory;
            _packetVariableFactory = packetVariableFactory;
        }

        private string formatString(string filterString) {
            filterString = filterString.Replace(" <", "<");
            filterString = filterString.Replace("< ", "<");
            filterString = filterString.Replace(" >", ">");
            filterString = filterString.Replace("> ", ">");
            filterString = filterString.Replace(" =", "=");
            filterString = filterString.Replace("= ", "=");
            return filterString;
        }

        public IPacketFilter? ParseString(string filterString) {
            filterString = formatString(filterString);

            string[] split = filterString.Split(" ", StringSplitOptions.None);

            // Only 1 split, this means there are no spaces
            if (split.Length == 1) {
                return ParseSpacelessString(split[0]);
            }

            ICollection<string> elements = new LinkedList<string>();

            /*
             * Get 3 elements into the list
             * The first element
             * The second element (operator)
             * The rest of the filter
             */
            int parenthesisBalance = 0;
            string currentElement = "";
            for (int i = 0; i < split.Length; i++) {
                string splitItem = split[i];

                if (currentElement.Length > 0) {
                    currentElement += " ";
                }
                currentElement += splitItem;

                parenthesisBalance += splitItem.Count(c => c == '(');
                parenthesisBalance -= splitItem.Count(c => c == ')');

                if (
                    // If we are in the middle of parenthesis, keep accumulating
                    parenthesisBalance == 0 &&
                    // If we already have the 2 first elements, keep accumulating
                    elements.Count < 2
                    ) {
                    elements.Add(currentElement);
                    currentElement = "";
                }
            }

            // Whatever is accumulated is the 3rd element, the rest of the filter
            if (currentElement.Length > 0) {
                elements.Add(currentElement);
            }

            // Only 1 element, this means it must be a parenthesis
            if (elements.Count == 1) {
                string trimmedBlock = elements.ElementAt(0);

                // Is there enough characters for 2 parenthesis?
                if (trimmedBlock.Length < 2) {
                    return null;
                }
                // Are there parenthesis?
                if (trimmedBlock[0] != '(') {
                    return null;
                }
                // Are there parenthesis?
                if (trimmedBlock[trimmedBlock.Length - 1] != ')') {
                    return null;
                }

                // Remove the parenthesis and parse
                trimmedBlock = trimmedBlock.Substring(1, trimmedBlock.Length - 2);
                return ParseString(trimmedBlock);
            }

            // Are there only 2 elements? Not valid
            if (elements.Count == 2) {
                return null;
            }

            // Get the 3 elements
            string firstBlock = elements.ElementAt(0);
            string firstOperator = elements.ElementAt(1);
            string restFilter = elements.ElementAt(2);

            IPacketFilter? filter1 = ParseString(firstBlock);
            IPacketFilter? filter2 = ParseString(restFilter);
            if (filter1 == null || filter2 == null) {
                return null;
            }

            /*
             * Parse or first. Since and should get evaluated first
             * It makes sense when you think about it
             * The filter resolves the inner filters first
             */
            if (firstOperator.Equals("or")) {
                return new PacketFilterOrConcatenator(
                    filter1,
                    filter2
                );
            }
            if (firstOperator.Equals("and")) {
                return new PacketFilterAndConcatenator(
                    filter1,
                    filter2
                );
            }

            return null;
        }

        private IPacketFilter? ParseSpacelessString(string spaceLessString) {
            if (spaceLessString.Equals("udp")) {
                return new UdpPacketFilter();
            }
            if (spaceLessString.Equals("tcp")) {
                return new TcpPacketFilter();
            }

            IPacketFilter? comparisonFilter = parseComparison(spaceLessString);
            if (comparisonFilter != null) {
                return comparisonFilter;
            }

            return null;
        }

        private IPacketFilter? parseComparison(string comparisonString) {
            ICondition? conditionOperator = _conditionFactory.Parse(comparisonString);
            if (conditionOperator == null) {
                return null;
            }

            string[] stringVariables = comparisonString.Split(conditionOperator.GetConditionString());
            if (stringVariables.Length != 2) {
                return null;
            }

            IPacketVariable? var1 = _packetVariableFactory.Parse(stringVariables[0]);
            IPacketVariable? var2 =  _packetVariableFactory.Parse(stringVariables[1]);
            if (var1 == null || var2 == null) {
                return null;
            }

            return new PacketVariableComparisonFilter(var1, conditionOperator, var2);
        }
    }
}
