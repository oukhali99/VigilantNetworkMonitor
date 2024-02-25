using VigilantNetworkMonitor.Comparison.Base;

namespace VigilantNetworkMonitor.Comparison {
    internal class BiggerThanComparison<E> : BaseComparison<E> where E : IComparable {
        public BiggerThanComparison(E innerValue) : base(innerValue) {
        }

        public override string GetComparisonString() {
            return ">" + _innerValue;
        }

        public override bool GetResult(E value) {
            return value.CompareTo(_innerValue) > 0;
        }
    }
}
