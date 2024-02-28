using System.Collections.Specialized;

namespace VigilantNetworkMonitor.Service {
    public interface IColumnOptions {
        bool IsColumnEnabled(string columnName);
        void EnableColumn(string columnName);
        void DisableColumn(string columnName);
        ICollection<DataGridViewColumn> GetColumns();
        void AddColumn(DataGridViewColumn column);
        void AddChangedEnabledColumnsEventHandler(EventHandler handler);
    }

    internal class ColumnOptions : IColumnOptions {
        private ICollection<DataGridViewColumn> _columns;
        private event EventHandler? _changedEnabledColumnsEvent;

        public ColumnOptions() {
            _columns = new LinkedList<DataGridViewColumn>();
            if (Properties.Settings.Default.EnabledColumnNames == null) {
                Properties.Settings.Default.EnabledColumnNames = new StringCollection();
            }
        }

        public void EnableColumn(string columnName) {
            if (Properties.Settings.Default.EnabledColumnNames.Contains(columnName)) {
                return;
            }
            Properties.Settings.Default.EnabledColumnNames.Add(columnName);
            Properties.Settings.Default.Save();
            _changedEnabledColumnsEvent?.Invoke(this, EventArgs.Empty);
        }

        public void DisableColumn(string columnName) {
            if (!Properties.Settings.Default.EnabledColumnNames.Contains(columnName)) {
                return;
            }
            Properties.Settings.Default.EnabledColumnNames.Remove(columnName);
            Properties.Settings.Default.Save();
            _changedEnabledColumnsEvent?.Invoke(this, EventArgs.Empty);
        }

        public bool IsColumnEnabled(string columnName) {
            return Properties.Settings.Default.EnabledColumnNames.Contains(columnName);
        }

        public ICollection<DataGridViewColumn> GetColumns() {
            return _columns;
        }

        public void AddColumn(DataGridViewColumn column) {
            _columns.Add(column);
        }

        public void AddChangedEnabledColumnsEventHandler(EventHandler handler) {
            _changedEnabledColumnsEvent += handler;
        }

    }
}
