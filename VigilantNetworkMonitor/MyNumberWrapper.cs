using System;
using System.Collections.Generic;
using System.Linq;
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

            return null;
        }
    }
}
