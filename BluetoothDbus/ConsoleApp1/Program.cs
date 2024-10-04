using bluez.DBus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;
using Connection = Tmds.DBus.Protocol.Connection;

string? systemBusAddress = Address.System;
if (systemBusAddress is null)
{
    Console.Write("Cannot determine system bus address");
    return 1;
}

Connection connection = new Connection(Address.System!);
await connection.ConnectAsync();
Console.WriteLine("Connected to system bus.");

var service = new bluezService(connection, "org.bluez");
var Adapter =  service.CreateAdapter1("/org/bluez/hci0");
//var Device = service.CreateObjectManager()
var ObjectManager = Connection.System.CreateProxy.CreateObjectManager("/org/bluez/");
var adapterid = await Adapter.GetAddressAsync();
Console.WriteLine($"{adapterid}");
await Adapter.StartDiscoveryAsync();
await Adapter.StopDiscoveryAsync();
var devices = ObjectManager.;
//var unknown = await ObjectManager.GetManagedObjectsAsync();
//foreach (var obj in unknown)
//{
//    Console.WriteLine($"{obj.Key.ToString}");
//}




return 0;