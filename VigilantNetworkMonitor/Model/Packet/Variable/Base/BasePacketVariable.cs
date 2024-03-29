﻿namespace VigilantNetworkMonitor.Packet.Variable.Base {
    internal abstract class BasePacketVariable : IPacketVariable {
        public abstract IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        public abstract Type GetValueType();
        public abstract string GetVariableName();
    }
}
