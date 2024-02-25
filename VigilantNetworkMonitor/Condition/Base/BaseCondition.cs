using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor.Comparator.Base {
    internal abstract class BaseCondition : ICondition {
        public abstract bool Evaluate(IComparable value1, IComparable value2);
        public abstract string GetConditionString();
    }
}
