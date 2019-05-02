using AOC2019.Eleven;
using AOC2019.Ten;
using AOC2019.Twelve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DayTwelve();

            System.Console.ReadLine();
        }

        private static void DayTen()
        {
            var dayTen = new DayTen();

            dayTen.RunDayTen(@"Files\DayTen.txt");
        }

        private static void DayEleven()
        {
            var dayEleven = new DayEleven();

            System.Console.WriteLine(dayEleven.PartOne(8141));
        }

        private static void DayTwelve()
        {
            var dayTwelve = new DayTwelve();

            System.Console.WriteLine(dayTwelve.Run(@"Files\DayTwelve.txt"));
        }
    }
}
