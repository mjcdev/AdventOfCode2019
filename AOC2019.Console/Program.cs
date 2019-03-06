using AOC2019.Eleven;
using AOC2019.Ten;
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
            DayEleven();

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
    }
}
