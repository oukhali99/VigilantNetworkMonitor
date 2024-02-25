using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparator.Base;
using VigilantNetworkMonitor.Condition.Service;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.VariableComparison;
using VigilantNetworkMonitor.PacketFilter.VariableComparison.Base;
using VigilantNetworkMonitor.PacketVariable.Base;
using VigilantNetworkMonitor.PacketVariable.Factory;

namespace VigilantNetworkMonitor.PacketFilter.VariableCondition.Factory {
    public interface IPacketVariableConditionFilterFactory {
        IPacketVariableConditionFilter? parseComparison(string comparisonString);
    }

    public class PacketVariableConditionFilterFactory : IPacketVariableConditionFilterFactory {
        private readonly IConditionFactory _conditionFactory;
        private readonly IPacketVariableFactory _packetVariableFactory;

        public PacketVariableConditionFilterFactory(IConditionFactory conditionFactory, IPacketVariableFactory packetVariableFactory)
        {
            _conditionFactory = conditionFactory;
            _packetVariableFactory = packetVariableFactory;
        }

        public IPacketVariableConditionFilter? parseComparison(string comparisonString) {
            ICondition? conditionOperator = _conditionFactory.Parse(comparisonString);
            if (conditionOperator == null) {
                return null;
            }

            string[] stringVariables = comparisonString.Split(conditionOperator.GetConditionString());
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

            return new PacketVariableConditionFilter(var1, conditionOperator, var2);
        }

    }
}
