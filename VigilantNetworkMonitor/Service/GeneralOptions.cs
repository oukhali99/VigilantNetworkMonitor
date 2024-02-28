namespace VigilantNetworkMonitor.Service {
    public interface IGeneralOptions {
        bool IsAutoScrollEnabled();
        void SetAutoScrollEnabled(bool value);
    }

    public class GeneralOptions : IGeneralOptions {
        private bool _autoScrollEnabled;

        public GeneralOptions() {
            _autoScrollEnabled = Properties.Settings.Default.AutoScrollEnabled;
        }

        public bool IsAutoScrollEnabled() {
            return _autoScrollEnabled;
        }

        public void SetAutoScrollEnabled(bool value) {
            _autoScrollEnabled = value;
            Properties.Settings.Default.AutoScrollEnabled = _autoScrollEnabled;
            Properties.Settings.Default.Save();
        }
    }
}
