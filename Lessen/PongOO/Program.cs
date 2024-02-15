namespace PongOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            PongOO pong = new PongOO();
            while (true) 
            {
                pong.PongMove();
                pong.PongPrint();
                System.Threading.Thread.Sleep(50); //50 ms wachten
                //Console.Clear();
            }

        }
    }
}
