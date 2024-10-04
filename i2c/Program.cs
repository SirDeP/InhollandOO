using System;
using System.Threading;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;

class HMC5883L
{
    const byte HMC5883L_ADDRESS = 0x1E;
    const byte HMC5883L_CONFIG_REG_A = 0x00;
    const byte HMC5883L_MODE_REG = 0x02;
    const byte HMC5883L_DATA_REG = 0x03;

    private UIntPtr _deviceHandle;

    public HMC5883L()
    {
        // Initialize the PiGpio library
        Setup.GpioInitialise();

        // Open the I2C device
        _deviceHandle = I2c.I2cOpen((uint)I2cBusId.Bus1, HMC5883L_ADDRESS);
        InitializeSensor();
    }

    private void InitializeSensor()
    {
        // 0x70: 8 samples averaged per measurement output, 15 Hz, normal measurement configuration
        I2c.I2cWriteByteData(_deviceHandle, HMC5883L_CONFIG_REG_A, 0x70);
        // 0x00: Continuous measurement mode
        I2c.I2cWriteByteData(_deviceHandle, HMC5883L_MODE_REG, 0x00);
    }

    private (int X, int Y, int Z) ReadSensor()
    {
        var buffer = new byte[6];
        buffer = I2c.I2cReadI2cBlockData(_deviceHandle, HMC5883L_DATA_REG, buffer.Length);

        int x = (buffer[0] << 8) | buffer[1];
        int z = (buffer[2] << 8) | buffer[3];
        int y = (buffer[4] << 8) | buffer[5];

        if (x > 32767) x -= 65536;
        if (y > 32767) y -= 65536;
        if (z > 32767) z -= 65536;

        return (x, y, z);
    }

    private double CalculateHeading(int x, int y)
    {
        double headingRadians = Math.Atan2(y, x);
        double headingDegrees = headingRadians * (180.0 / Math.PI);

        if (headingDegrees < 0)
            headingDegrees += 360;

        return headingDegrees;
    }

    public void CalibrateSensor(out int xOffset, out int yOffset, out int zOffset)
    {
        int xMin = int.MaxValue, yMin = int.MaxValue, zMin = int.MaxValue;
        int xMax = int.MinValue, yMax = int.MinValue, zMax = int.MinValue;

        Console.WriteLine("Rotate the sensor in all directions for calibration...");

        for (int i = 0; i < 500; i++)
        {
            var (x, y, z) = ReadSensor();

            if (x < xMin) xMin = x;
            if (y < yMin) yMin = y;
            if (z < zMin) zMin = z;
            if (x > xMax) xMax = x;
            if (y > yMax) yMax = y;
            if (z > zMax) zMax = z;

            Thread.Sleep(100);
        }

        xOffset = (xMax + xMin) / 2;
        yOffset = (yMax + yMin) / 2;
        zOffset = (zMax + zMin) / 2;
    }

    private (int X, int Y, int Z) ReadCalibratedSensor(int xOffset, int yOffset, int zOffset)
    {
        var (x, y, z) = ReadSensor();
        x -= xOffset;
        y -= yOffset;
        z -= zOffset;
        return (x, y, z);
    }

    public void Run()
    {
        CalibrateSensor(out int xOffset, out int yOffset, out int zOffset);

        while (true)
        {
            var (x, y, z) = ReadCalibratedSensor(xOffset, yOffset, zOffset);
            double heading = CalculateHeading(x, y);
            Console.WriteLine($"Heading: {heading:F2} degrees");
            Thread.Sleep(1000);
        }
    }

    ~HMC5883L()
    {
        // Close the I2C device
        I2c.I2cClose(_deviceHandle);
    }
}

class Program
{
    static void Main()
    {
        var compass = new HMC5883L();
        compass.Run();
    }
}
