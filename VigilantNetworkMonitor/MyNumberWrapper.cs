using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable;

namespace VigilantNetworkMonitor {
    public class MyNumberWrapper : IComparable {
        private double _value;

        public MyNumberWrapper(double value) {
            _value = value;
        }

        public MyNumberWrapper(float value) {
            _value = value;
        }

        public MyNumberWrapper(int value) {
            _value = value;
        }

        public MyNumberWrapper(ushort value) {
            _value = value;
        }

        public MyNumberWrapper(IPAddress ipAddress) {
            _value = 0;
            byte[] bytes = ipAddress.GetAddressBytes();
            for (int i = 0; i < bytes.Length; i++) {
                _value += bytes[i] * Math.Pow(256, bytes.Length - 1 - i);
            }
        }

        public int CompareTo(object? obj) {
            if (obj != null) {
                if (obj is MyNumberWrapper) {
                    MyNumberWrapper myNumberWrapperObj = (MyNumberWrapper)obj;
                    return _value.CompareTo(myNumberWrapperObj._value);
                }
            }

            return _value.CompareTo(obj);
        }

        public override string? ToString() {
            return _value.ToString();
        }

        public static MyNumberWrapper? Parse(string stringToParse) {
            try {
                return new MyNumberWrapper(int.Parse(stringToParse));
            }
            catch (Exception) {
            }
            try {
                return new MyNumberWrapper(double.Parse(stringToParse));
            }
            catch (Exception) {
            }
            try {
                return new MyNumberWrapper(IPAddress.Parse(stringToParse));
            }
            catch (Exception) {
            }

            return null;
        }
    }
}
