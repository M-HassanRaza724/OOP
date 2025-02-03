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
                PrintHeader();
                if (Role == null)
                {

                    if (Choice == -1)
                    {
                        EntryMenu();
                        Choice = int.Parse(Console.ReadLine());
                    }
                    else if (Choice == 1)
                    {
                        LoginPage();
                        Console.SetCursorPosition(28, 12);
                        credentials[1] = Console.ReadLine();
                        Console.SetCursorPosition(28, 15);
                        credentials[2] = Console.ReadLine();
                        user = new MUser(null, credentials[1], credentials[2]);
                        if (user.AuthenticateUser())
                        {
                            Console.Write("\tLoged in as ");
                            if (user.UserRole == 1)
                            {
                                Console.Write("\tAdmin.");
                                Role = "admin";
                            }
                            else
                            {
                                Console.Write("\tCustomer.");
                                Role = "customer";
                            }
                            Choice = -1;
                            //exit = true;
                            //Console.ReadKey();  

                        }
                        else
                        {
                            Console.WriteLine("\tInvalid credentials");
                            Choice = -1;
                            //Console.ReadKey();
                        }

                    }
                    else if (Choice == 2)
                    {
                        SignUpPage();
                        Console.SetCursorPosition(28, 12);
                        credentials[0] = Console.ReadLine();
                        Console.SetCursorPosition(28, 15);
                        credentials[1] = Console.ReadLine();
                        if (!EmailValidation(credentials[1]))
                        {
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("\tinvalid email...!");
                        }
                        else
                        {
                            Console.SetCursorPosition(28, 18);
                            credentials[2] = Console.ReadLine();
                            if (!PasswordValidation(credentials[2]))
                            {
                                Console.SetCursorPosition(0, 22);
                                Console.WriteLine("\tA password must have 8 to 16 characters with letters, numbers and special characters...!");
                            }
                            else
                            {
                                user = new MUser(credentials[0], credentials[1], credentials[2]);
                                user.SearchUser();
                                if (user.SearchUser())
                                {
                                    Console.WriteLine("\tEmail already exists....");
                                }
                                else
                                {
                                    user.AddUser();
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
                    Console.WriteLine("\tAdmin console");
                    int aChoice = MainAdminMenu(user.Username);
                    while (Role == "admin")
                    {

                        switch (aChoice)
                        {
                            case 1:
                                Console.WriteLine("\tDashboard");
                                break;
                            case 2:
                                Console.WriteLine("\tOrders");
                                break;
                            case 3:
                                Service service;
                                string[] ser = new string[4];
                                int servicesChoice = ManageServicesMenu();
                                while (servicesChoice != 4)
                                {
                                    switch (servicesChoice)
                                    {
                                        case 1:
                                            service = new Service(null, null, null);
                                            service.ShowServices();
                                            break;
                                        case 2:
                                            Console.Write("Enter Service Type: ");
                                            ser[0] = Console.ReadLine();
                                            Console.Write("\tEnter Service Description: ");
                                            ser[1] = Console.ReadLine();
                                            Console.Write("\tEnter Service Technologies: ");
                                            ser[2] = Console.ReadLine();
                                            Console.Write("\tEnter Service services: ");
                                            ser[3] = Console.ReadLine();

                                            service = new Service(ser[0], ser[1], ser[2], ser[3]);
                                            service.AddService();
                                            break;
                                        case 3:
                                            Console.Write("\tEnter Service Type: ");
                                            ser[0] = Console.ReadLine();
                                            service = new Service(ser[0], null, null, null);
                                            if (service.SearchService())
                                            {
                                                Console.Write("\tEnter (1.Delete, 2.Back): ");
                                                int choice = int.Parse(Console.ReadLine());
                                                switch (choice)
                                                {
                                                    case 1:
                                                        service.DeleteService();
                                                        break;
                                                    case 2:
                                                        break;
                                                    default:
                                                        Console.WriteLine("\tInvalid choice...!");
                                                        break;
                                                }
                                                choice = -1;
                                            }
                                            else
                                                Console.WriteLine("\tService not found...!");
                                            break;
                                        default:
                                            Console.WriteLine("\tInvalid choice...!");
                                            break;
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    servicesChoice = ManageServicesMenu();
                                }
                                break;
                            case 4:
                                Console.WriteLine();
                                break;
                            case 5:
                                Console.WriteLine();
                                break;
                            case 6:
                                Console.WriteLine();
                                break;
                            case 7:
                                Console.WriteLine();
                                break;
                            case 8:
                                Console.WriteLine();
                                break;
                            case 9:
                                Console.WriteLine();
                                break;
                            case 10:
                                Console.WriteLine();
                                break;
                            case 11:
                                Role = null;
                                break;
                            default:
                                Console.WriteLine("\tInvalid choice...!");
                                break;
                        }
                        Console.Clear();
                        if (aChoice != 11)
                            aChoice = MainAdminMenu(user.Username);
                    }
                }
                else if (Role == "customer")
                {
                    int cChoice = CustomerMenu(user);
                    Console.Clear();
                    while (Role == "customer")
                    {
                        switch (cChoice)
                        {
                            case 1:
                                Service service = new Service();
                                service.ShowServices();
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
                                Console.WriteLine("Invalid choice...!");
                                break;
                        }
                        Console.ReadKey();
                        Console.Clear();
                        if (cChoice != 6) cChoice = CustomerMenu(user);
                    }
                }
            }
        }
        static bool EmailValidation(string email)
        {
            int rateIdx = -1, dotIdx = -1;
            int emailLen = email.Length;

            for (int i = 0; i < emailLen; i++)
                if (email[i] == ' ') return false;

            if (email == "" || emailLen < 5)
                return false;

            for (int i = 0; i < emailLen; i++)
            {
                if (email[i] == '@')
                {
                    if (rateIdx != -1)
                        return false;
                    rateIdx = i;
                }
                else if (email[i] == '.')
                    dotIdx = i;
                else if (email[i] == ' ')
                    return false;
            }

            if (rateIdx == -1 || dotIdx == -1 || rateIdx == 0 || rateIdx > dotIdx - 2 || dotIdx == emailLen - 1)
                return false;

            return true;
        }

        static bool PasswordValidation(string password)
        {
            bool hasSpecial = false, hasNumber = false, hasLetter = false;
            int passwordLen = password.Length;

            for (int i = 0; i < passwordLen; i++)
                if (password[i] == ' ') return false;

            if ((passwordLen < 8) || (passwordLen > 16) || (password == ""))
                return false;

            for (int i = 0; i < passwordLen; i++)
            {
                char a = password[i];

                if ((a > 64 && a < 91) || (a > 96 && a < 123))
                    hasLetter = true;

                if (a > 47 && a < 58)
                    hasNumber = true;

                else if ((a >= 33 && a <= 47) || (a >= 58 && a <= 64) || (a >= 91 && a <= 96) || (a >= 123 && a <= 126))
                    hasSpecial = true;
            }

            return hasSpecial && hasNumber && hasLetter;
        }
        static int ManageServicesMenu()
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
        static void EntryMenu()
        {
            Console.WriteLine("\tWelcome to HXA Software LAB");
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine("\t1. Log In.");
            Console.WriteLine("\t2. Sign Up.");
            Console.WriteLine("\t3. Exit.");
            Console.Write("\tEnter your choice: ");
        }
        static int MainAdminMenu(string username)
        {
            Console.WriteLine($"\tHello {username}");
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine("\t1. Admin Dashboard");
            Console.WriteLine("\t2. Order Management");
            Console.WriteLine("\t3. Manage Services");
            Console.WriteLine("\t4. Manage Sales Analytics");
            Console.WriteLine("\t5. Add Recent Top Projects");
            Console.WriteLine("\t6. Client Reviews.");
            Console.WriteLine("\t7. Add New Admin Profile.");
            Console.WriteLine("\t8. Delete Admin Profile.");
            Console.WriteLine("\t9. Add New Customer Profile.");
            Console.WriteLine("\t10. Delete Customer Profile.");
            Console.WriteLine("\t11. SignOut.");
            Console.Write("\tEnter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static int CustomerMenu(MUser user)
        {
            Console.WriteLine($"\tHello {user.Username}");
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine("\t1. Our Services.");
            Console.WriteLine("\t2. Place Order.");
            Console.WriteLine("\t3. Order Book.");
            Console.WriteLine("\t4. Our Recent Top Projects.");
            Console.WriteLine("\t5. Client Reviews.");
            Console.WriteLine("\t6. SignOut.");
            Console.Write("\tEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static void LoginPage()
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
        static void SignUpPage()
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
        static void PrintHeader()
        {
            Console.WriteLine("\t\t __________________________________________________________________________________________________ ");
            Console.WriteLine("\t\t|                                 __________                                                       |");
            Console.WriteLine("\t\t|                                |          |                                                      |");
            Console.WriteLine("\t\t|                                |__________|   HXA  SOFTWARE  LAB                                 |");
            Console.WriteLine("\t\t|                               /____________\\                                                     |");
            Console.WriteLine("\t\t|__________________________________________________________________________________________________|\n\n");
        }

    }
}