using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Eleven
{
    public class DayEleven
    {
        private const int gridWidth = 300;

        public string PartOne(int serialNumber)
        {
            var grid = BuildGrid(serialNumber);
                        
            return MaximumAreaRoot(grid, gridWidth);
        }

        public int[][] BuildGrid(int serialNumber)
        {
            var grid = new int[gridWidth][];
            
            for (int x = 0; x < gridWidth; x++)
            {
                grid[x] = new int[gridWidth];

                for (int y = 0; y < gridWidth; y++)
                {
                    grid[x][y] = CalculateEnergyLevel(x, y, serialNumber);
                }
            }

            return grid;
        }

        private string MaximumAreaRoot(int[][]grid, int gridWidth)
        {
            string maximum = string.Empty;
            int maximumValue = 0;

            for (int w = 1; w <= gridWidth; w++)
            {
                for (int x = 0; x < gridWidth - w; x++)
                {
                    for (int y = 0; y < gridWidth - w; y++)
                    {
                        var areaValue = AreaValue(x, y, grid, w);

                        if (areaValue > maximumValue)
                        {
                            maximumValue = areaValue;
                            maximum = BuildOutputString(x, y, w);
                        }
                    }
                }
            }

            return maximum;
        }

        private string BuildOutputString(int x, int y, int w)
        {
            return $"{x},{y},{w}"; 
        }

        private int AreaValue(int xRoot, int yRoot, int[][] grid, int areaWidth)
        {
            var value = 0;

            for (int x = xRoot; x < xRoot + areaWidth; x++)
            {
                for(int y = yRoot; y < yRoot + areaWidth; y++)
                {
                    value += grid[x][y];
                }
            }

            return value;
        }

//        Find the fuel cell's rack ID, which is its X coordinate plus 10.
//Begin with a power level of the rack ID times the Y coordinate.
//Increase the power level by the value of the grid serial number(your puzzle input).
//Set the power level to itself multiplied by the rack ID.
//Keep only the hundreds digit of the power level(so 12345 becomes 3; numbers with no hundreds digit become 0).
//Subtract 5 from the power level.

        public int CalculateEnergyLevel(int x, int y, int serialNumber)
        {
            var rackId = x + 10;
            var powerLevel = rackId * y;
            powerLevel += serialNumber;
            powerLevel *= rackId;

            var powerLevelString = powerLevel.ToString();

            if (powerLevelString.Length < 3)
            {
                return 0;
            }

            var hundred = int.Parse(powerLevelString[powerLevelString.Length - 3].ToString());

            return hundred - 5;
        }


    }
}
