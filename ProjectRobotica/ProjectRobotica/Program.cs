//using System.ComponentModel.Design;
//using ProjectRobotica.Controller;
////using Linux.Bluetooth;
//using static System.Net.Mime.MediaTypeNames;

//namespace ProjectRobotica
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                PS4Controller controller = new("/dev/input/js0", false);
//                //PS4Controller controller = new("/dev/input/js0", false);
//                while (true)
//                {
//                    if (controller.Update())
//                    {
//                        controller.Print();
//                        //    //Uncomment the code below to have raw bytes printed to console after each update is detected

//                        //    //Convert the bytes to a string and print them
//                        //    string hex = BitConverter.ToString(controller.deviceBytes.ToArray());
//                        //    Console.WriteLine(hex);
//                    }
//                    //Console.WriteLine(controller.state.GetButtonState(ControllerButtons.PSMenu));


//                }
//            }
//            catch(Exception e) { Console.WriteLine(e.Message); }
//        }
//    }
//}

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class BlueZInterop
{
    const string BlueZLib = "libbluetooth.so"; // or the appropriate library name

    [DllImport(BlueZLib)]
    public static extern int hci_get_route(IntPtr bdaddr);
    [DllImport(BlueZLib)]
    public static extern int hci_devba(int dev_id, byte[] bdaddr);
    [DllImport(BlueZLib)]
    public static extern int ba2str(byte[] bdaddr, IntPtr str);

    [DllImport(BlueZLib)]
    public static extern int hci_disconnect(int sock, ushort handle, int reason);

    [DllImport(BlueZLib)]
    public static extern int hci_le_create_conn(int dev_id, ushort interval, ushort window, ushort initiator_filter, byte peer_bdaddr_type, IntPtr peer_bdaddr, byte own_bdaddr_type, ushort min_interval, ushort max_interval, ushort latency, ushort supervision_timeout, ushort min_ce_length, ushort max_ce_length);

    // Function to get the handle of the device with the specified address
    [DllImport(BlueZLib)]
    public static extern int hci_get_conn_handle(int dev_id, IntPtr bdaddr, ushort psm, ushort key_flag, out ushort handle);
    // Define other BlueZ functions similarly
    public static string ExecuteCommand(string command)
    {
        Process process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = $"-c \"{command}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return output;
    }

}

class Program
{
    static void Main()
    {
        byte[] bdaddr = new byte[6]; //= Marshal.AllocHGlobal(6); // You would need to initialize this properly
        int deviceID = BlueZInterop.hci_get_route(IntPtr.Zero);
        BlueZInterop.hci_devba(deviceID, bdaddr);
        IntPtr str = Marshal.AllocHGlobal(18);
        //Console.ReadLine();
        BlueZInterop.ba2str(bdaddr, str);
        string adapterAdress = Marshal.PtrToStringAnsi(str);

        Console.WriteLine("Bluetooth device ID: " + deviceID);
        Console.WriteLine("Bluetooth adapter adress: " + adapterAdress);

        //Console.ReadLine();

        //GetActiveConnection(); // List<ushort> activeConnections = 
        //DisconnectDevice(Convert.ToUInt16(GetActiveConnection()));
        // Print the connection handles
        //Console.WriteLine("Active connection handles:");
        //foreach (ushort handle in activeConnections)
        //{
        //DBus
        //    Console.WriteLine(handle);
        //}

        //Marshal.FreeHGlobal(bdaddr);
        Marshal.FreeHGlobal(str);
    }
    static void DisconnectDevice(ushort handle)
    {
        // Disconnect the device
        int result = BlueZInterop.hci_disconnect(0 /* Assuming default socket */, handle, 0 /* Reason code */);
        if (result == 0)
        {
            Console.WriteLine("Disconnected device with handle: " + handle);
        }
        else
        {
            Console.WriteLine("Failed to disconnect device with handle: " + handle);
        }
    }
    static string GetActiveConnection()
    {
        

        // Execute the command to list active connections
        string output = BlueZInterop.ExecuteCommand("hcitool con");
        int index = output.IndexOf("handle");
        string portion;
            if (index != -1)
            {
                // Extract the substring after the word
                portion = output.Substring(index + "handle ".Length, 2);
                //string portion2 = portion.Substring(index + "handle ".Length);
                Console.WriteLine(portion);
                return portion;
            }
        return null;
        // Parse the output to extract connection handles
        //string[] lines = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        //foreach (string line in lines)
        //{
        //    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        //    if (parts.Length >= 2)
        //    {
        //        ushort handle;
        //        if (ushort.TryParse(parts[0], out handle))
        //        {
        //            activeConnections.Add(handle);
        //        }
        //    }
        //}

        //return activeConnections;
    }
}
