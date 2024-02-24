﻿
using PacketDotNet;
using VigilantNetworkMonitor.PacketFilter;

namespace VigilantNetworkMonitor {
    public interface IPacketFilterService {
        bool Filter(MyPacketWrapper myPacketWrapper);
        void SetFilterString(string filterString);
        void AddChangedFilterStringEventHandler(EventHandler handler);
    }

    public class PacketFilterService : IPacketFilterService {
        private event EventHandler? _changedFilterString;
        private IPacketFilter? _filter;
        private readonly IPacketFilterFactory _packetFilterFactory;

        public PacketFilterService(IPacketFilterFactory packetFilterFactory) {
            _packetFilterFactory = packetFilterFactory;
        }

        public bool Filter(MyPacketWrapper myPacketWrapper) {
            if (_filter == null) {
                return true;
            }
            return _filter.Filter(myPacketWrapper);
        }

        public void SetFilterString(string filterString) {
            _filter = _packetFilterFactory.ParseString(filterString);
            _changedFilterString?.Invoke(this, EventArgs.Empty);
        }

        public void AddChangedFilterStringEventHandler(EventHandler handler) {
            _changedFilterString += handler;
        }

    }
}
