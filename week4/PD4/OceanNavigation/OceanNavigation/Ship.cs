using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation
{
    class Ship
    {
        public string SerialNumber;
        public Angle Latitude;
        public Angle Longitude;

        public Ship(string serialNumber, Angle latitude, Angle longitude)
        {
            SerialNumber = serialNumber;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void DisplayPosition()
        {
            Console.Write("Ship is at ");
            Latitude.DisplayAngle();
            Console.Write(" and ");
            Longitude.DisplayAngle();
        }

        public void DisplaySerialNumber()
        {
            Console.WriteLine($"Ship's serial number is {SerialNumber}");
        }

        public void ChangePosition(Angle latitude, Angle longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
