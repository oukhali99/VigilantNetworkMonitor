using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparator.Base;

namespace VigilantNetworkMonitor.Condition {
    internal class EqualsCondition : BaseCondition {

        public override bool Evaluate(IComparable value1, IComparable value2) {
            return value1.CompareTo(value2) == 0;
        }

        public override string GetConditionString() {
            return "=";
        }
    }
}
