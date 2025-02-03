using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace trafficShooter
{
    public class Enemy
    {   
        public string[] Vehicle;
        public int X;
        public int Y;
        public Enemy(int x, int y, string[] vehicle)
        {
            X = x;
            Y = y;
            Vehicle = vehicle;
        }
        public void PrintEnemy()
        {
            for (int i = 0; i < Vehicle.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(Vehicle[i]);
            }
        }
        public void MoveRight(char[,] console)
        {
            if (console[Y - 1,X + 18] == ' ' && console[Y - 1,X + 17] == ' ')
                X++;
        }
        public void MoveLeft(char[,] console)
        {
            if (console[Y + 8, X - 2] == ' ' && console[Y + 3, X - 2] == ' ')
                X--;
        }
        public void MoveDown(char[,] console)
        {
            if (console[Y + 10, X + 4] == ' ')
                Y++;
        }
        public void MoveUp()
        {
            Y--;
        }
        public void EraseEnemy()
        {
            for (int i = 0; i < Vehicle.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("             ");
            }
        }

    }
}
