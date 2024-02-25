using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparison.Base;
using VigilantNetworkMonitor.PacketFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter.Base {
    internal abstract class BasePacketVariableFilter<E> : IPacketVariableFilter<E> where E : IComparable {
        protected IComparison<E> _comparison { get; }

        protected BasePacketVariableFilter(IComparison<E> comparison) {
            _comparison = comparison;
        }

        public abstract string GetFilterString();
        public abstract bool Filter(MyPacketWrapper packet);
    }
}
