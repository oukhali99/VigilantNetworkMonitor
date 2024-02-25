namespace VigilantNetworkMonitor.Comparator.Base {
    public interface ICondition {
        bool Evaluate(IComparable value1, IComparable value2);
        string GetConditionString();
    }
}
