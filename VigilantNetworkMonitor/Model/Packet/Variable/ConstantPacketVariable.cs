using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Variable.Base;

namespace VigilantNetworkMonitor.Packet.Variable
{
    internal class ConstantPacketVariable : BasePacketVariable
    {
        private readonly MyQuantifiableValueWrapper _value;

        public ConstantPacketVariable(MyQuantifiableValueWrapper value)
        {
            _value = value;
        }

        public override MyQuantifiableValueWrapper? GetValue(MyPacketWrapper myPacketWrapper)
        {
            return _value;
        }

        public override Type GetValueType()
        {
            return typeof(MyQuantifiableValueWrapper);
        }

        public override string GetVariableName()
        {
            return _value.ToString();
        }
    }
}
