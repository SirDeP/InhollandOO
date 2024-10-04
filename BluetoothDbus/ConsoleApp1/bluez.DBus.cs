namespace bluez.DBus
{
    using System;
    using Tmds.DBus.Protocol;
    using SafeHandle = System.Runtime.InteropServices.SafeHandle;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    partial class ObjectManager : bluezObject
    {
        private const string __Interface = "org.freedesktop.DBus.ObjectManager";
        public ObjectManager(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task<Dictionary<ObjectPath, Dictionary<string, Dictionary<string, VariantValue>>>> GetManagedObjectsAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage(), (Message m, object? s) => ReadMessage_aeoaesaesv(m, (bluezObject)s!), this);
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "GetManagedObjects");
                return writer.CreateMessage();
            }
        }
        public ValueTask<IDisposable> WatchInterfacesAddedAsync(Action<Exception?, (ObjectPath Object, Dictionary<string, Dictionary<string, VariantValue>> Interfaces)> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
            => base.WatchSignalAsync(Service.Destination, __Interface, Path, "InterfacesAdded", (Message m, object? s) => ReadMessage_oaesaesv(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
        public ValueTask<IDisposable> WatchInterfacesRemovedAsync(Action<Exception?, (ObjectPath Object, string[] Interfaces)> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
            => base.WatchSignalAsync(Service.Destination, __Interface, Path, "InterfacesRemoved", (Message m, object? s) => ReadMessage_oas(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
    }
    partial class AgentManager1 : bluezObject
    {
        private const string __Interface = "org.bluez.AgentManager1";
        public AgentManager1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterAgentAsync(ObjectPath agent, string capability)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "os",
                    member: "RegisterAgent");
                writer.WriteObjectPath(agent);
                writer.WriteString(capability);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterAgentAsync(ObjectPath agent)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterAgent");
                writer.WriteObjectPath(agent);
                return writer.CreateMessage();
            }
        }
        public Task RequestDefaultAgentAsync(ObjectPath agent)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "RequestDefaultAgent");
                writer.WriteObjectPath(agent);
                return writer.CreateMessage();
            }
        }
    }
    partial class ProfileManager1 : bluezObject
    {
        private const string __Interface = "org.bluez.ProfileManager1";
        public ProfileManager1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterProfileAsync(ObjectPath profile, string uUID, Dictionary<string, Variant> options)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "osa{sv}",
                    member: "RegisterProfile");
                writer.WriteObjectPath(profile);
                writer.WriteString(uUID);
                writer.WriteDictionary(options);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterProfileAsync(ObjectPath profile)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterProfile");
                writer.WriteObjectPath(profile);
                return writer.CreateMessage();
            }
        }
    }
    partial class HealthManager1 : bluezObject
    {
        private const string __Interface = "org.bluez.HealthManager1";
        public HealthManager1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task<ObjectPath> CreateApplicationAsync(Dictionary<string, Variant> config)
        {
            return this.Connection.CallMethodAsync(CreateMessage(), (Message m, object? s) => ReadMessage_o(m, (bluezObject)s!), this);
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "a{sv}",
                    member: "CreateApplication");
                writer.WriteDictionary(config);
                return writer.CreateMessage();
            }
        }
        public Task DestroyApplicationAsync(ObjectPath application)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "DestroyApplication");
                writer.WriteObjectPath(application);
                return writer.CreateMessage();
            }
        }
    }
    record Adapter1Properties
    {
        public string Address { get; set; } = default!;
        public string AddressType { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Alias { get; set; } = default!;
        public uint Class { get; set; } = default!;
        public bool Powered { get; set; } = default!;
        public bool Discoverable { get; set; } = default!;
        public uint DiscoverableTimeout { get; set; } = default!;
        public bool Pairable { get; set; } = default!;
        public uint PairableTimeout { get; set; } = default!;
        public bool Discovering { get; set; } = default!;
        public string[] UUIDs { get; set; } = default!;
        public string Modalias { get; set; } = default!;
        public string[] Roles { get; set; } = default!;
        public string[] ExperimentalFeatures { get; set; } = default!;
    }
    partial class Adapter1 : bluezObject
    {
        private const string __Interface = "org.bluez.Adapter1";
        public Adapter1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task StartDiscoveryAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "StartDiscovery");
                return writer.CreateMessage();
            }
        }
        public Task SetDiscoveryFilterAsync(Dictionary<string, Variant> properties)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "a{sv}",
                    member: "SetDiscoveryFilter");
                writer.WriteDictionary(properties);
                return writer.CreateMessage();
            }
        }
        public Task StopDiscoveryAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "StopDiscovery");
                return writer.CreateMessage();
            }
        }
        public Task RemoveDeviceAsync(ObjectPath device)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "RemoveDevice");
                writer.WriteObjectPath(device);
                return writer.CreateMessage();
            }
        }
        public Task<string[]> GetDiscoveryFiltersAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage(), (Message m, object? s) => ReadMessage_as(m, (bluezObject)s!), this);
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "GetDiscoveryFilters");
                return writer.CreateMessage();
            }
        }
        public Task SetAddressAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Address");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAddressTypeAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("AddressType");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetNameAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Name");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAliasAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Alias");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetClassAsync(uint value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Class");
                writer.WriteSignature("u");
                writer.WriteUInt32(value);
                return writer.CreateMessage();
            }
        }
        public Task SetPoweredAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Powered");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetDiscoverableAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Discoverable");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetDiscoverableTimeoutAsync(uint value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("DiscoverableTimeout");
                writer.WriteSignature("u");
                writer.WriteUInt32(value);
                return writer.CreateMessage();
            }
        }
        public Task SetPairableAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Pairable");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetPairableTimeoutAsync(uint value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("PairableTimeout");
                writer.WriteSignature("u");
                writer.WriteUInt32(value);
                return writer.CreateMessage();
            }
        }
        public Task SetDiscoveringAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Discovering");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetUUIDsAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("UUIDs");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task SetModaliasAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Modalias");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetRolesAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Roles");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task SetExperimentalFeaturesAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ExperimentalFeatures");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task<string> GetAddressAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Address"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetAddressTypeAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "AddressType"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetNameAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Name"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetAliasAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Alias"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<uint> GetClassAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Class"), (Message m, object? s) => ReadMessage_v_u(m, (bluezObject)s!), this);
        public Task<bool> GetPoweredAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Powered"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetDiscoverableAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Discoverable"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<uint> GetDiscoverableTimeoutAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "DiscoverableTimeout"), (Message m, object? s) => ReadMessage_v_u(m, (bluezObject)s!), this);
        public Task<bool> GetPairableAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Pairable"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<uint> GetPairableTimeoutAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "PairableTimeout"), (Message m, object? s) => ReadMessage_v_u(m, (bluezObject)s!), this);
        public Task<bool> GetDiscoveringAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Discovering"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<string[]> GetUUIDsAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "UUIDs"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<string> GetModaliasAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Modalias"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string[]> GetRolesAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Roles"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<string[]> GetExperimentalFeaturesAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ExperimentalFeatures"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<Adapter1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static Adapter1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<Adapter1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<Adapter1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<Adapter1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "Address": invalidated.Add("Address"); break;
                        case "AddressType": invalidated.Add("AddressType"); break;
                        case "Name": invalidated.Add("Name"); break;
                        case "Alias": invalidated.Add("Alias"); break;
                        case "Class": invalidated.Add("Class"); break;
                        case "Powered": invalidated.Add("Powered"); break;
                        case "Discoverable": invalidated.Add("Discoverable"); break;
                        case "DiscoverableTimeout": invalidated.Add("DiscoverableTimeout"); break;
                        case "Pairable": invalidated.Add("Pairable"); break;
                        case "PairableTimeout": invalidated.Add("PairableTimeout"); break;
                        case "Discovering": invalidated.Add("Discovering"); break;
                        case "UUIDs": invalidated.Add("UUIDs"); break;
                        case "Modalias": invalidated.Add("Modalias"); break;
                        case "Roles": invalidated.Add("Roles"); break;
                        case "ExperimentalFeatures": invalidated.Add("ExperimentalFeatures"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static Adapter1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new Adapter1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "Address":
                        reader.ReadSignature("s");
                        props.Address = reader.ReadString();
                        changedList?.Add("Address");
                        break;
                    case "AddressType":
                        reader.ReadSignature("s");
                        props.AddressType = reader.ReadString();
                        changedList?.Add("AddressType");
                        break;
                    case "Name":
                        reader.ReadSignature("s");
                        props.Name = reader.ReadString();
                        changedList?.Add("Name");
                        break;
                    case "Alias":
                        reader.ReadSignature("s");
                        props.Alias = reader.ReadString();
                        changedList?.Add("Alias");
                        break;
                    case "Class":
                        reader.ReadSignature("u");
                        props.Class = reader.ReadUInt32();
                        changedList?.Add("Class");
                        break;
                    case "Powered":
                        reader.ReadSignature("b");
                        props.Powered = reader.ReadBool();
                        changedList?.Add("Powered");
                        break;
                    case "Discoverable":
                        reader.ReadSignature("b");
                        props.Discoverable = reader.ReadBool();
                        changedList?.Add("Discoverable");
                        break;
                    case "DiscoverableTimeout":
                        reader.ReadSignature("u");
                        props.DiscoverableTimeout = reader.ReadUInt32();
                        changedList?.Add("DiscoverableTimeout");
                        break;
                    case "Pairable":
                        reader.ReadSignature("b");
                        props.Pairable = reader.ReadBool();
                        changedList?.Add("Pairable");
                        break;
                    case "PairableTimeout":
                        reader.ReadSignature("u");
                        props.PairableTimeout = reader.ReadUInt32();
                        changedList?.Add("PairableTimeout");
                        break;
                    case "Discovering":
                        reader.ReadSignature("b");
                        props.Discovering = reader.ReadBool();
                        changedList?.Add("Discovering");
                        break;
                    case "UUIDs":
                        reader.ReadSignature("as");
                        props.UUIDs = reader.ReadArrayOfString();
                        changedList?.Add("UUIDs");
                        break;
                    case "Modalias":
                        reader.ReadSignature("s");
                        props.Modalias = reader.ReadString();
                        changedList?.Add("Modalias");
                        break;
                    case "Roles":
                        reader.ReadSignature("as");
                        props.Roles = reader.ReadArrayOfString();
                        changedList?.Add("Roles");
                        break;
                    case "ExperimentalFeatures":
                        reader.ReadSignature("as");
                        props.ExperimentalFeatures = reader.ReadArrayOfString();
                        changedList?.Add("ExperimentalFeatures");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    partial class GattManager1 : bluezObject
    {
        private const string __Interface = "org.bluez.GattManager1";
        public GattManager1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterApplicationAsync(ObjectPath application, Dictionary<string, Variant> options)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "oa{sv}",
                    member: "RegisterApplication");
                writer.WriteObjectPath(application);
                writer.WriteDictionary(options);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterApplicationAsync(ObjectPath application)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterApplication");
                writer.WriteObjectPath(application);
                return writer.CreateMessage();
            }
        }
    }
    record Media1Properties
    {
        public string[] SupportedUUIDs { get; set; } = default!;
    }
    partial class Media1 : bluezObject
    {
        private const string __Interface = "org.bluez.Media1";
        public Media1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterEndpointAsync(ObjectPath endpoint, Dictionary<string, Variant> properties)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "oa{sv}",
                    member: "RegisterEndpoint");
                writer.WriteObjectPath(endpoint);
                writer.WriteDictionary(properties);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterEndpointAsync(ObjectPath endpoint)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterEndpoint");
                writer.WriteObjectPath(endpoint);
                return writer.CreateMessage();
            }
        }
        public Task RegisterPlayerAsync(ObjectPath player, Dictionary<string, Variant> properties)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "oa{sv}",
                    member: "RegisterPlayer");
                writer.WriteObjectPath(player);
                writer.WriteDictionary(properties);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterPlayerAsync(ObjectPath player)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterPlayer");
                writer.WriteObjectPath(player);
                return writer.CreateMessage();
            }
        }
        public Task RegisterApplicationAsync(ObjectPath application, Dictionary<string, Variant> options)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "oa{sv}",
                    member: "RegisterApplication");
                writer.WriteObjectPath(application);
                writer.WriteDictionary(options);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterApplicationAsync(ObjectPath application)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterApplication");
                writer.WriteObjectPath(application);
                return writer.CreateMessage();
            }
        }
        public Task SetSupportedUUIDsAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("SupportedUUIDs");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task<string[]> GetSupportedUUIDsAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "SupportedUUIDs"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<Media1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static Media1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<Media1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<Media1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<Media1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "SupportedUUIDs": invalidated.Add("SupportedUUIDs"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static Media1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new Media1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "SupportedUUIDs":
                        reader.ReadSignature("as");
                        props.SupportedUUIDs = reader.ReadArrayOfString();
                        changedList?.Add("SupportedUUIDs");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    partial class NetworkServer1 : bluezObject
    {
        private const string __Interface = "org.bluez.NetworkServer1";
        public NetworkServer1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterAsync(string uuid, string bridge)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "ss",
                    member: "Register");
                writer.WriteString(uuid);
                writer.WriteString(bridge);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterAsync(string uuid)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "s",
                    member: "Unregister");
                writer.WriteString(uuid);
                return writer.CreateMessage();
            }
        }
    }
    record LEAdvertisingManager1Properties
    {
        public byte ActiveInstances { get; set; } = default!;
        public byte SupportedInstances { get; set; } = default!;
        public string[] SupportedIncludes { get; set; } = default!;
        public string[] SupportedSecondaryChannels { get; set; } = default!;
    }
    partial class LEAdvertisingManager1 : bluezObject
    {
        private const string __Interface = "org.bluez.LEAdvertisingManager1";
        public LEAdvertisingManager1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task RegisterAdvertisementAsync(ObjectPath advertisement, Dictionary<string, Variant> options)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "oa{sv}",
                    member: "RegisterAdvertisement");
                writer.WriteObjectPath(advertisement);
                writer.WriteDictionary(options);
                return writer.CreateMessage();
            }
        }
        public Task UnregisterAdvertisementAsync(ObjectPath service)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "o",
                    member: "UnregisterAdvertisement");
                writer.WriteObjectPath(service);
                return writer.CreateMessage();
            }
        }
        public Task SetActiveInstancesAsync(byte value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ActiveInstances");
                writer.WriteSignature("y");
                writer.WriteByte(value);
                return writer.CreateMessage();
            }
        }
        public Task SetSupportedInstancesAsync(byte value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("SupportedInstances");
                writer.WriteSignature("y");
                writer.WriteByte(value);
                return writer.CreateMessage();
            }
        }
        public Task SetSupportedIncludesAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("SupportedIncludes");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task SetSupportedSecondaryChannelsAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("SupportedSecondaryChannels");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task<byte> GetActiveInstancesAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ActiveInstances"), (Message m, object? s) => ReadMessage_v_y(m, (bluezObject)s!), this);
        public Task<byte> GetSupportedInstancesAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "SupportedInstances"), (Message m, object? s) => ReadMessage_v_y(m, (bluezObject)s!), this);
        public Task<string[]> GetSupportedIncludesAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "SupportedIncludes"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<string[]> GetSupportedSecondaryChannelsAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "SupportedSecondaryChannels"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<LEAdvertisingManager1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static LEAdvertisingManager1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<LEAdvertisingManager1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<LEAdvertisingManager1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<LEAdvertisingManager1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "ActiveInstances": invalidated.Add("ActiveInstances"); break;
                        case "SupportedInstances": invalidated.Add("SupportedInstances"); break;
                        case "SupportedIncludes": invalidated.Add("SupportedIncludes"); break;
                        case "SupportedSecondaryChannels": invalidated.Add("SupportedSecondaryChannels"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static LEAdvertisingManager1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new LEAdvertisingManager1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "ActiveInstances":
                        reader.ReadSignature("y");
                        props.ActiveInstances = reader.ReadByte();
                        changedList?.Add("ActiveInstances");
                        break;
                    case "SupportedInstances":
                        reader.ReadSignature("y");
                        props.SupportedInstances = reader.ReadByte();
                        changedList?.Add("SupportedInstances");
                        break;
                    case "SupportedIncludes":
                        reader.ReadSignature("as");
                        props.SupportedIncludes = reader.ReadArrayOfString();
                        changedList?.Add("SupportedIncludes");
                        break;
                    case "SupportedSecondaryChannels":
                        reader.ReadSignature("as");
                        props.SupportedSecondaryChannels = reader.ReadArrayOfString();
                        changedList?.Add("SupportedSecondaryChannels");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    record Device1Properties
    {
        public string Address { get; set; } = default!;
        public string AddressType { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Alias { get; set; } = default!;
        public uint Class { get; set; } = default!;
        public ushort Appearance { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public bool Paired { get; set; } = default!;
        public bool Bonded { get; set; } = default!;
        public bool Trusted { get; set; } = default!;
        public bool Blocked { get; set; } = default!;
        public bool LegacyPairing { get; set; } = default!;
        public short RSSI { get; set; } = default!;
        public bool Connected { get; set; } = default!;
        public string[] UUIDs { get; set; } = default!;
        public string Modalias { get; set; } = default!;
        public ObjectPath Adapter { get; set; } = default!;
        public Dictionary<ushort, VariantValue> ManufacturerData { get; set; } = default!;
        public Dictionary<string, VariantValue> ServiceData { get; set; } = default!;
        public short TxPower { get; set; } = default!;
        public bool ServicesResolved { get; set; } = default!;
        public bool WakeAllowed { get; set; } = default!;
    }
    partial class Device1 : bluezObject
    {
        private const string __Interface = "org.bluez.Device1";
        public Device1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task DisconnectAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Disconnect");
                return writer.CreateMessage();
            }
        }
        public Task ConnectAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Connect");
                return writer.CreateMessage();
            }
        }
        public Task ConnectProfileAsync(string uUID)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "s",
                    member: "ConnectProfile");
                writer.WriteString(uUID);
                return writer.CreateMessage();
            }
        }
        public Task DisconnectProfileAsync(string uUID)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    signature: "s",
                    member: "DisconnectProfile");
                writer.WriteString(uUID);
                return writer.CreateMessage();
            }
        }
        public Task PairAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Pair");
                return writer.CreateMessage();
            }
        }
        public Task CancelPairingAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "CancelPairing");
                return writer.CreateMessage();
            }
        }
        public Task SetAddressAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Address");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAddressTypeAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("AddressType");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetNameAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Name");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAliasAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Alias");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetClassAsync(uint value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Class");
                writer.WriteSignature("u");
                writer.WriteUInt32(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAppearanceAsync(ushort value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Appearance");
                writer.WriteSignature("q");
                writer.WriteUInt16(value);
                return writer.CreateMessage();
            }
        }
        public Task SetIconAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Icon");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetPairedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Paired");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetBondedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Bonded");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetTrustedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Trusted");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetBlockedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Blocked");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetLegacyPairingAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("LegacyPairing");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetRSSIAsync(short value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("RSSI");
                writer.WriteSignature("n");
                writer.WriteInt16(value);
                return writer.CreateMessage();
            }
        }
        public Task SetConnectedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Connected");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetUUIDsAsync(string[] value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("UUIDs");
                writer.WriteSignature("as");
                writer.WriteArray(value);
                return writer.CreateMessage();
            }
        }
        public Task SetModaliasAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Modalias");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task SetAdapterAsync(ObjectPath value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Adapter");
                writer.WriteSignature("o");
                writer.WriteObjectPath(value);
                return writer.CreateMessage();
            }
        }
        public Task SetManufacturerDataAsync(Dictionary<ushort, Variant> value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ManufacturerData");
                writer.WriteSignature("a{qv}");
                WriteType_aeqv(ref writer, value);
                return writer.CreateMessage();
            }
        }
        public Task SetServiceDataAsync(Dictionary<string, Variant> value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ServiceData");
                writer.WriteSignature("a{sv}");
                writer.WriteDictionary(value);
                return writer.CreateMessage();
            }
        }
        public Task SetTxPowerAsync(short value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("TxPower");
                writer.WriteSignature("n");
                writer.WriteInt16(value);
                return writer.CreateMessage();
            }
        }
        public Task SetServicesResolvedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ServicesResolved");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetWakeAllowedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("WakeAllowed");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task<string> GetAddressAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Address"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetAddressTypeAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "AddressType"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetNameAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Name"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<string> GetAliasAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Alias"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<uint> GetClassAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Class"), (Message m, object? s) => ReadMessage_v_u(m, (bluezObject)s!), this);
        public Task<ushort> GetAppearanceAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Appearance"), (Message m, object? s) => ReadMessage_v_q(m, (bluezObject)s!), this);
        public Task<string> GetIconAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Icon"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<bool> GetPairedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Paired"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetBondedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Bonded"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetTrustedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Trusted"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetBlockedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Blocked"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetLegacyPairingAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "LegacyPairing"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<short> GetRSSIAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "RSSI"), (Message m, object? s) => ReadMessage_v_n(m, (bluezObject)s!), this);
        public Task<bool> GetConnectedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Connected"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<string[]> GetUUIDsAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "UUIDs"), (Message m, object? s) => ReadMessage_v_as(m, (bluezObject)s!), this);
        public Task<string> GetModaliasAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Modalias"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<ObjectPath> GetAdapterAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Adapter"), (Message m, object? s) => ReadMessage_v_o(m, (bluezObject)s!), this);
        public Task<Dictionary<ushort, VariantValue>> GetManufacturerDataAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ManufacturerData"), (Message m, object? s) => ReadMessage_v_aeqv(m, (bluezObject)s!), this);
        public Task<Dictionary<string, VariantValue>> GetServiceDataAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ServiceData"), (Message m, object? s) => ReadMessage_v_aesv(m, (bluezObject)s!), this);
        public Task<short> GetTxPowerAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "TxPower"), (Message m, object? s) => ReadMessage_v_n(m, (bluezObject)s!), this);
        public Task<bool> GetServicesResolvedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ServicesResolved"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<bool> GetWakeAllowedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "WakeAllowed"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<Device1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static Device1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<Device1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<Device1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<Device1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "Address": invalidated.Add("Address"); break;
                        case "AddressType": invalidated.Add("AddressType"); break;
                        case "Name": invalidated.Add("Name"); break;
                        case "Alias": invalidated.Add("Alias"); break;
                        case "Class": invalidated.Add("Class"); break;
                        case "Appearance": invalidated.Add("Appearance"); break;
                        case "Icon": invalidated.Add("Icon"); break;
                        case "Paired": invalidated.Add("Paired"); break;
                        case "Bonded": invalidated.Add("Bonded"); break;
                        case "Trusted": invalidated.Add("Trusted"); break;
                        case "Blocked": invalidated.Add("Blocked"); break;
                        case "LegacyPairing": invalidated.Add("LegacyPairing"); break;
                        case "RSSI": invalidated.Add("RSSI"); break;
                        case "Connected": invalidated.Add("Connected"); break;
                        case "UUIDs": invalidated.Add("UUIDs"); break;
                        case "Modalias": invalidated.Add("Modalias"); break;
                        case "Adapter": invalidated.Add("Adapter"); break;
                        case "ManufacturerData": invalidated.Add("ManufacturerData"); break;
                        case "ServiceData": invalidated.Add("ServiceData"); break;
                        case "TxPower": invalidated.Add("TxPower"); break;
                        case "ServicesResolved": invalidated.Add("ServicesResolved"); break;
                        case "WakeAllowed": invalidated.Add("WakeAllowed"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static Device1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new Device1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "Address":
                        reader.ReadSignature("s");
                        props.Address = reader.ReadString();
                        changedList?.Add("Address");
                        break;
                    case "AddressType":
                        reader.ReadSignature("s");
                        props.AddressType = reader.ReadString();
                        changedList?.Add("AddressType");
                        break;
                    case "Name":
                        reader.ReadSignature("s");
                        props.Name = reader.ReadString();
                        changedList?.Add("Name");
                        break;
                    case "Alias":
                        reader.ReadSignature("s");
                        props.Alias = reader.ReadString();
                        changedList?.Add("Alias");
                        break;
                    case "Class":
                        reader.ReadSignature("u");
                        props.Class = reader.ReadUInt32();
                        changedList?.Add("Class");
                        break;
                    case "Appearance":
                        reader.ReadSignature("q");
                        props.Appearance = reader.ReadUInt16();
                        changedList?.Add("Appearance");
                        break;
                    case "Icon":
                        reader.ReadSignature("s");
                        props.Icon = reader.ReadString();
                        changedList?.Add("Icon");
                        break;
                    case "Paired":
                        reader.ReadSignature("b");
                        props.Paired = reader.ReadBool();
                        changedList?.Add("Paired");
                        break;
                    case "Bonded":
                        reader.ReadSignature("b");
                        props.Bonded = reader.ReadBool();
                        changedList?.Add("Bonded");
                        break;
                    case "Trusted":
                        reader.ReadSignature("b");
                        props.Trusted = reader.ReadBool();
                        changedList?.Add("Trusted");
                        break;
                    case "Blocked":
                        reader.ReadSignature("b");
                        props.Blocked = reader.ReadBool();
                        changedList?.Add("Blocked");
                        break;
                    case "LegacyPairing":
                        reader.ReadSignature("b");
                        props.LegacyPairing = reader.ReadBool();
                        changedList?.Add("LegacyPairing");
                        break;
                    case "RSSI":
                        reader.ReadSignature("n");
                        props.RSSI = reader.ReadInt16();
                        changedList?.Add("RSSI");
                        break;
                    case "Connected":
                        reader.ReadSignature("b");
                        props.Connected = reader.ReadBool();
                        changedList?.Add("Connected");
                        break;
                    case "UUIDs":
                        reader.ReadSignature("as");
                        props.UUIDs = reader.ReadArrayOfString();
                        changedList?.Add("UUIDs");
                        break;
                    case "Modalias":
                        reader.ReadSignature("s");
                        props.Modalias = reader.ReadString();
                        changedList?.Add("Modalias");
                        break;
                    case "Adapter":
                        reader.ReadSignature("o");
                        props.Adapter = reader.ReadObjectPath();
                        changedList?.Add("Adapter");
                        break;
                    case "ManufacturerData":
                        reader.ReadSignature("a{qv}");
                        props.ManufacturerData = ReadType_aeqv(ref reader);
                        changedList?.Add("ManufacturerData");
                        break;
                    case "ServiceData":
                        reader.ReadSignature("a{sv}");
                        props.ServiceData = reader.ReadDictionaryOfStringToVariantValue();
                        changedList?.Add("ServiceData");
                        break;
                    case "TxPower":
                        reader.ReadSignature("n");
                        props.TxPower = reader.ReadInt16();
                        changedList?.Add("TxPower");
                        break;
                    case "ServicesResolved":
                        reader.ReadSignature("b");
                        props.ServicesResolved = reader.ReadBool();
                        changedList?.Add("ServicesResolved");
                        break;
                    case "WakeAllowed":
                        reader.ReadSignature("b");
                        props.WakeAllowed = reader.ReadBool();
                        changedList?.Add("WakeAllowed");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    record MediaControl1Properties
    {
        public bool Connected { get; set; } = default!;
        public ObjectPath Player { get; set; } = default!;
    }
    partial class MediaControl1 : bluezObject
    {
        private const string __Interface = "org.bluez.MediaControl1";
        public MediaControl1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task PlayAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Play");
                return writer.CreateMessage();
            }
        }
        public Task PauseAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Pause");
                return writer.CreateMessage();
            }
        }
        public Task StopAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Stop");
                return writer.CreateMessage();
            }
        }
        public Task NextAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Next");
                return writer.CreateMessage();
            }
        }
        public Task PreviousAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Previous");
                return writer.CreateMessage();
            }
        }
        public Task VolumeUpAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "VolumeUp");
                return writer.CreateMessage();
            }
        }
        public Task VolumeDownAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "VolumeDown");
                return writer.CreateMessage();
            }
        }
        public Task FastForwardAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "FastForward");
                return writer.CreateMessage();
            }
        }
        public Task RewindAsync()
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: __Interface,
                    member: "Rewind");
                return writer.CreateMessage();
            }
        }
        public Task SetConnectedAsync(bool value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Connected");
                writer.WriteSignature("b");
                writer.WriteBool(value);
                return writer.CreateMessage();
            }
        }
        public Task SetPlayerAsync(ObjectPath value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("Player");
                writer.WriteSignature("o");
                writer.WriteObjectPath(value);
                return writer.CreateMessage();
            }
        }
        public Task<bool> GetConnectedAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Connected"), (Message m, object? s) => ReadMessage_v_b(m, (bluezObject)s!), this);
        public Task<ObjectPath> GetPlayerAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "Player"), (Message m, object? s) => ReadMessage_v_o(m, (bluezObject)s!), this);
        public Task<MediaControl1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static MediaControl1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<MediaControl1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<MediaControl1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<MediaControl1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "Connected": invalidated.Add("Connected"); break;
                        case "Player": invalidated.Add("Player"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static MediaControl1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new MediaControl1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "Connected":
                        reader.ReadSignature("b");
                        props.Connected = reader.ReadBool();
                        changedList?.Add("Connected");
                        break;
                    case "Player":
                        reader.ReadSignature("o");
                        props.Player = reader.ReadObjectPath();
                        changedList?.Add("Player");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    record Input1Properties
    {
        public string ReconnectMode { get; set; } = default!;
    }
    partial class Input1 : bluezObject
    {
        private const string __Interface = "org.bluez.Input1";
        public Input1(bluezService service, ObjectPath path) : base(service, path)
        { }
        public Task SetReconnectModeAsync(string value)
        {
            return this.Connection.CallMethodAsync(CreateMessage());
            MessageBuffer CreateMessage()
            {
                var writer = this.Connection.GetMessageWriter();
                writer.WriteMethodCallHeader(
                    destination: Service.Destination,
                    path: Path,
                    @interface: "org.freedesktop.DBus.Properties",
                    signature: "ssv",
                    member: "Set");
                writer.WriteString(__Interface);
                writer.WriteString("ReconnectMode");
                writer.WriteSignature("s");
                writer.WriteString(value);
                return writer.CreateMessage();
            }
        }
        public Task<string> GetReconnectModeAsync()
            => this.Connection.CallMethodAsync(CreateGetPropertyMessage(__Interface, "ReconnectMode"), (Message m, object? s) => ReadMessage_v_s(m, (bluezObject)s!), this);
        public Task<Input1Properties> GetPropertiesAsync()
        {
            return this.Connection.CallMethodAsync(CreateGetAllPropertiesMessage(__Interface), (Message m, object? s) => ReadMessage(m, (bluezObject)s!), this);
            static Input1Properties ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                return ReadProperties(ref reader);
            }
        }
        public ValueTask<IDisposable> WatchPropertiesChangedAsync(Action<Exception?, PropertyChanges<Input1Properties>> handler, bool emitOnCapturedContext = true, ObserverFlags flags = ObserverFlags.None)
        {
            return base.WatchPropertiesChangedAsync(__Interface, (Message m, object? s) => ReadMessage(m, (bluezObject)s!), handler, emitOnCapturedContext, flags);
            static PropertyChanges<Input1Properties> ReadMessage(Message message, bluezObject _)
            {
                var reader = message.GetBodyReader();
                reader.ReadString(); // interface
                List<string> changed = new(), invalidated = new();
                return new PropertyChanges<Input1Properties>(ReadProperties(ref reader, changed), changed.ToArray(), ReadInvalidated(ref reader));
            }
            static string[] ReadInvalidated(ref Reader reader)
            {
                List<string>? invalidated = null;
                ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.String);
                while (reader.HasNext(arrayEnd))
                {
                    invalidated ??= new();
                    var property = reader.ReadString();
                    switch (property)
                    {
                        case "ReconnectMode": invalidated.Add("ReconnectMode"); break;
                    }
                }
                return invalidated?.ToArray() ?? Array.Empty<string>();
            }
        }
        private static Input1Properties ReadProperties(ref Reader reader, List<string>? changedList = null)
        {
            var props = new Input1Properties();
            ArrayEnd arrayEnd = reader.ReadArrayStart(DBusType.Struct);
            while (reader.HasNext(arrayEnd))
            {
                var property = reader.ReadString();
                switch (property)
                {
                    case "ReconnectMode":
                        reader.ReadSignature("s");
                        props.ReconnectMode = reader.ReadString();
                        changedList?.Add("ReconnectMode");
                        break;
                    default:
                        reader.ReadVariantValue();
                        break;
                }
            }
            return props;
        }
    }
    partial class bluezService
    {
        public Tmds.DBus.Protocol.Connection Connection { get; }
        public string Destination { get; }
        public bluezService(Tmds.DBus.Protocol.Connection connection, string destination)
            => (Connection, Destination) = (connection, destination);
        public ObjectManager CreateObjectManager(string path) => new ObjectManager(this, path);
        public AgentManager1 CreateAgentManager1(string path) => new AgentManager1(this, path);
        public ProfileManager1 CreateProfileManager1(string path) => new ProfileManager1(this, path);
        public HealthManager1 CreateHealthManager1(string path) => new HealthManager1(this, path);
        public Adapter1 CreateAdapter1(string path) => new Adapter1(this, path);
        public GattManager1 CreateGattManager1(string path) => new GattManager1(this, path);
        public Media1 CreateMedia1(string path) => new Media1(this, path);
        public NetworkServer1 CreateNetworkServer1(string path) => new NetworkServer1(this, path);
        public LEAdvertisingManager1 CreateLEAdvertisingManager1(string path) => new LEAdvertisingManager1(this, path);
        public Device1 CreateDevice1(string path) => new Device1(this, path);
        public MediaControl1 CreateMediaControl1(string path) => new MediaControl1(this, path);
        public Input1 CreateInput1(string path) => new Input1(this, path);
    }
    class bluezObject
    {
        public bluezService Service { get; }
        public ObjectPath Path { get; }
        protected Tmds.DBus.Protocol.Connection Connection => Service.Connection;
        protected bluezObject(bluezService service, ObjectPath path)
            => (Service, Path) = (service, path);
        protected MessageBuffer CreateGetPropertyMessage(string @interface, string property)
        {
            var writer = this.Connection.GetMessageWriter();
            writer.WriteMethodCallHeader(
                destination: Service.Destination,
                path: Path,
                @interface: "org.freedesktop.DBus.Properties",
                signature: "ss",
                member: "Get");
            writer.WriteString(@interface);
            writer.WriteString(property);
            return writer.CreateMessage();
        }
        protected MessageBuffer CreateGetAllPropertiesMessage(string @interface)
        {
            var writer = this.Connection.GetMessageWriter();
            writer.WriteMethodCallHeader(
                destination: Service.Destination,
                path: Path,
                @interface: "org.freedesktop.DBus.Properties",
                signature: "s",
                member: "GetAll");
            writer.WriteString(@interface);
            return writer.CreateMessage();
        }
        protected ValueTask<IDisposable> WatchPropertiesChangedAsync<TProperties>(string @interface, MessageValueReader<PropertyChanges<TProperties>> reader, Action<Exception?, PropertyChanges<TProperties>> handler, bool emitOnCapturedContext, ObserverFlags flags)
        {
            var rule = new MatchRule
            {
                Type = MessageType.Signal,
                Sender = Service.Destination,
                Path = Path,
                Interface = "org.freedesktop.DBus.Properties",
                Member = "PropertiesChanged",
                Arg0 = @interface
            };
            return this.Connection.AddMatchAsync(rule, reader,
                                                    (Exception? ex, PropertyChanges<TProperties> changes, object? rs, object? hs) => ((Action<Exception?, PropertyChanges<TProperties>>)hs!).Invoke(ex, changes),
                                                    this, handler, emitOnCapturedContext, flags);
        }
        public ValueTask<IDisposable> WatchSignalAsync<TArg>(string sender, string @interface, ObjectPath path, string signal, MessageValueReader<TArg> reader, Action<Exception?, TArg> handler, bool emitOnCapturedContext, ObserverFlags flags)
        {
            var rule = new MatchRule
            {
                Type = MessageType.Signal,
                Sender = sender,
                Path = path,
                Member = signal,
                Interface = @interface
            };
            return this.Connection.AddMatchAsync(rule, reader,
                                                    (Exception? ex, TArg arg, object? rs, object? hs) => ((Action<Exception?, TArg>)hs!).Invoke(ex, arg),
                                                    this, handler, emitOnCapturedContext, flags);
        }
        public ValueTask<IDisposable> WatchSignalAsync(string sender, string @interface, ObjectPath path, string signal, Action<Exception?> handler, bool emitOnCapturedContext, ObserverFlags flags)
        {
            var rule = new MatchRule
            {
                Type = MessageType.Signal,
                Sender = sender,
                Path = path,
                Member = signal,
                Interface = @interface
            };
            return this.Connection.AddMatchAsync<object>(rule, (Message message, object? state) => null!,
                                                            (Exception? ex, object v, object? rs, object? hs) => ((Action<Exception?>)hs!).Invoke(ex), this, handler, emitOnCapturedContext, flags);
        }
        protected static Dictionary<ObjectPath, Dictionary<string, Dictionary<string, VariantValue>>> ReadMessage_aeoaesaesv(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            return ReadType_aeoaesaesv(ref reader);
        }
        protected static (ObjectPath, Dictionary<string, Dictionary<string, VariantValue>>) ReadMessage_oaesaesv(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            var arg0 = reader.ReadObjectPath();
            var arg1 = ReadType_aesaesv(ref reader);
            return (arg0, arg1);
        }
        protected static (ObjectPath, string[]) ReadMessage_oas(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            var arg0 = reader.ReadObjectPath();
            var arg1 = reader.ReadArrayOfString();
            return (arg0, arg1);
        }
        protected static ObjectPath ReadMessage_o(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            return reader.ReadObjectPath();
        }
        protected static string[] ReadMessage_as(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            return reader.ReadArrayOfString();
        }
        protected static string ReadMessage_v_s(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("s");
            return reader.ReadString();
        }
        protected static uint ReadMessage_v_u(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("u");
            return reader.ReadUInt32();
        }
        protected static bool ReadMessage_v_b(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("b");
            return reader.ReadBool();
        }
        protected static string[] ReadMessage_v_as(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("as");
            return reader.ReadArrayOfString();
        }
        protected static byte ReadMessage_v_y(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("y");
            return reader.ReadByte();
        }
        protected static ushort ReadMessage_v_q(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("q");
            return reader.ReadUInt16();
        }
        protected static short ReadMessage_v_n(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("n");
            return reader.ReadInt16();
        }
        protected static ObjectPath ReadMessage_v_o(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("o");
            return reader.ReadObjectPath();
        }
        protected static Dictionary<ushort, VariantValue> ReadMessage_v_aeqv(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("a{qv}");
            return ReadType_aeqv(ref reader);
        }
        protected static Dictionary<string, VariantValue> ReadMessage_v_aesv(Message message, bluezObject _)
        {
            var reader = message.GetBodyReader();
            reader.ReadSignature("a{sv}");
            return reader.ReadDictionaryOfStringToVariantValue();
        }
        protected static Dictionary<ushort, VariantValue> ReadType_aeqv(ref Reader reader)
        {
            Dictionary<ushort, VariantValue> dictionary = new();
            ArrayEnd dictEnd = reader.ReadDictionaryStart();
            while (reader.HasNext(dictEnd))
            {
                var key = reader.ReadUInt16();
                var value = reader.ReadVariantValue();
                dictionary[key] = value;
            }
            return dictionary;
        }
        protected static Dictionary<ObjectPath, Dictionary<string, Dictionary<string, VariantValue>>> ReadType_aeoaesaesv(ref Reader reader)
        {
            Dictionary<ObjectPath, Dictionary<string, Dictionary<string, VariantValue>>> dictionary = new();
            ArrayEnd dictEnd = reader.ReadDictionaryStart();
            while (reader.HasNext(dictEnd))
            {
                var key = reader.ReadObjectPath();
                var value = ReadType_aesaesv(ref reader);
                dictionary[key] = value;
            }
            return dictionary;
        }
        protected static Dictionary<string, Dictionary<string, VariantValue>> ReadType_aesaesv(ref Reader reader)
        {
            Dictionary<string, Dictionary<string, VariantValue>> dictionary = new();
            ArrayEnd dictEnd = reader.ReadDictionaryStart();
            while (reader.HasNext(dictEnd))
            {
                var key = reader.ReadString();
                var value = reader.ReadDictionaryOfStringToVariantValue();
                dictionary[key] = value;
            }
            return dictionary;
        }
        protected static void WriteType_aeqv(ref MessageWriter writer, Dictionary<ushort, Variant> value)
        {
            ArrayStart arrayStart = writer.WriteDictionaryStart();
            foreach (var item in value)
            {
                writer.WriteDictionaryEntryStart();
                writer.WriteUInt16(item.Key);
                writer.WriteVariant(item.Value);
            }
            writer.WriteDictionaryEnd(arrayStart);
        }
    }
    class PropertyChanges<TProperties>
    {
        public PropertyChanges(TProperties properties, string[] invalidated, string[] changed)
        	=> (Properties, Invalidated, Changed) = (properties, invalidated, changed);
        public TProperties Properties { get; }
        public string[] Invalidated { get; }
        public string[] Changed { get; }
        public bool HasChanged(string property) => Array.IndexOf(Changed, property) != -1;
        public bool IsInvalidated(string property) => Array.IndexOf(Invalidated, property) != -1;
    }
}
