using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;

namespace HXA_SOFTWARE_LAB.UI
{
    public static class CustomerUI
    {
        public static int CustomerMenu(MUser user)
        {
            Console.WriteLine($"\tHello {user.Username}");
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine("\t1. Our Services.");
            Console.WriteLine("\t2. Place Order.");
            Console.WriteLine("\t3. Order Book.");
            //Console.WriteLine("\t4. Our Recent Top Projects.");
            Console.WriteLine("\t4. SignOut.");
            Console.Write("\tEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
