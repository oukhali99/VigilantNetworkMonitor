using VigilantNetworkMonitor.Comparator.Base;

namespace VigilantNetworkMonitor.Comparison.Service {
    public interface IComparisonFactory {
        IComparison? Parse(string comparisonString);
    }

    internal class ComparisonFactory : IComparisonFactory {
        public IComparison? Parse(string comparisonString) {
            if (comparisonString.Contains('<')) {
                return new SmallerThanComparison();
            }
            if (comparisonString.Contains('>')) {
                return new BiggerThanComparison();
            }
            if (comparisonString.Contains('=')) {
                return new EqualsComparison();
            }

            return null;
        }
    }
}
