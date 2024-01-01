
using System;
using System.ComponentModel;
using AdventOfCode2023.Library;

namespace AdventOfCode2023.Console
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var day = args[0];
            var filePath = args[1];
            var fileExits = System.IO.File.Exists(filePath);
            if (fileExits == false)
            {
                System.Console.WriteLine("Please provide a valid input file.");
                return;
            }

            switch (day)
            {
                case "1":
                    DayOne(filePath);
                    break;
                case "2":
                    DayTwo(filePath);
                    break;
                case "3":
                    DayThree(filePath);
                    break;
                default:
                    System.Console.WriteLine("Please provide a valid day.");
                    break;
            }

        }

        private static void DayOne(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var calibrationSum = 0;
            foreach (string line in lines)
            {
                var calibrationValue = Library.DayOneProcessor.GetCalibrationValue(line);
                calibrationSum += calibrationValue;
            }
            System.Console.WriteLine($"Calibration Sum = {calibrationSum}");
        }

        private static void DayTwo(string filePath)
        {
            //part 1    
            var validGameSum = DayTwoProcessor.GetValidGameIDSum(filePath);
            System.Console.WriteLine($"Valid Game Sum = {validGameSum}");
            //part 2
            var validGamePowerSum = DayTwoProcessor.GetSumOfGamePowers(filePath);
            System.Console.WriteLine($"Game Power Sum = {validGamePowerSum}");
        }

        private static void DayThree(string filePath)
        {
            var schematic = Schematic.DeserializeGrid(filePath) ?? new Schematic();
            System.Console.WriteLine($"Game Grid = {schematic.Grid?.Length}");
            //part 1    
            //sum of all of the part numbers in the engine schematic?
            var partNumberSum = schematic.GetPartNumberSum();
            System.Console.WriteLine($"Part Number Sum = {partNumberSum}");
            //part 2    
            //sum of all of the symbols gear rations in the engine schematic
            var gearRatioSum = schematic.GetGearRationSum();
            System.Console.WriteLine($"Gear Ratio Sum = {gearRatioSum}");
        }
    }

}