namespace VigilantNetworkMonitor.Comparator.Base {
    public interface IComparison {
        bool Evaluate(IComparable value1, IComparable value2);
        string GetComparisonString();
    }
}
