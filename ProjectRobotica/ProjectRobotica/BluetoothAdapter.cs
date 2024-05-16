using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus;

namespace ProjectRobotica.Bluetooth
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

        internal static async Task<BluetoothAdapter> CreateAsync(IAdapter1 proxy)
        {
            BluetoothAdapter bluetoothAdapter = new BluetoothAdapter
            {
                _proxy = proxy,
            };

            bluetoothAdapter._objectManager = Connection.System.CreateProxy<IObjectManager>(BluezConstants.DbusService, "/");
            bluetoothAdapter._interfacesWatcher = await bluetoothAdapter._objectManager.WatchInterfacesAddedAsync(bluetoothAdapter.OnDeviceAddedAsync);
            bluetoothAdapter._propertyWatcher = await proxy.WatchPropertiesAsync(bluetoothAdapter.OnPropertyChanges);

            return bluetoothAdapter;
        }
        public Task StartDiscoveryAsync()
        {
            return _proxy.StartDiscoveryAsync();
        }
        public Task StopDiscoveryAsync()
        {
            return _proxy.StopDiscoveryAsync();
        }

        public void Dispose()
        {
            _interfacesWatcher?.Dispose();
            _interfacesWatcher = null;

            GC.SuppressFinalize(this);
        }

        public event DeviceChangeEventHandlerAsync DeviceFound
        {
            add
            {
                _deviceFound += value;
                FireEventForExistingDeviceAsync();
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
    }
}
