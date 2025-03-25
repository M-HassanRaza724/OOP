using HXA_SOFTWARE_LAB.BL;

namespace HXA_SOFTWARE_LAB.UI
{
    public class OrderUI
    {
        public static string InputOrderService(ref int y,List<string> services)
        {
            Console.WriteLine("Place Your Order");
            Console.WriteLine("At HXA Software Lab, we make it easy to bring your vision to life! Complete the form below to");
            Console.WriteLine("request our services. Our team will review your details and reach out shortly to discuss your");
            Console.WriteLine("project requirements.");
            Console.WriteLine();
            Console.WriteLine("Order Form");
            Console.WriteLine("1. Select Service Type:");
            Console.WriteLine();
            Console.WriteLine("Please select the primary service you are interested in:");

            Console.SetCursorPosition(0, y);

            return ServiceUI.InputServicesType(services);
        }
        public static string InputOrderDescription()
        {
            Console.WriteLine("2. Project Description:\n\n");
            Console.WriteLine("\tDescribe your project or specific needs:\n");
            return Console.ReadLine();
        }
        public static string InputOrderPlatform()
        {
            Console.WriteLine("3. Preferred Platform:\n");
            Console.WriteLine("Select the platform(s) for the project (if applicable):");
            Console.WriteLine("\t1. Web");
            Console.WriteLine("\t2. Mobile (Android, iOS)");
            Console.WriteLine("\t3. Desktop");
            Console.WriteLine("\t4. Cross-platform");
            Console.Write("\tEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                return "Web";
            else if (choice == 2)
                return "Mobile";
            else if (choice == 3)
                return "Desktop";
            else if (choice == 4)
                return "Cross-platform";
            else
                return "Invalid";
        }

        public static string InputOrderBudget()
        {
            Console.WriteLine("4. Project Budget:\n");
            Console.WriteLine("Please specify your estimated budget range:");
            Console.WriteLine("\t1. <$5,000");
            Console.WriteLine("\t2. $5,000 - $10,000");
            Console.WriteLine("\t3. $10,000 - $20,000");
            Console.WriteLine("\t4. $20,000 - $50,000");
            Console.WriteLine("\t5. >$50,000");
            Console.Write("\tEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                return "<$5,000";
            else if (choice == 2)
                return "$5,000 - $10,000";
            else if (choice == 3)
                return "$10,000 - $20,000";
            else if (choice == 4)
                return "$20,000 - $50,000";
            else if (choice == 5)
                return ">$50,000";
            else
                return "Invalid";
        }

        public static (DateTime startDate, DateTime endDate) InputOrderTimeline()
        {
            Console.WriteLine("5. Timeline:");
            Console.WriteLine("When would you like to start, and when is the expected completion date?");

            DateTime startDate, endDate;

            Console.Write("\tStart Date (MM/DD/YYYY): ");
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.Write("Invalid date format. Please enter start date (MM/DD/YYYY): ");
            }

            Console.Write("\n\n\tCompletion Date (MM/DD/YYYY): ");
            while (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate <= startDate)
            {
                Console.Write("Invalid date or before start date. Please enter completion date (MM/DD/YYYY): ");
            }

            return (startDate, endDate);
        }

        public static bool InputOrderSubmitProposal()
        {
            Console.WriteLine("                           Submit Your Order");
            Console.WriteLine("You've completed the form, click '1' to send us your project request. Our");
            Console.WriteLine("team will contact you to confirm details, discuss your project scope, and provide");
            Console.WriteLine("a customized proposal.");
            ConsoleUtility.inputChoice("submit", "cancel");

            return Console.ReadLine() == "1";
        }
        public static int ManageOrderMenu()
        {
            Console.WriteLine("================================================================================================");
            Console.WriteLine("                                       ORDER MANAGEMENT");
            Console.WriteLine("================================================================================================\n");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Update Order Status");
            Console.WriteLine("3. Delete an Order");
            Console.WriteLine("4. Search Orders");
            Console.WriteLine("5. Generate Summary Reports");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Enter your choice (1-6): ");

            return int.Parse(Console.ReadLine());

        }
        // In OrderUI.cs
        public static void PrintAllOrders(List<Order> orders)
        {
            Console.Clear();
            Console.WriteLine("===============================================================================================");
            Console.WriteLine("                                 ORDER MANAGEMENT: All Orders");
            Console.WriteLine("===============================================================================================\n");

            Console.WriteLine(" Order ID                 | Customer Email         | Type                      | Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            int row = 6; // Starting row for orders

            foreach (var order in orders.OrderByDescending(o => o.OrderId)) // or any other ordering logic
            {
                Console.SetCursorPosition(0, row);
                Console.Write($" {order.OrderId}".PadRight(25));

                Console.SetCursorPosition(25, row);
                Console.Write($"| {order.GetOrdererEmail()}".PadRight(25));

                Console.SetCursorPosition(50, row);
                Console.Write($"| {order.GetType()}".PadRight(28));

                Console.SetCursorPosition(78, row);
                Console.Write("| ");
                Console.Write(order.GetStatus() == "0" ? "Uncompleted" : "Completed");

                row++;
            }

            Console.WriteLine("\n\n================================================================================================");
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }
        public static void GenerateOrderSummary(List<Order> orders)
        {
            Console.Clear();
            PrintOrderHeader("Summary");

            Console.WriteLine($"Total Orders: {orders.Count}\n");

            int completedOrders = orders.Count(o => o.GetStatus() == "1");
            Console.WriteLine($"Completed Orders: {completedOrders}\n");

            int uncompletedOrders = orders.Count(o => o.GetStatus() == "0");
            Console.WriteLine($"Uncompleted Orders: {uncompletedOrders}\n");

            Console.WriteLine("===============================================================================================\n");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
        }

        public static void DisplayOrder(Order order)
        {
            Console.Clear();
            PrintOrderHeader("Order Details");

            Console.WriteLine($"Type: {order.GetType()}");
            Console.WriteLine($"Id: {order.OrderId}");
            Console.WriteLine($"Description: {order.GetDescription()}");
            Console.WriteLine($"Budget: ${order.GetPBudget()}");
            Console.Write("Status: ");

            if (order.GetStatus() == "1")
            {
                Console.WriteLine("Completed");
                Console.WriteLine($"Revenue: ${order.GetRevenueGenerated()}");
            }
            else
            {
                Console.WriteLine("Uncompleted");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        // In OrderUI.cs
            public static void PrintOrderBook(List<Order> orders)
            {
                Console.Clear();
                Console.WriteLine("                                       ORDER BOOK\n");
                Console.WriteLine("================================================================================================");
                Console.WriteLine("                                    Uncompleted Orders");
                Console.WriteLine("================================================================================================\n");

                bool hasUncompleted = PrintOrders(orders, "0", "In Progress");

                Console.WriteLine("\n================================================================================================");
                Console.WriteLine("                                     Completed Orders");
                Console.WriteLine("================================================================================================\n");

                bool hasCompleted = PrintOrders(orders, "1", "Completed");

                Console.WriteLine("\nPress any Key to go to Main Menu");
                Console.ReadKey();
            }

            private static bool PrintOrders(List<Order> orders, string statusFilter, string statusText)
            {
                bool found = false;
                int orderNumber = 1;

                foreach (var order in orders.Where(o => o.GetStatus() == statusFilter))
                {
                    Console.WriteLine($"Order # {orderNumber}");
                   OrderUI.DisplayOrder(order);

                    orderNumber++;
                    found = true;
                }

                if (!found)
                {
                    Console.WriteLine("No Record\n");
                }

                return found;
        }

        public static void PrintOrderHeader(string subHeading)
        {
            Console.WriteLine("================================================================================================");
            Console.WriteLine($"                                 ORDER MANAGEMENT: {subHeading}");
            Console.WriteLine("================================================================================================\n");
        }
    }

}
