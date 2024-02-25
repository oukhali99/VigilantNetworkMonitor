
namespace VigilantNetworkMonitor.Comparison.Base {
    public interface IComparison<E> where E : IComparable {
        bool GetResult(E value);
        string GetComparisonString();
    }
}
