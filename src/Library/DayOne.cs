using System;
using System.Net.NetworkInformation;

namespace AdventOfCode2023.Library
{
    public class DayOneProcessor
    {
        
        // create a constant value that is a char array of the integers from 1 to 9
        private static readonly char[] IntegerChars = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

          public static int GetCalibrationValue(string input)
        {
            var firstIntegerIndex = input.IndexOfAny(IntegerChars);
            var lastIntegerIndex = input.LastIndexOfAny(IntegerChars);

            // no numbers found
            if (firstIntegerIndex == -1 || lastIntegerIndex == -1)
            {
                return -1;
            }
            var firstIntegerAsInt = int.Parse(input[firstIntegerIndex].ToString());
            var lastIntegerAsInt = int.Parse(input[lastIntegerIndex].ToString());

            return int.Parse($"{firstIntegerAsInt}{lastIntegerAsInt}");
        }
    }
}


