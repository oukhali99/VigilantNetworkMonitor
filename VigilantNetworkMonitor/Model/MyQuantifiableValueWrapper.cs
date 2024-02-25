using System.Net;

namespace VigilantNetworkMonitor.Model {
    public class MyQuantifiableValueWrapper : IComparable {
        private double _value;

        public MyQuantifiableValueWrapper(double value) {
            _value = value;
        }

        public MyQuantifiableValueWrapper(float value) {
            _value = value;
        }

        public MyQuantifiableValueWrapper(int value) {
            _value = value;
        }

        public MyQuantifiableValueWrapper(ushort value) {
            _value = value;
        }

        public MyQuantifiableValueWrapper(IPAddress ipAddress) {
            _value = 0;
            byte[] bytes = ipAddress.GetAddressBytes();
            for (int i = 0; i < bytes.Length; i++) {
                _value += bytes[i] * Math.Pow(256, bytes.Length - 1 - i);
            }
        }

        public int CompareTo(object? obj) {
            if (obj != null) {
                if (obj is MyQuantifiableValueWrapper) {
                    MyQuantifiableValueWrapper myNumberWrapperObj = (MyQuantifiableValueWrapper)obj;
                    return _value.CompareTo(myNumberWrapperObj._value);
                }
            }

            return _value.CompareTo(obj);
        }

        public override string? ToString() {
            return _value.ToString();
        }

        public static MyQuantifiableValueWrapper? Parse(string stringToParse) {
            try {
                return new MyQuantifiableValueWrapper(int.Parse(stringToParse));
            }
            catch (Exception) {
            }
            try {
                return new MyQuantifiableValueWrapper(double.Parse(stringToParse));
            }
            catch (Exception) {
            }
            try {
                return new MyQuantifiableValueWrapper(IPAddress.Parse(stringToParse));
            }
            catch (Exception) {
            }

            return null;
        }
    }
}
