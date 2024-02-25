namespace VigilantNetworkMonitor.Comparison.Base {
    internal abstract class BaseComparison<E> : IComparison<E> where E : IComparable {
        protected E _innerValue { get; }

        protected BaseComparison(E innerValue) {
            _innerValue = innerValue;
        }

        public abstract bool GetResult(E value);
        public abstract string GetComparisonString();
    }
}
