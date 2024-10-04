using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothDbus.Bluetooth
{
    public class AdapterProperties
    {
        public string Address { get; set; } = default(string);
        public string AddressType { get; set; } = default(string);
        public string Name { get; set; } = default(string);
        public string Alias { get; set; } = default(string);
        public uint Class { get; set; } = default(uint);
        public bool Powered { get; set; } = default(bool);
        public bool Discoverable { get; set; } = default(bool);
        public uint DiscoverableTimeout { get; set; } = default(uint);
        public bool Discovering { get; set; } = default(bool);
        public bool Pairable { get; set; } = default(bool);
        public uint PairableTimeout { get; set; } = default(uint);
        public string[] UUIDs {  get; set; } = default(string[]);
        public string Modalias { get; set; } = default(string);
    }
}
