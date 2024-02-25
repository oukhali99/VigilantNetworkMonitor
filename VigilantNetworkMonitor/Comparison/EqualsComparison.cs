using VigilantNetworkMonitor.Comparison.Base;

namespace VigilantNetworkMonitor.Comparison {
    internal class EqualsComparison<E> : BaseComparison<E> where E : IComparable {
        public EqualsComparison(E innerValue) : base(innerValue) {
        }

        public override bool GetResult(E value) {
            return value.CompareTo(_innerValue) == 0;
        }
    }
}
