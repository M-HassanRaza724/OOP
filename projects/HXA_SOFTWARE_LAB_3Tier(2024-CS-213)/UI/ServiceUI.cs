using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;

namespace HXA_SOFTWARE_LAB.UI
{
    public static class ServiceUI
    {
        public static int ManageServicesMenu()
        {
            int choice = 0;
            Console.WriteLine("\t    MANAGE SERVICES");
            Console.WriteLine("\t1. Display services.");
            Console.WriteLine("\t2. Add services.");
            Console.WriteLine("\t3. Delete services.");
            Console.WriteLine("\t4. Main Menu");
            Console.Write("\tEnter your choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void DisplayService(Service s)
        {
            Console.WriteLine($"Type: {s.Type}");
            Console.WriteLine($"\tDescription: {s.Description}");
            Console.WriteLine($"\tTechnologies: {s.Technologies}");
            Console.WriteLine($"\tServices: {s.Services}");
        }
        public static void DisplayServices(List<Service> services)
        {
            foreach (var s in services)
            {
                DisplayService(s);
            }
        }
        public static Service TakeInput()
        {
            string[] ser = new string[4];
            Console.Write("Enter Service Type: ");
            ser[0] = Console.ReadLine();
            Console.Write("\tEnter Service Description: ");
            ser[1] = Console.ReadLine();
            Console.Write("\tEnter Service Technologies: ");
            ser[2] = Console.ReadLine();
            Console.Write("\tEnter Service services: ");
            ser[3] = Console.ReadLine();

            return new Service(ser[0], ser[1], ser[2], ser[3]);
        }
    }
}
