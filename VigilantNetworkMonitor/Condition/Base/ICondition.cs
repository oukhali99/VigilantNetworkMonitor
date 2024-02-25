using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor.Comparator.Base {
    public interface ICondition {
        bool Evaluate(IComparable value1, IComparable value2);
        string GetConditionString();
    }
}
