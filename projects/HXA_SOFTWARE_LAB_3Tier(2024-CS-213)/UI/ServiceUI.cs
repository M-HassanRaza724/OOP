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
        public static void DisplayServiceType(Service s)
        {
            Console.WriteLine($"Type: {s.Type}");
        }
        public static void DisplayServiceTypes(List<Service> services)
        {
            foreach (var s in services)
            {
                DisplayServiceType(s);
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
        public static string InputServicesType(List<string> services)
        {
            foreach (var s in services)
            {
                Console.WriteLine($"\t{services.IndexOf(s) + 1}. {s}");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice >= 0 && choice < services.Count)
            {
                return services[choice];
            }
            //else if (choice == services.Count) 
            //{
            //    return "auto";
            //}

            return string.Empty;
        }

        public static void DisplayOurServicesHeader()
        {
            Console.WriteLine("                                    ---OUR SERVICES---");
            Console.WriteLine("                                   ");
            Console.WriteLine("Welcome to HXA Software Lab, where we bring your digital ideas to life! We offer a range of");
            Console.WriteLine("professional services tailored to meet the unique needs of each client. Our team is committed to");
            Console.WriteLine("delivering innovative solutions with a focus on quality, efficiency, and support.");
            Console.WriteLine();
        }

        public static void DisplayOurServicesFooter()
        {
            Console.WriteLine();
            Console.WriteLine("At HXA Software Lab, we are committed to helping you achieve your goals with solutions that are");
            Console.WriteLine("tailored to your business needs. Whether you're looking to build a new product, optimize existing");
            Console.WriteLine("processes, or improve your digital footprint, we're here to support you every step of the way.");
        }
    }
}
