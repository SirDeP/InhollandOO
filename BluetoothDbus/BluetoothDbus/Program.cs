//using bluez.DBus;
using System;
using System.Threading.Tasks;
using Tmds.DBus;

class Program
{
    static async Task Main(string[] args)
    {
        const string adapterPath = "/org/bluez/hci0"; // Change if your adapter is different

        var systemConnection = new Connection(Address.System);
        await systemConnection.ConnectAsync();

        var adapter = systemConnection.CreateProxy<IAdapter1>("org.bluez", adapterPath);
        var adapterProperties = systemConnection.CreateProxy<IProperties>("org.bluez", adapterPath);

        // Ensure the adapter is powered on
        var properties = await adapterProperties.GetAllAsync();
        if (!properties["Powered"].Equals(true))
        {
            await adapterProperties.SetAsync("org.bluez.Adapter1", "Powered", true);
        }

        // Start discovery
        await adapter.StartDiscoveryAsync();
        Console.WriteLine("Scanning for BLE devices...");

        // Listen for DeviceFound signals
        var objectManager = systemConnection.CreateProxy<IObjectManager>("org.freedesktop.DBus.ObjectManager", "/");
        objectManager.InterfacesAdded += (path, interfaces) =>
        {
            if (interfaces.ContainsKey("org.bluez.Device1"))
            {
                var deviceProperties = interfaces["org.bluez.Device1"];
                if (deviceProperties.TryGetValue("Name", out var deviceName) && deviceProperties.TryGetValue("Address", out var deviceAddress))
                {
                    Console.WriteLine($"Device found: {deviceName} ({deviceAddress})");
                }
            }
        };

        // Keep the application running
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

        // Stop discovery
        await adapter.StopDiscoveryAsync();
        //await systemConnection.();
    }
}

[DBusInterface("org.bluez.Adapter1")]
interface IAdapter1 : IDBusObject
{
    Task StartDiscoveryAsync();
    Task StopDiscoveryAsync();
}

[DBusInterface("org.freedesktop.DBus.Properties")]
interface IProperties : IDBusObject
{
    Task<IDictionary<string, object>> GetAllAsync();
    Task SetAsync(string iface, string prop, object val);
}

[DBusInterface("org.freedesktop.DBus.ObjectManager")]
interface IObjectManager : IDBusObject
{
    event Action<ObjectPath, IDictionary<string, IDictionary<string, object>>> InterfacesAdded;
    event Action<ObjectPath, IList<string>> InterfacesRemoved;
}