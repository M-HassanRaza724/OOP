using OceanNavigation;

class Program
{
    static void Main(string[] args)
    {
        List<Ship> ships = new List<Ship>();
        int choice;
        do
        {

            choice = Menu();

            switch (choice)
            {
                case 1: // Add Ship
                    Console.Write("Enter Ship Number: ");
                    string serialNumber = Console.ReadLine();

                    Console.WriteLine("Enter Ship Latitude:");
                    Console.Write("Enter Latitude's Degree: ");
                    int latDegrees = int.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Minute: ");
                    float latMinutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Direction (N/S): ");
                    char latDirection = char.Parse(Console.ReadLine().ToUpper());

                    Angle latitude = new Angle(latDegrees, latMinutes, latDirection);

                    Console.WriteLine("Enter Ship Longitude:");
                    Console.Write("Enter Longitude's Degree: ");
                    int lonDegrees = int.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Minute: ");
                    float lonMinutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Direction (E/W): ");
                    char lonDirection = char.Parse(Console.ReadLine().ToUpper());

                    Angle longitude = new Angle(lonDegrees, lonMinutes, lonDirection);

                    Ship ship = new Ship(serialNumber, latitude, longitude);
                    ships.Add(ship);
                    Console.WriteLine("Ship added successfully!");
                    break;

                case 2: // View Ship Position
                    Console.Write("Enter Ship Serial Number to find its position: ");
                    string searchSerialNumber = Console.ReadLine();
                    Ship foundShip = ships.Find(s => s.SerialNumber == searchSerialNumber);
                    if (foundShip != null)
                    {
                        foundShip.DisplayPosition();
                    }
                    else
                    {
                        Console.WriteLine("Ship not found!");
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter the ship latitude (e.g., 149°34.8’ W):");
                    string latInput = Console.ReadLine();
                    Console.WriteLine("Enter the ship longitude (e.g., 17°31.5’ S):");
                    string lonInput = Console.ReadLine();

                    bool shipFound = false;

                    foreach (Ship s in ships)
                    {
                        string shipLatitude = $"{s.Latitude.Degrees}\u00b0{s.Latitude.Minutes}' {s.Latitude.Direction}";
                        string shipLongitude = $"{s.Longitude.Degrees}\u00b0{s.Longitude.Minutes}' {s.Longitude.Direction}";

                        if (shipLatitude == latInput && shipLongitude == lonInput)
                        {
                            s.DisplaySerialNumber();
                            break;
                        }
                    }
                    Console.WriteLine("Ship not found!");
                    break;

                case 4:
                    Console.Write("Enter Ship's serial number whose position you want to change: ");
                    string changeSerialNumber = Console.ReadLine();

                    bool Found = false;

                    foreach (Ship s in ships)
                    {
                        if (s.SerialNumber == changeSerialNumber)
                        {
                            Console.WriteLine("Enter new Ship Latitude:");
                            Console.Write("Enter Latitude's Degree: ");
                            int newLatDegrees = int.Parse(Console.ReadLine());
                            Console.Write("Enter Latitude's Minute: ");
                            float newLatMinutes = float.Parse(Console.ReadLine());
                            Console.Write("Enter Latitude's Direction (N/S): ");
                            char newLatDirection = char.Parse(Console.ReadLine().ToUpper());

                            Angle newLatitude = new Angle(newLatDegrees, newLatMinutes, newLatDirection);

                            Console.WriteLine("Enter new Ship Longitude:");
                            Console.Write("Enter Longitude's Degree: ");
                            int newLonDegrees = int.Parse(Console.ReadLine());
                            Console.Write("Enter Longitude's Minute: ");
                            float newLonMinutes = float.Parse(Console.ReadLine());
                            Console.Write("Enter Longitude's Direction (E/W): ");
                            char newLonDirection = char.Parse(Console.ReadLine().ToUpper());

                            Angle newLongitude = new Angle(newLonDegrees, newLonMinutes, newLonDirection);

                            s.ChangePosition(newLatitude, newLongitude);
                            Console.WriteLine("Ship position updated successfully!");
                            shipFound = true;
                            break;
                        }
                    }

                    if (!Found)
                    {
                        Console.WriteLine("Ship not found!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        } while (choice != 5);
        Console.WriteLine("Exiting the program...");
    }
        static int Menu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }
}