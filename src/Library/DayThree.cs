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

        private  List<SchematicPartNumber> _partNumbers = new List<SchematicPartNumber>();
        private  List<SchematicSymbol> _symbols = new List<SchematicSymbol>();

        public Schematic()
        {
        }

        public char[,]? Grid { get; set; }

        public List<SchematicPartNumber>? PartNumbers
        {
            get
            {
                return _partNumbers;
            }
            private set
            {
                _partNumbers = value ?? new List<SchematicPartNumber>();
            }
        } 
         
        public List<SchematicSymbol>? Symbols
        {
            get
            {
                return _symbols;
            }
            private set
            {
                _symbols = value ?? new List<SchematicSymbol>();
            }
        }

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


        public long GetGearRationSum()
        {
            long product = 0;
           //for each symbol, if the symbol is a gear, any adjacent part numbers are multiplied together
           foreach (var symbol in _symbols)
            {
                if (symbol.Value == '*')
                {
                     //get all part numbers that are adjacent to this symbol, AND there must be ONLY two adjacent part numbers
                        var adjacentPartNumbers = _partNumbers.Where(partNumber =>
                                (partNumber.Row == symbol.Row || partNumber.Row - 1 == symbol.Row || partNumber.Row + 1 == symbol.Row) &&
                                (partNumber.Start == symbol.Position || partNumber.Start - 1 == symbol.Position || partNumber.Start + 1 == symbol.Position ||
                                partNumber.End == symbol.Position || partNumber.End - 1 == symbol.Position || partNumber.End + 1 == symbol.Position)
                        ).ToList(); //This immediately executes the query and returns a list to get the count 
                        if (adjacentPartNumbers.Count != 2)
                        {
                            continue;
                        }
                        //multiply  adjacent part numbers together
                        product += adjacentPartNumbers.Aggregate(1L, (acc, partNumber) => acc * partNumber.Value);                      
                }
            }
            return product;
        }

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
            (schematic.PartNumbers, schematic.Symbols) = GetPartNumbers(schematic);
            return schematic;
        }

        private static Tuple<List<SchematicPartNumber>,List<SchematicSymbol>> GetPartNumbers(Schematic schematic)
        {
            if (schematic == null ||  schematic.Grid == null)
            {
                throw new Exception("Grid is null");
            }
            var partNumbers = new List<SchematicPartNumber>();
            var symbols = new List<SchematicSymbol>();
            var rowLength = schematic.Grid?.GetLength(0);
            var columnLength = schematic.Grid?.GetLength(1);
            if (rowLength == null || columnLength == null)
            {
                throw new Exception("Grid is null");
            }
            for (var row = 0; row < rowLength; row++)
            {
                for (var column = 0; column < columnLength; column++)
                {
                    #nullable disable warnings  
                    var currentChar = schematic.Grid[row, column];
                    #nullable restore warnings    
                
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
                                currentChar = schematic.Grid[row, column];
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