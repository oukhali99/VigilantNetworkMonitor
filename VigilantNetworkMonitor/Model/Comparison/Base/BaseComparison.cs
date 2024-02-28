namespace VigilantNetworkMonitor.Model.Comparison.Base {
    internal abstract class BaseComparison : IComparison {
        public abstract bool Evaluate(IComparable value1, IComparable value2);
        public abstract string GetComparisonString();
    }
}
