using VigilantNetworkMonitor.Comparison.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter.Base {
    internal abstract class BasePacketVariableFilter<E> : IPacketVariableFilter<E> where E : IComparable {
        protected IComparison<E> _comparison { get; }

        public const string VARIABLE_NAME = "N/A";

        protected BasePacketVariableFilter(IComparison<E> comparison) {
            _comparison = comparison;
        }

        public string GetFilterString() {
            return GetVariableName() + _comparison.GetComparisonString();
        }

        public abstract bool Filter(MyPacketWrapper packet);
        public abstract string GetVariableName();
    }
}
