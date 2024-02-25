
using PacketDotNet;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Factory;

namespace VigilantNetworkMonitor.PacketFilter.Service
{
    public interface IPacketFilterService
    {
        bool Filter(MyPacketWrapper myPacketWrapper);
        void SetFilterString(string filterString);
        void AddChangedFilterStringEventHandler(EventHandler handler);
        public IPacketFilter? GetFilter();
    }

    public class PacketFilterService : IPacketFilterService
    {
        private event EventHandler? _changedFilterString;
        private IPacketFilter? _filter;
        private readonly IPacketFilterFactory _packetFilterFactory;

        public PacketFilterService(IPacketFilterFactory packetFilterFactory)
        {
            _packetFilterFactory = packetFilterFactory;
        }

        public bool Filter(MyPacketWrapper myPacketWrapper)
        {
            if (_filter == null)
            {
                return true;
            }
            return _filter.Filter(myPacketWrapper);
        }

        public void SetFilterString(string filterString)
        {

            filterString = filterString.Replace(" <", "<");
            filterString = filterString.Replace("< ", "<");
            filterString = filterString.Replace(" >", ">");
            filterString = filterString.Replace("> ", ">");
            filterString = filterString.Replace(" =", "=");
            filterString = filterString.Replace("= ", "=");

            _filter = _packetFilterFactory.ParseString(filterString);
            _changedFilterString?.Invoke(this, EventArgs.Empty);
        }

        public void AddChangedFilterStringEventHandler(EventHandler handler)
        {
            _changedFilterString += handler;
        }

        public IPacketFilter? GetFilter()
        {
            return _filter;
        }

    }
}
