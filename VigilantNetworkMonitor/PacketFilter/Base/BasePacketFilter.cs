﻿namespace VigilantNetworkMonitor.PacketFilter.Base {
    internal abstract class BasePacketFilter : IPacketFilter {
        public abstract bool Filter(MyPacketWrapper packet);
        public abstract string GetFilterString();
    }
}
