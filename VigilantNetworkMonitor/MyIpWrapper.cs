using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor {
    public class MyIpWrapper : IComparable {
        private IPAddress _ipAddress;

        public MyIpWrapper(IPAddress ipAddress) {
            _ipAddress = ipAddress;
        }

        public int CompareTo(object? obj) {
            if (obj == null) {
                return 1;
            }
            if (obj is not MyIpWrapper) {
                throw new ArgumentException("Cannot compare with " + obj.GetType());
            }

            MyIpWrapper myIpWrapperObj = (MyIpWrapper)obj;
            byte[] thisBytes = _ipAddress.GetAddressBytes();
            byte[] objBytes = myIpWrapperObj._ipAddress.GetAddressBytes();

            return 0;
        }

        public static MyIpWrapper? Parse(string stringToParse) {
            try {
                return new MyIpWrapper(IPAddress.Parse(stringToParse));
            }
            catch (Exception) {
            }

            return null;
        }
    }
}
