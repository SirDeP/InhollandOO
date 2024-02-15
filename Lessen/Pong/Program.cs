namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int balX = 20;
            int balY = 20;
            int VectorX = 2;
            int VectorY = 1;
            while (true)
            {
                //Xvector van richting veranderen aan de randen
                if (balX + VectorX >= Console.WindowWidth || balX + VectorX < 0)
                {
                    VectorX = -VectorX;
                }
                balX = balX + VectorX; //X positie updaten
                                       //Yvector van richting veranderen aan de randen
                if (balY + VectorY >= Console.WindowHeight || balY + VectorY < 0)
                {
                    VectorY = -VectorY;
                }
                balY = balY + VectorY; //Y positie updaten
                                       //Output naar scherm sturen
                Console.SetCursorPosition(balX, balY);
                Console.Write("O");
                System.Threading.Thread.Sleep(50); //50 ms wachten
                Console.Clear();
            }
        }
    }
}
