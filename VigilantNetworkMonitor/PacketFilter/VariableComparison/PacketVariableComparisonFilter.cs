using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparator.Base;
using VigilantNetworkMonitor.PacketFilter.VariableComparison.Base;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableComparison
{
    internal class PacketVariableComparisonFilter : IPacketVariableComparisonFilter
    {
        private readonly IPacketVariable _variable1;
        private readonly ICondition _condition;
        private readonly IPacketVariable _variable2;

        internal PacketVariableComparisonFilter(
            IPacketVariable variable1,
            ICondition condition,
            IPacketVariable variable2
        )
        {
            _variable1 = variable1;
            _condition = condition;
            _variable2 = variable2;
        }

        public bool Filter(MyPacketWrapper packet)
        {
            IComparable? val1 = _variable1.GetValue(packet);
            IComparable? val2 = _variable2.GetValue(packet);

            if (val1 == null || val2 == null) {
                return false;
            }

            return _condition.Evaluate(val1, val2);
        }

        public string GetFilterString()
        {
            return _variable1.GetVariableName() + _condition.GetConditionString() + _variable2.GetVariableName();
        }
    }
}
