using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;

namespace HXA_SOFTWARE_LAB.UI
{
    public static class MUserUI
    {
        public static void LoginPage()
        {
            Console.WriteLine("\t\t\t/------------------------------------------------\\");
            Console.WriteLine("\t\t\t|                     LOGIN                      |");
            Console.WriteLine("\t\t\t|------------------------------------------------|");
            Console.WriteLine("\t\t\t|   EMAIL:                                       |");
            Console.WriteLine("\t\t\t|                                                |");
            Console.WriteLine("\t\t\t|------------------------------------------------|");
            Console.WriteLine("\t\t\t|   PASSWORD:                                    |");
            Console.WriteLine("\t\t\t|                                                |");
            Console.WriteLine("\t\t\t\\------------------------------------------------/");
        }
        public static void SignUpPage()
        {
            Console.WriteLine("\t\t\t/------------------------------------------------\\");
            Console.WriteLine("\t\t\t|                    SIGN UP                     |");
            Console.WriteLine("\t\t\t|------------------------------------------------|");
            Console.WriteLine("\t\t\t|   USERNAME:                                    |");
            Console.WriteLine("\t\t\t|                                                |");
            Console.WriteLine("\t\t\t|------------------------------------------------|");
            Console.WriteLine("\t\t\t|   EMAIL:                                       |");
            Console.WriteLine("\t\t\t|                                                |");
            Console.WriteLine("\t\t\t|------------------------------------------------|");
            Console.WriteLine("\t\t\t|   PASSWORD:                                    |");
            Console.WriteLine("\t\t\t|                                                |");
            Console.WriteLine("\t\t\t\\------------------------------------------------/");
        }
        public static MUser TakeLoginInput() 
        {
            MUserUI.LoginPage();
            Console.SetCursorPosition(28, 12);
            string email = Console.ReadLine();
            Console.SetCursorPosition(28, 15);
            string password = Console.ReadLine();
            return new MUser(null, email, password);
        }
    }
}
