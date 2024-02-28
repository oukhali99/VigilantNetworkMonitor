using VigilantNetworkMonitor.Comparator.Base;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.VariableComparison.Base;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableComparison {
    internal class PacketVariableComparisonFilter : IPacketVariableComparisonFilter {
        private readonly IPacketVariable _variable1;
        private readonly IComparison _comparison;
        private readonly IPacketVariable _variable2;

        internal PacketVariableComparisonFilter(
            IPacketVariable variable1,
            IComparison comparison,
            IPacketVariable variable2
        ) {
            _variable1 = variable1;
            _comparison = comparison;
            _variable2 = variable2;
        }

        public bool Filter(MyPacketWrapper packet) {
            IComparable? val1 = _variable1.GetValue(packet);
            IComparable? val2 = _variable2.GetValue(packet);

            if (val1 == null || val2 == null) {
                return false;
            }

            return _comparison.Evaluate(val1, val2);
        }

        public string GetFilterString() {
            return _variable1.GetVariableName() + _comparison.GetComparisonString() + _variable2.GetVariableName();
        }
    }
}
