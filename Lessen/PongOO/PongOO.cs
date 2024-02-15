using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PongOO
{
    internal class PongOO
    {
       
        int balX = 20;
        int balY = 20;
        int VectorX = 2;
        int VectorY = 1;

        public void PongMove()
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
        }
        public void PongPrint()
        {
            Console.SetCursorPosition(balX, balY);
            Console.Write("O");
        }

    }
}
