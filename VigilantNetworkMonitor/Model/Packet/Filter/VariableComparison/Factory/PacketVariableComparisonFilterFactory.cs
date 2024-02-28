using VigilantNetworkMonitor.Model.Comparison.Base;
using VigilantNetworkMonitor.Model.Comparison.Factory;
using VigilantNetworkMonitor.Packet.Filter.VariableComparison.Base;
using VigilantNetworkMonitor.Packet.Variable.Base;
using VigilantNetworkMonitor.Packet.Variable.Factory;

namespace VigilantNetworkMonitor.Packet.Filter.VariableComparison.Factory {
    public interface IPacketVariableComparisonFilterFactory {
        IPacketVariableComparisonFilter? parseComparison(string comparisonString);
    }

    public class PacketVariableComparisonFilterFactory : IPacketVariableComparisonFilterFactory {
        private readonly IComparisonFactory _comparisonFactory;
        private readonly IPacketVariableFactory _packetVariableFactory;

        public PacketVariableComparisonFilterFactory(IComparisonFactory comparisonFactory, IPacketVariableFactory packetVariableFactory) {
            _comparisonFactory = comparisonFactory;
            _packetVariableFactory = packetVariableFactory;
        }

        public IPacketVariableComparisonFilter? parseComparison(string comparisonString) {
            IComparison? comparisonOperator = _comparisonFactory.Parse(comparisonString);
            if (comparisonOperator == null) {
                return null;
            }

            string[] stringVariables = comparisonString.Split(comparisonOperator.GetComparisonString());
            if (stringVariables.Length != 2) {
                return null;
            }

            IPacketVariable? var1 = _packetVariableFactory.Parse(stringVariables[0]);
            IPacketVariable? var2 = _packetVariableFactory.Parse(stringVariables[1]);
            if (var1 == null || var2 == null) {
                return null;
            }

            if (!var1.GetValueType().Equals(var2.GetValueType())) {
                return null;
            }

            return new PacketVariableComparisonFilter(var1, comparisonOperator, var2);
        }

    }
}
