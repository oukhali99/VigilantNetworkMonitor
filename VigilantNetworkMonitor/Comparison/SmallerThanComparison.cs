using VigilantNetworkMonitor.Comparison.Base;

namespace VigilantNetworkMonitor.Comparison {
    internal class SmallerThanComparison<E> : BaseComparison<E> where E : IComparable {
        public SmallerThanComparison(E innerValue) : base(innerValue) {
        }

        public override bool GetResult(E value) {
            return value.CompareTo(_innerValue) < 0;
        }
    }
}
