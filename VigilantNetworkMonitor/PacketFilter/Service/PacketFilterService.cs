using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Factory;
using static VigilantNetworkMonitor.PacketFilter.Service.IPacketFilterService;

namespace VigilantNetworkMonitor.PacketFilter.Service {
    public interface IPacketFilterService {
        bool Filter(MyPacketWrapper myPacketWrapper);
        void SetFilterString(string filterString);
        public IPacketFilter? GetFilter();
        public void SaveFilter(string filterName, string filterString);
        public Dictionary<string, string> GetFiltersByName();

        void AddChangedFilterStringEventHandler(FilterStringEventHandler handler);
        delegate void FilterStringEventHandler(object sender, FilterStringEventArgs e);
        class FilterStringEventArgs : EventArgs {
            public string FilterString { get; }
            public FilterStringEventArgs(string filterString) {
                FilterString = filterString;
            }
        }
    }

    public class PacketFilterService : IPacketFilterService {
        private event FilterStringEventHandler? _changedFilterString;
        private IPacketFilter? _filter;
        private readonly IPacketFilterFactory _packetFilterFactory;

        public PacketFilterService(IPacketFilterFactory packetFilterFactory) {
            if (Properties.Settings.Default.SavedFilters == null) {
                Properties.Settings.Default.SavedFilters = new System.Collections.Specialized.StringCollection();
            }

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
            _changedFilterString?.Invoke(this, new FilterStringEventArgs(filterString));
        }

        public void AddChangedFilterStringEventHandler(FilterStringEventHandler handler) {
            _changedFilterString += handler;
        }

        public IPacketFilter? GetFilter() {
            return _filter;
        }

        public void SaveFilter(string filterName, string filterString) {
            string combined = filterName + ";" + filterString;
            Properties.Settings.Default.SavedFilters.Add(combined);
            Properties.Settings.Default.Save();
        }

        public Dictionary<string, string> GetFiltersByName() {
            Dictionary<string, string> filtersByName = new Dictionary<string, string>();

            foreach (string? combined in Properties.Settings.Default.SavedFilters) {
                if (combined == null) {
                    continue;
                }

                try {
                    string[] split = combined.Split(";");
                    string name = split[0];
                    string filterString = split[1];
                    filtersByName.Add(name, filterString);
                }
                catch (Exception) {
                }
            }

            return filtersByName;
        }
    }
}
