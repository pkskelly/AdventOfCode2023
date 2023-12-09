namespace AdventOfCode2023.Library
{
    //only 12 red cubes, 13 green cubes, and 14 blue cubes

    public class MAX_COLOR_COUNTS
    {
        public const int RED = 12;
        public const int GREEN = 13;
        public const int BLUE = 14;
    }

    public class DayTwo_ColorGame
    {
        public int ID { get; set; }
        public required List<Round> Rounds { get; set; }


        public int CalculateMinColorCountPower()
        {
            //get the minimum color count for each color for each round
            int minRedCount =  Int32.MinValue;
            int minGreenCount = Int32.MinValue;
            int minBlueCount = Int32.MinValue;

            foreach (var round in Rounds)
            {
                foreach (var color in round.Colors)
                {
                    switch (color.Name)
                    {
                        case "red":
                            if ( color.Count > minRedCount)
                            {
                                minRedCount = color.Count;
                            }
                            break;
                        case "green":
                            if ( color.Count > minGreenCount)
                            {
                                minGreenCount = color.Count;
                            }
                            break;
                        case "blue":
                            if ( color.Count > minBlueCount )
                            {
                                minBlueCount = color.Count;
                            }
                            break;
                    }
                }
            }
            var gamePower = minRedCount * minGreenCount * minBlueCount;
            return gamePower;
        }

        public bool IsValid()
        {
            var redCount = 0;
            var greenCount = 0;
            var blueCount = 0;
            var roundValid = true;
            foreach (var round in Rounds)
            {
                foreach (var color in round.Colors)
                {
                    switch (color.Name)
                    {
                        case "red":
                            redCount = color.Count;
                            break;
                        case "green":
                            greenCount = color.Count;
                            break;
                        case "blue":
                            blueCount = color.Count;
                            break;
                    }
                }
                roundValid = redCount <= MAX_COLOR_COUNTS.RED && greenCount <= MAX_COLOR_COUNTS.GREEN && blueCount <= MAX_COLOR_COUNTS.BLUE;
                if (!roundValid)
                {
                    break;
                }
            }
            return roundValid;
        }
    }

    public class Round
    {
        public Round()
        {
            Colors = new List<Color>();
        }
        public ICollection<Color> Colors { get; set; }
    }

    public record Color
    {
        public required string Name { get; set; }
        public int Count { get; set; }
    }

    public class GameDeserializer
    {
        public static DayTwo_ColorGame DeserializeGame(string gameText)
        {
            var inputLineGameParts = gameText.Split(':');
            var newGame = new DayTwo_ColorGame()
            {
                ID = int.Parse(inputLineGameParts[0].Split(' ')[1]),
                Rounds = new List<Round>()
            };

            var inputLineRounds = inputLineGameParts[1].Split(';');
            foreach (var round in inputLineRounds)
            {
                var inputColors = round.Split(',');
                var gameRound = new Round();
                foreach (var color in inputColors)
                {
                    var colorParts = color.Trim().Split(' ');
                    gameRound.Colors.Add(new Color { Name = colorParts[1], Count = int.Parse(colorParts[0]) });
                }
                newGame.Rounds.Add(gameRound);
            }
            return newGame;
        }
    }

    public class DayTwoProcessor
    {
        public static int GetValidGameIDSum(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var validGameSum = 0;
            foreach (string line in lines)
            {
                var game = Library.GameDeserializer.DeserializeGame(line);
                if (game.IsValid())
                {
                    validGameSum += game.ID;
                }
            }
            return validGameSum;
        }

           public static int GetSumOfGamePowers(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var gamePowersSum = 0;
            foreach (string line in lines)
            {
                var game = Library.GameDeserializer.DeserializeGame(line);
                var gamePower = game.CalculateMinColorCountPower();
                gamePowersSum += gamePower;
            }
            return gamePowersSum;
        }
    }
}