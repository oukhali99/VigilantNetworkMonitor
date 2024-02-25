using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor.Comparison.Base
{
    public interface IComparison<E> where E : IComparable {
        bool GetResult(E value);
        string GetComparisonString();
    }
}
