using VigilantNetworkMonitor.Packet.Filter.Base;
using VigilantNetworkMonitor.Packet.Filter.Factory;
using static VigilantNetworkMonitor.Packet.Filter.Service.IPacketFilterService;

namespace VigilantNetworkMonitor.Packet.Filter.Service {
    public interface IPacketFilterService {
        bool Filter(MyPacketWrapper myPacketWrapper);
        void SetActiveFilter(string filterString);
        public IPacketFilter? GetActiveFilter();
        public void SaveFilter(string filterName, string filterString);
        public Dictionary<string, string> GetSavedFilters();

        void AddChangedActiveFilterEventHandler(ChangedActiveFilterEventHandler handler);
        delegate void ChangedActiveFilterEventHandler(object sender, ChangedActiveFilterEventArgs e);
        class ChangedActiveFilterEventArgs : EventArgs {
            public string FilterString { get; }
            public ChangedActiveFilterEventArgs(string filterString) {
                FilterString = filterString;
            }
        }
    }

    public class PacketFilterService : IPacketFilterService {
        private event ChangedActiveFilterEventHandler? _changedFilterString;
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

        public void SetActiveFilter(string filterString) {
            _filter = _packetFilterFactory.ParseString(filterString);
            _changedFilterString?.Invoke(this, new ChangedActiveFilterEventArgs(filterString));
        }

        public void AddChangedActiveFilterEventHandler(ChangedActiveFilterEventHandler handler) {
            _changedFilterString += handler;
        }

        public IPacketFilter? GetActiveFilter() {
            return _filter;
        }

        public void SaveFilter(string filterName, string filterString) {
            string combined = filterName + ";" + filterString;
            Properties.Settings.Default.SavedFilters.Add(combined);
            Properties.Settings.Default.Save();
        }

        public Dictionary<string, string> GetSavedFilters() {
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
