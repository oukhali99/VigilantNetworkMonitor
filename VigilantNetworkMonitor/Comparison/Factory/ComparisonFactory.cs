using System.Globalization;
using VigilantNetworkMonitor.Comparison.Base;

namespace VigilantNetworkMonitor.Comparison.Factory {
    public interface IComparisonFactory {
        IComparison<E>? Parse<E>(string comparisonString) where E : IComparable, IParsable<E>;
    }

    public class ComparisonFactory : IComparisonFactory {
        public IComparison<E>? Parse<E>(string comparisonString) where E : IComparable, IParsable<E> {
            try {
                if (comparisonString.Contains('<')) {
                    string valueString = comparisonString.Replace("<", "");
                    E value = E.Parse(valueString, CultureInfo.InvariantCulture);
                    return new SmallerThanComparison<E>(value);
                }
                if (comparisonString.Contains('>')) {
                    string valueString = comparisonString.Replace(">", "");
                    E value = E.Parse(valueString, CultureInfo.InvariantCulture);
                    return new BiggerThanComparison<E>(value);
                }
                if (comparisonString.Contains('=')) {
                    string valueString = comparisonString.Replace("=", "");
                    E value = E.Parse(valueString, CultureInfo.InvariantCulture);
                    return new EqualsComparison<E>(value);
                }
            }
            catch (Exception) {
            }


            return null;
        }
    }
}
