using HXA_SOFTWARE_LAB.BL;
using HXA_SOFTWARE_LAB.UI;
using HXA_SOFTWARE_LAB.DL;

namespace HXA_SOFTWARE_LAB
{
    class Program
    {
        static void Main(string[] args)
        {

            //int total_buyers = 0, total_admins = 0, userType = -1,userIndex = -1;
            string Role = null;
            int Choice = -1;
            bool exit = false;
            MUser user = new MUser();
            string[] credentials = new string[3];
            while (!exit)
            {
                Console.Clear();
                ConsoleUtility.PrintHeader();
                if (Role == null)
                {
                    if (Choice == -1)
                    {
                        ConsoleUtility.EntryMenu();
                        Choice = int.Parse(Console.ReadLine());
                    }
                    else if (Choice == 1)
                    {
                        MUserUI.TakeLoginInput();
                        if (MUserCRUD.AuthenticateUser(user))
                        {
                            Role = user.UserRole;
                        }
                        else
                        {
                            ConsoleUtility.PrintMessage("\tInvalid credentials");
                            Choice = -1;
                        }

                    }
                    else if (Choice == 2)
                    {
                        MUserUI.SignUpPage();
                        Console.SetCursorPosition(28, 12);
                        credentials[0] = Console.ReadLine();
                        Console.SetCursorPosition(28, 15);
                        credentials[1] = Console.ReadLine();
                        if (!Validation.EmailValidation(credentials[1]))
                        {
                            Console.SetCursorPosition(0, 22);
                            ConsoleUtility.PrintMessage("\tinvalid email...!");
                        }
                        else
                        {
                            Console.SetCursorPosition(28, 18);
                            credentials[2] = Console.ReadLine();
                            if (!Validation.PasswordValidation(credentials[2]))
                            {
                                Console.SetCursorPosition(0, 22);
                                ConsoleUtility.PrintMessage("\tA password must have 8 to 16 characters with letters, numbers and special characters...!");
                            }
                            else
                            {
                                user = new MUser(credentials[0], credentials[1], credentials[2]);
                                MUserCRUD.SearchUser(user);
                                if (MUserCRUD.SearchUser(user))
                                {
                                    ConsoleUtility.PrintMessage("\tEmail already exists....");
                                }
                                else
                                {
                                    MUserCRUD.AddUser(user);
                                }
                            }
                        }
                        //RegisterCredentials(credentials, 2, ref total_buyers, adminCredentials, customerCredentials);
                        Choice = -1;
                    }
                    if (Choice == 3)
                    {
                        Choice = -1;
                        exit = true;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Role == "admin")
                {
                    ConsoleUtility.PrintMessage("\tAdmin console");
                    int aChoice = AdminUI.MainAdminMenu(user.Username);
                    while (Role == "admin")
                    {

                        switch (aChoice)
                        {
                            case 1:
                                ConsoleUtility.PrintMessage("\tDashboard");
                                break;
                            case 2:
                                ConsoleUtility.PrintMessage("\tOrders");
                                break;
                            case 3:
                                Service service;
                                string[] ser = new string[4];
                                int servicesChoice = ServiceUI.ManageServicesMenu();
                                while (servicesChoice != 4)
                                {
                                    switch (servicesChoice)
                                    {
                                        case 1:
                                            service = new Service(null, null, null);
                                            ServiceUI.DisplayServices(ServiceCRUD.GetServices());
                                            break;
                                        case 2:
                                            ServiceCRUD.AddService(ServiceUI.TakeInput());
                                            break;
                                        case 3:
                                            ser[0] = ConsoleUtility.inputString("\tEnter Service Type: ");
                                            if (ServiceCRUD.GetService(ser[0]) != null)
                                            {
                                                int choice = ConsoleUtility.inputChoice("Delete","back");
                                                switch (choice)
                                                {
                                                    case 1:
                                                        ServiceCRUD.DeleteService(ser[0]);
                                                        break;
                                                    case 2:
                                                        break;
                                                    default:
                                                        ConsoleUtility.PrintMessage("\tInvalid choice...!");
                                                        break;
                                                }
                                                choice = -1;
                                            }
                                            else
                                                ConsoleUtility.PrintMessage("\tService not found...!");
                                            break;
                                        default:
                                            ConsoleUtility.PrintMessage("\tInvalid choice...!");
                                            break;
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    servicesChoice = ServiceUI.ManageServicesMenu();
                                }
                                break;
                            case 4:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 5:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 6:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 7:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 8:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 9:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 10:
                                ConsoleUtility.PrintMessage();
                                break;
                            case 11:
                                Role = null;
                                break;
                            default:
                                ConsoleUtility.PrintMessage("\tInvalid choice...!");
                                break;
                        }
                        Console.Clear();
                        if (aChoice != 11)
                            aChoice = AdminUI.MainAdminMenu(user.Username);
                    }
                }
                else if (Role == "customer")
                {
                    int cChoice = CustomerUI.CustomerMenu(user);
                    Console.Clear();
                    while (Role.ToLower() == "customer")
                    {
                        switch (cChoice)
                        {
                            case 1:
                                ServiceUI.DisplayServices(ServiceCRUD.GetServices());
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                Role = null;
                                break;
                            default:
                                ConsoleUtility.PrintMessage("Invalid choice...!");
                                break;
                        }
                        Console.ReadKey();
                        Console.Clear();
                        if (cChoice != 6) cChoice = CustomerUI.CustomerMenu(user);
                    }
                }
            }
        }
    }
}