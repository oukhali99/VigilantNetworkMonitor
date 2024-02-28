using VigilantNetworkMonitor.Model.Comparison.Base;

namespace VigilantNetworkMonitor.Model.Comparison {
    internal class BiggerThanComparison : BaseComparison {

        public override bool Evaluate(IComparable value1, IComparable value2) {
            return value1.CompareTo(value2) > 0;
        }

        public override string GetComparisonString() {
            return ">";
        }
    }
}
