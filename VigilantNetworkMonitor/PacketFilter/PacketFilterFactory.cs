
namespace VigilantNetworkMonitor.PacketFilter {
    public interface IPacketFilterFactory {
        public IPacketFilter? ParseString(string filterString);
    }

    public class PacketFilterFactory : IPacketFilterFactory {
        public IPacketFilter? ParseString(string filterString) {
            // Base checking
            if (filterString.Equals("udp")) {
                return new UdpPacketFilter();
            }
            if (filterString.Equals("tcp")) {
                return new TcpPacketFilter();
            }

            string[] split = filterString.Split(" ", StringSplitOptions.None);
            ICollection<string> blocks = new LinkedList<string>();

            // Split into blocks, respecting parenthesis
            int parenthesisBalance = 0;
            string block = "";
            for (int i = 0; i < split.Length; i++) {
                string s = split[i];

                if (block.Length > 0) {
                    block += " ";
                }
                block += s;

                parenthesisBalance += s.Count(c => c == '(');
                parenthesisBalance -= s.Count(c => c == ')');

                if (parenthesisBalance == 0 && blocks.Count < 2) {
                    blocks.Add(block);
                    block = "";
                }
            }
            if (block.Length > 0) {
                blocks.Add(block);
            }

            if (blocks.Count == 1) {
                string trimmedBlock = blocks.ElementAt(0);

                if (trimmedBlock.Length < 2) {
                    return null;
                }
                if (trimmedBlock[0] != '(') {
                    return null;
                }
                if (trimmedBlock[trimmedBlock.Length - 1] != ')') {
                    return null;
                }
                
                trimmedBlock = trimmedBlock.Substring(1, trimmedBlock.Length - 2);
                return ParseString(trimmedBlock);
            }
            if (blocks.Count == 2) {
                return null;
            }

            string firstBlock = blocks.ElementAt(0);
            string firstOperator = blocks.ElementAt(1);
            string restFilter = blocks.ElementAt(2);

            IPacketFilter? filter1 = ParseString(firstBlock);
            IPacketFilter? filter2 = ParseString(restFilter);
            if (filter1 == null || filter2 == null) {
                return null;
            }

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
    }
}
