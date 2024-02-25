using VigilantNetworkMonitor.Comparator.Base;

namespace VigilantNetworkMonitor.Condition.Service {
    public interface IConditionFactory {
        ICondition? Parse(string conditionString);
    }

    internal class ConditionFactory : IConditionFactory {
        public ICondition? Parse(string conditionString) {
            if (conditionString.Contains('<')) {
                return new SmallerThanCondition();
            }
            if (conditionString.Contains('>')) {
                return new BiggerThanCondition();
            }
            if (conditionString.Contains('=')) {
                return new EqualsCondition();
            }

            return null;
        }
    }
}
