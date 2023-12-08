
using System;
using System.ComponentModel;
using AdventOfCode2023.Library;

namespace AdventOfCode2023.Console 
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var calibrationSum = 0;
            var filePath = args[0];
            var fileExits = System.IO.File.Exists(filePath);
            if ( fileExits == false)
            {
                System.Console.WriteLine("Please provide a valid input file.");
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var calibrationValue = Library.DayOneProcessor.GetCalibrationValue(line);
                calibrationSum += calibrationValue;
            }
           
           System.Console.WriteLine($"Calibration Sum = {calibrationSum}");
        }
    }
}