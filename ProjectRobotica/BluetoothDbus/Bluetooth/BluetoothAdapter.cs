//using Linux.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BluetoothDbus.Bluetooth
{
    public delegate Task DeviceChangeEventHandlerAsync(BluetoothAdapter sender, DeviceFoundEventArgs eventArgs);

    public delegate Task AdapterEventHandlerAsync(BluetoothAdapter sender, BlueZEventArgs eventArgs);
    public class BluetoothAdapter : IAdapter1, IDisposable
    {
        private IAdapter1 _proxy;
        private IDisposable _interfacesWatcher;
        private IDisposable _propertyWatcher;
        private DeviceChangeEventHandlerAsync _deviceFound;
        private AdapterEventHandlerAsync _poweredOn;
        private IObjectManager _objectManager;

        ~BluetoothAdapter() { Dispose(); }

        public void Dispose()
        {
            _interfacesWatcher?.Dispose();
            _interfacesWatcher = null;

            GC.SuppressFinalize(this);
        }
        internal static async Task<BluetoothAdapter> CreateAsync(IAdapter1 proxy)
        {
            BluetoothAdapter bluetoothAdapter = new BluetoothAdapter
            {
                _proxy = proxy,
            };

            bluetoothAdapter._objectManager = Connection.System.CreateProxy<IObjectManager>(BluezConstants.DbusService, "/");
            bluetoothAdapter._interfacesWatcher = await bluetoothAdapter._objectManager.WatchInterfacesAddedAsync(bluetoothAdapter.OnDeviceAddedAsync());
            bluetoothAdapter._propertyWatcher = await proxy.WatchPropertiesAsync(bluetoothAdapter.OnPropertyChanges);

            return bluetoothAdapter;
        }

        public Task<Adapter1Properties> GetAllAsync()
        {
            return _proxy.GetAllAsync();
        }

        public async Task<AdapterProperties> GetPropertiesAsync()
        {
            var properties = await _proxy.GetAllAsync();
            return new AdapterProperties
            {
                Address = properties.Address,
                AddressType = properties.AddressType, //"public" or "random"
                Name = properties.Name,
                Alias = properties.Alias,
                Class = properties.Class,
                Powered = properties.Powered, //"on" "off" "off-enabling" "on-disabling" "off-blocked"
                Discoverable = properties.Discoverable,
                DiscoverableTimeout = properties.DiscoverableTimeout,
                Discovering = properties.Discovering,
                Pairable = properties.Pairable,
                PairableTimeout = properties.PairableTimeout,
                UUIDs = properties.UUIDs,
                Modalias = properties.Modalias
            };
        }
        public Task StartDiscoveryAsync()
        {
            return _proxy.StartDiscoveryAsync();
        }
        public Task SetDiscoveryFilterAsync(IDictionary<string, object> Properties)
        {
            return _proxy.SetDiscoveryFilterAsync(Properties);
        }
        public Task StopDiscoveryAsync()
        {
            return _proxy.StopDiscoveryAsync();
        }
        public Task RemoveDeviceAsync(ObjectPath Device)
        {
            return _proxy.RemoveDeviceAsync(Device);
        }
        public Task<string[]> GetDiscoveryFiltersAsync()
        {
            return _proxy.GetDiscoveryFiltersAsync();
        }
        public Task<T> GetAsync<T>(string prop)
        {
            return _proxy.GetAsync<T>(prop);
        }

        public Task SetAsync(string prop, object val)
        {
            return _proxy.SetAsync(prop, val);
        }
        public Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler)
        {
            return _proxy.WatchPropertiesAsync(handler);
        }

        public event DeviceChangeEventHandlerAsync DeviceFound
        {
            add
            {
                _deviceFound += value;
                ExistingDeviceEventChangeAsync();
            }
            remove
            {
                _deviceFound -= value;
            }
        }

        public event AdapterEventHandlerAsync PoweredOn
        {
            add
            {
                _poweredOn += value;
                FireEventIfPropertyAlreadyTrueAsync(_poweredOn, "Powered");
            }
            remove
            {
                _poweredOn -= value;
            }
        }

        public event AdapterEventHandlerAsync PoweredOff;
        public ObjectPath ObjectPath => _proxy.ObjectPath;

        public async void ExistingDeviceEventChangeAsync()
        {
            var devices = await this.GetDevicesAsync();
            foreach (var device in devices)
            {
                _deviceFound?.Invoke(this, new DeviceFoundEventArgs(device, isStateChange: false));
            }
        }
        public async void FireEventIfPropertyAlreadyTrueAsync(AdapterEventHandlerAsync handler, string prop)
        {
            try
            {
                var value = await _proxy.GetAsync<bool>(prop);
                if (value)
                {
                    // TODO: Suppress duplicate event from OnPropertyChanges.
                    handler?.Invoke(this, new BlueZEventArgs(isStateChange: false));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if '{prop}' is already true: {ex}");
            }
        }
        public void OnPropertyChanges(PropertyChanges propertyChanges)
        {
            foreach (var pair in propertyChanges.Changed)
            {
                switch (pair.Key)
                {
                    case "Powered":
                        if (true.Equals(pair.Value))
                        {
                            _poweredOn?.Invoke(this, new BlueZEventArgs());
                        }
                        else
                        {
                            PoweredOff?.Invoke(this, new BlueZEventArgs());
                        }
                        break;
                }
            }
        }
        public static async Task<IReadOnlyList<Device>> GetDevicesAsync(this IAdapter1 adapter)
        {
            var devices = await BlueZManager.GetProxiesAsync<IDevice1>(BluezConstants.DeviceInterface, adapter);

            return await Task.WhenAll(devices.Select(Device.CreateAsync));
        }
        public static async Task<Device> GetDeviceAsync(this IAdapter1 adapter, string deviceAddress)
        {
            var devices = await BlueZManager.GetProxiesAsync<IDevice1>(BluezConstants.DeviceInterface, adapter);

            var matches = new List<IDevice1>();
            foreach (var device in devices)
            {
                if (String.Equals(await device.GetAddressAsync(), deviceAddress, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(device);
                }
            }

            // BlueZ can get in a weird state, probably due to random public BLE addresses.
            if (matches.Count > 1)
            {
                throw new Exception($"{matches.Count} devices found with the address {deviceAddress}!");
            }

            var dev = matches.FirstOrDefault();
            if (dev != null)
            {
                return await Device.CreateAsync(dev);
            }

            return null;
        }
        public static Task<IDisposable> WatchDevicesAddedAsync(this IAdapter1 adapter, Action<Device> handler)
        {
            async void OnDeviceAdded((ObjectPath objectPath, IDictionary<string, IDictionary<string, object>> interfaces) args)
            {
                if (BlueZManager.IsMatch(BluezConstants.DeviceInterface, args.objectPath, args.interfaces, adapter))
                {
                    var device = Connection.System.CreateProxy<IDevice1>(BluezConstants.DbusService, args.objectPath);

                    var dev = await Device.CreateAsync(device);
                    handler(dev);
                }
            }

            var objectManager = Connection.System.CreateProxy<IObjectManager>(BluezConstants.DbusService, "/");
            return objectManager.WatchInterfacesAddedAsync(OnDeviceAdded);
        }
    }
}
