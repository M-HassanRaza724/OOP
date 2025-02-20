namespace trafficShooter
{
    public class Player
    {
        public string[] Vehicle;
        public int X;
        public int Y;
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Vehicle = new string[]
            {
                $"   _{(char)200}___{(char)200}_   ",
                "  /_______\\  ",
                " /         \\ ",
                "[|  \\   /  |]",
                " |   \\_/   | ",
                $"{(char)220}|  | | |  | ",
                " |  | | |  | ",
                "[|___/_\\___|]",
                " |_________| ",
            };
        }
        public Player(int x, int y, string[] vehicle)
        {
            X = x;
            Y = y;
            Vehicle = vehicle;
        }
        public void PrintPlayer()
        {
            for (int i = 0; i < Vehicle.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(Vehicle[i]);
            }
        }
        public void ErasePlayer()
        {
            for (int i = 0; i < Vehicle.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("             ");
            }
        }
        public void moveCarLeft(char[,] console)
        {
            if ((console[Y, X - 1] == ' ' && console[Y + 8, X - 1] == ' ' && console[Y + 4, X - 1] == ' ') || console[Y, X - 1] == (char)219 || console[Y + 4, X - 1] == (char)219 || console[Y + 8, X - 1] == (char)219)
            {
                Program.Updater(console, this, "erase");
                ErasePlayer();
                X = X - 1;
                if ((X == 23 || X == 46))
                    X--;
                Program.Updater(console, this, "print");
                PrintPlayer();
            }
        }
        public void moveCarRight(char[,] console)
        {
            if ((console[Y, X + 14] == ' ' && console[Y + 4, X + 14] == ' ' && console[Y + 8, X + 14] == ' ') || console[Y, X + 14] == (char)219 || console[Y + 4, X + 14] == (char)219 || console[Y + 8, X + 14] == (char)219)
            {
                ErasePlayer();
                Program.Updater(console,this, "erase");
                X = X + 1;
                if ((X == 23 || X == 46))
                    X++;
                Program.Updater(console, this, "print");
                PrintPlayer();
            }
        }
        public void moveCarUp(int i, char[,] console)
        {
            if ((Y >= 25) && (i % 2 == 0))
            {
                Program.Updater(console, this, "erase");
                ErasePlayer();
                Y = Y - 1;
                Program.Updater(console, this, "print");
                PrintPlayer();
            }       
        }
        public void moveCarDown(int i, char[,] console)
        {
            if ((Y < 26) && (i % 2 == 0))
            {
                Program.Updater(console, this, "erase");
                ErasePlayer();
                Y = Y + 1;
                Program.Updater(console, this, "print");
                PrintPlayer();
            }
        }
    }
}
