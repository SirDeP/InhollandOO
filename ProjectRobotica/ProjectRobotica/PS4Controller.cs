using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace ProjectRobotica
{
    internal class PS4Controller
    {
        FileStream ControllerStream;

        int counter = 0;
        bool debug = false;

        public List<byte> deviceBytes = new List<byte>();

        public ControllerState state = new ControllerState();

        public PS4Controller(string devicefile, bool deviceDebug = false)
        {
            try
            {
                ControllerStream = File.Open(devicefile, FileMode.Open);
                debug = deviceDebug;
                
            }
            catch (Exception e)
            {
                //Don't throw the exception, just print it.
                Console.WriteLine("Failed to initialize input device: " + devicefile);
                Console.WriteLine(e.Message);
            }

        }

        public void update()
        {
            //the output buffer
            //bool output = false;

            // The size of the data packet we're expecting
            const int packetSize = 8;

            // Create a buffer to store the incoming data
            byte[] buffer = new byte[packetSize];

            try
            {
                // Read a packet of data from the stream
                int bytesRead = ControllerStream.Read(buffer, 0, packetSize);

                // Check if we read the expected number of bytes
                if (bytesRead == packetSize)
                {
                    // Set output to true since an update has happened
                    //output = true;

                    // Clear existing bytes list.
                    deviceBytes.Clear();

                    // Insert bytes into deviceBytes list (in order)
                    deviceBytes.AddRange(buffer);
                }
            }
            catch (IOException e)
            {
                // Handle any IO exceptions (e.g., end of stream)
                Console.WriteLine("Error reading from stream: " + e.Message);
            }


            //Reset counter
            counter = 0;

            //Grab the event type identifier byte and cast it to xEvents enum
            ControllerEvents eventType = (ControllerEvents)deviceBytes.ToArray()[6]; // Event stream example: 58-50-BD-00-01-80-02-05 -- 02 is event type (Axis)

            //Check for button event
            if (eventType == ControllerEvents.ButtonAction)
            {
                ControllerButtons button = (ControllerButtons)deviceBytes.ToArray()[7];                       // Event stream example: F4-37-BE-00-01-00-01-05 -- 05 is button ID
                ControllerButtonState buttonAction = (ControllerButtonState)deviceBytes.ToArray()[4]; // F4-37-BE-00-01-00-01-05 -- The first 01 is ButtonState
                if (debug) Console.Write(button.ToString());

                if (buttonAction == ControllerButtonState.Pressed)
                {
                    state.buttons[(byte)button] = true;
                    if (debug) Console.WriteLine(" pressed.");
                }
                else if (buttonAction == ControllerButtonState.Released)
                {
                    state.buttons[(byte)button] = false;
                    if (debug) Console.WriteLine(" released.");
                }
            }
            //Check for axis event
            else if (eventType == ControllerEvents.AxisMoved)
            {
                ControllerAxis axis = (ControllerAxis)deviceBytes.ToArray()[7];
                byte[] cbytes = { deviceBytes.ToArray()[4], deviceBytes.ToArray()[5] };
                Int16 value = BitConverter.ToInt16(cbytes, 0);
                state.axis[(byte)axis] = value;
                if (debug) Console.WriteLine(axis.ToString() + " moved to " + value.ToString());
            }
            else
            {
                if (debug) Console.WriteLine("Unknown event occured(this is normal immediately after connection)");
            }
        }

        public void Print()
        {
            state.Print();
        }
    }


}
