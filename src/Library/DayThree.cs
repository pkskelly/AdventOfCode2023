using System.Numerics;
namespace AdventOfCode2023.Library
{
    public class SchematicPartNumber
    {
        public long Value { get; set; }
        public int Row { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }

    public class SchematicSymbol
    {
        public char Value { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
    }

    public class Schematic {
        public char[,]? Grid { get; set; }
        public List<SchematicPartNumber>? PartNumbers { get; set; }
        public List<SchematicSymbol>? Symbols { get; set; }

        public long GetPartNumberSum()
        {
            if (PartNumbers == null || Symbols == null)
                return 0;

            return PartNumbers
                .Where(partNumber => Symbols.Any(symbol =>
                    (partNumber.Row == symbol.Row || partNumber.Row - 1 == symbol.Row || partNumber.Row + 1 == symbol.Row) &&
                    (partNumber.Start == symbol.Position || partNumber.Start - 1 == symbol.Position || partNumber.Start + 1 == symbol.Position ||
                    partNumber.End == symbol.Position || partNumber.End - 1 == symbol.Position || partNumber.End + 1 == symbol.Position)
                ))
                .Sum(partNumber => partNumber.Value);
        }
    }

    public class DayThreeProcessor
    {        
        public static Schematic DeserializeGrid(string filePath)
        {
            var schematic = new Schematic();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var grid = new char[lines.Length, lines[0].Length];
            for (var row = 0; row < lines.Length; row++)
            {
                for (var column = 0; column < lines[0].Length; column++)
                {
                    grid[row, column] = lines[row][column];
                }
            }
            schematic.Grid = grid; 
            (schematic.PartNumbers, schematic.Symbols) = DayThreeProcessor.GetPartNumbers(schematic);
            return schematic;
        }


        private static Tuple<List<SchematicPartNumber>,List<SchematicSymbol>> GetPartNumbers(Schematic schematic)
        {
            var partNumbers = new List<SchematicPartNumber>();
            var symbols = new List<SchematicSymbol>();
            var grid = schematic.Grid;
            var rowLength = grid?.GetLength(0);
            var columnLength = grid?.GetLength(1);

            for (var row = 0; row < rowLength; row++)
            {
                for (var column = 0; column < columnLength; column++)
                {
                    var currentChar = grid[row, column];
                    if (currentChar.ToString().All(char.IsDigit) )
                    {
                        var partNumber = new SchematicPartNumber();
                        partNumber.Row = row;
                        partNumber.Start = column;
                        do  
                        {
                            partNumber.Value = long.Parse(partNumber.Value.ToString() + currentChar.ToString());
                            partNumber.End = column;
                            column++;
                            if (column < columnLength)
                            {
                                currentChar = grid[row, column];
                            }
                            else {
                                break;
                            }
                        }
                        while (currentChar.ToString().All(char.IsDigit)); 
                        partNumbers.Add(partNumber);
                    }
                    //for our purposes, we don't care about the decimal point
                    if (currentChar.ToString() != "." && !currentChar.ToString().All(char.IsDigit))
                    {
                        var symbol = new SchematicSymbol();
                        symbol.Row = row;
                        symbol.Position = column;
                        symbol.Value = currentChar;
                        symbols.Add(symbol);
                    }
                }  
            }
            return Tuple.Create(partNumbers, symbols);
        }
    }
}