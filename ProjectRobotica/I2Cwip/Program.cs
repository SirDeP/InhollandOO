//using Unosquare.PiGpio;
//using Unosquare.PiGpio.NativeMethods;

//namespace I2Cwip
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //Console.WriteLine("Hello, World!");
//            Setup.GpioInitialise();
//            var bus = I2c.I2cOpen(1, 0x1E);

//            if (bus >= 0)
//            {
//                I2c.I2cWriteByteData(bus, 0x00, 0xF8);
//                I2c.I2cWriteByteData(bus, 0x02, 0x00);

//                DateTime time = DateTime.Now;

//                while ((time.Second - DateTime.Now.Second) < 60)
//                {
//                    byte[] store = I2c.I2cReadI2cBlockData(bus, 0x03, 6);
//                    short x = (short)((store[0] << 8) | store[1]);
//                    short y = (short)((store[4] << 8) | store[5]);
//                    short z = (short)((store[2] << 8) | store[3]);
//                    Console.WriteLine($"{x}, {y}, {z}");
//                }
//                I2c.I2cClose(bus);
//                Setup.GpioTerminate();

//            }

//        }
//    }
//}
using System;
using Unosquare.PiGpio;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;

class Program
{
    const int BUS_ID = 1;
    const int HMC5883L_I2C_ADDR = 0x1E;

    static void Main()
    {
        // Initialize PiGpio
        Setup.GpioInitialise();

        // Open I2C bus
        var handle = I2c.I2cOpen(BUS_ID, HMC5883L_I2C_ADDR);
        byte[] buffer = new byte[4000];
        if (handle >= 0)
        {
            try
            {
                // Initialize HMC5883L
                int i = I2c.I2cReadDevice(handle, buffer);
                if (i > 0) { 
                    Console.WriteLine($"{buffer}"); 
                }
                //I2c.I2cWriteDevice(handle, new byte[] { 0x00, 0x70 }); // CRA 8-average, 15 Hz, normal measurement
                //I2c.I2cWriteDevice(handle, new byte[] { 0x01, 0xA0 }); // CRB Gain = 5
                //I2c.I2cWriteDevice(handle, new byte[] { 0x02, 0x00 }); // Mode continuous reads

                //while (true) // Replace with your runtime condition
                //{
                //    // Read 6 bytes from the device starting at register 0x03
                //    byte[] readBuffer = new byte[6];
                //    byte[] bytesRead = I2c.I2cReadI2cBlockData(handle, 0x03, readBuffer.Length);

                //    if (bytesRead.Length == readBuffer.Length)
                //    {
                //        // Unpack the data (big endian)
                //        short x = (short)((readBuffer[0] << 8) | readBuffer[1]);
                //        short y = (short)((readBuffer[4] << 8) | readBuffer[5]);
                //        short z = (short)((readBuffer[2] << 8) | readBuffer[3]);

                //        Console.WriteLine($"{x} {y} {z}");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Failed to read data from the sensor.");
                //    }

                //    // Sleep for a short while before reading again
                //    System.Threading.Thread.Sleep(500);
                //}
            }
            finally
            {
                // Close the I2C bus
                I2c.I2cClose(handle);
            }
        }
        else
        {
            Console.WriteLine("Failed to open I2C device.");
        }

        // Terminate PiGpio
        Setup.GpioTerminate();
    }
}