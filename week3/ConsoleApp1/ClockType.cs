using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ClockType
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public ClockType()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }
        public ClockType(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        public ClockType(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
        public ClockType(int hour)
        {
            Hour = hour;
        }
        public void ShowTime()
        {
            Console.WriteLine($"{Hour} {Minute} {Second}");
        }
        public void IncrementSec()
        {
            Second++;
        }
        public void IncrementMin()
        {
            Minute++;
        }
        public void IncrementHour()
        {
            Hour++;
        }
        public bool IsEqual(int h,int min,int sec)
        {
            if (Hour == h && Minute == min && sec == Second)
            {
                return true;
            }
            return false;
        }
        public bool IsEqual(ClockType temp)
        {
            if (Hour == temp.Hour && Minute == temp.Minute && temp.Second == Second)
            {
                return true;
            }
            return false;
        }
        public int ElapsedTime()
        {
            return ((Hour*3600)+(Minute*60)+Second);
        }
        public int RemainingTime()
        {
            return (86400) -((Hour * 3600) + (Minute * 60) + Second);

        }
    }
}
