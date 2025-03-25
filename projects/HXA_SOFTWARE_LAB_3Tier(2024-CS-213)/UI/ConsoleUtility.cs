namespace HXA_SOFTWARE_LAB.UI
{
    public static class ConsoleUtility
    {
        public static void PrintHeader()
        {
            Console.WriteLine("\t\t __________________________________________________________________________________________________ ");
            Console.WriteLine("\t\t|                                 __________                                                       |");
            Console.WriteLine("\t\t|                                |          |                                                      |");
            Console.WriteLine("\t\t|                                |__________|   HXA  SOFTWARE  LAB                                 |");
            Console.WriteLine("\t\t|                               /____________\\                                                     |");
            Console.WriteLine("\t\t|__________________________________________________________________________________________________|\n\n");
        }
        public static void EntryMenu()
        {
            Console.WriteLine("\tWelcome to HXA Software LAB");
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine("\t1. Log In.");
            Console.WriteLine("\t2. Sign Up.");
            Console.WriteLine("\t3. Exit.");
            Console.Write("\tEnter your choice: ");
        }
        public static void PrintMessage(string message = null)
        {
            Console.WriteLine(message);
        }
        public static string inputString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        public static int inputInt(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());
        }
        public static string inputDouble(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        public static int inputChoice(params string[] choices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = $"\t{i + 1}. {choices[i]}";
            }
            Console.Write($"Enter ({string.Join(", ", choices)}): ");
            return int.Parse(Console.ReadLine());
        }
        public static void PrintSentence(string sentence, int lineLength)
        {
            string[] words = sentence.Split(' ');
            int currentLineLength = 0;

            foreach (string word in words)
            {
                if (currentLineLength + word.Length > lineLength)
                {
                    Console.Write("\n\t");
                    currentLineLength = 0;
                }

                Console.Write(word + " ");
                currentLineLength += word.Length + 1;
            }
        }
        public static void ShowIntro()
        {
            Console.WriteLine("                                                   ###   ##   ##   ##   #####                                               ");
            Thread.Sleep(40);
            Console.WriteLine("                                                    ##   ##   ##   ##  ##   ##                                              ");
            Thread.Sleep(40);
            Console.WriteLine("                                                    ##   ##    ## ##   ##   ##                                              ");
            Thread.Sleep(40);
            Console.WriteLine("                                                    #######     ###    #######                                              ");
            Thread.Sleep(40);
            Console.WriteLine("         _____________________________              ##   ##    ## ##   ##   ##                                              ");
            Thread.Sleep(40);
            Console.WriteLine("        /                             \\             ##   ##   ##   ##  ##   ##                                              ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |            ##   ###  ##   ##  ##   ##                                              ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |                                                                                    ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |                                                                                    ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |            #####     #####   #######  ######  ##    ##    #####   ######    #######");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |           ##   ##   ##   ##   ##  ##    ##    ##    ##   ##   ##   ##  ##    ##  ##");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |           ##        ##   ##   ##        ##    ##    ##   ##   ##   ##  ##    ##    ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |            #####    ##   ##   ####      ##    ## ## ##   #######   #####     ####  ");
            Thread.Sleep(40);
            Console.WriteLine("       |                               |                ##   ##   ##   ##        ##    ########   ##   ##   ###       ##    ");
            Thread.Sleep(40);
            Console.WriteLine("       |_______________________________|           ##   ##   ##   ##   ##        ##    ###  ###   ##   ##   ## ##     ##  ##");
            Thread.Sleep(40);
            Console.WriteLine("       /                               \\            #####     #####   ####       ##    ##    ##   ##   ##   ##  ###  #######");
            Thread.Sleep(40);
            Console.WriteLine("      /                                 \\                                                                                   ");
            Thread.Sleep(40);
            Console.WriteLine("     /                                   \\                                                                                  ");
            Thread.Sleep(40);
            Console.WriteLine("    /                                     \\        ##        #####   ######                                                 ");
            Thread.Sleep(40);
            Console.WriteLine("   /                                       \\       ##       ##   ##   ##  ##                                                ");
            Thread.Sleep(40);
            Console.WriteLine("   \\_______________________________________/       ##       ##   ##   ##  ##                                                ");
            Thread.Sleep(40);
            Console.WriteLine("                                                   ##       #######   #####                                                 ");
            Thread.Sleep(40);
            Console.WriteLine("                                                   ##       ##   ##   ##  ##                                                ");
            Thread.Sleep(40);
            Console.WriteLine("                                                   ##       ##   ##   ##  ##                                                ");
            Thread.Sleep(40);
            Console.WriteLine("                                                   #######  ##   ##  ######                                                 ");
            Thread.Sleep(1000);
        }
    }
}
