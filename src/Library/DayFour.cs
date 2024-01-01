namespace AdventOfCode2023.Library
{

    public class ScratchCard
    {
        public int CardNumber { get; set; }
        public HashSet<int>? WinningNumbers { get; set; }
        public HashSet<int>? CardNumbers { get; set; }           
    }
   
   public class LotteryTickets 
   {
       public List<ScratchCard> ScratchCards { get; set; } = new List<ScratchCard>();

       public LotteryTickets(List<ScratchCard> scratchCards)
       {
           ScratchCards = scratchCards;
       }
    
        public int CalculateTotalPoints()
        {
            var points = 0;
            foreach (var scratchCard in ScratchCards)
            {
                var totalMatchesForCard = scratchCard.WinningNumbers.Intersect(scratchCard.CardNumbers).Count();
                if (totalMatchesForCard > 0)
                {
                    var cardValue = (int)Math.Pow(2, totalMatchesForCard - 1);
                    points += cardValue;
                }
            }
            return points;
        }

       public static LotteryTickets DeserializeLotteryTickets(string filePath)
        {
            var scratchCards = new List<ScratchCard>();
            var lines = System.IO.File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                (int cardNumber, HashSet<int> winningNumbers, HashSet<int> cardNumbers) = ParseLine(line);
                
                var scratchCard = new ScratchCard() {CardNumber = cardNumber, WinningNumbers = winningNumbers, CardNumbers = cardNumbers};
                scratchCards.Add(scratchCard);
            }
            return new LotteryTickets(scratchCards);
        }

         private static Tuple<int, HashSet<int>, HashSet<int>> ParseLine(string line)
            {
                var cardNumberString = line.Split(':')[0].Split(' ')[line.Split(':')[0].Split(' ').Length - 1].Trim();
                var cardNumber = int.Parse(cardNumberString);
                var winningNumbers = line.Split(':')[1].Split('|')[0].Split(' ');
                var cardNumbers = line.Split(':')[1].Split('|')[1].Split(' ');
                
                var winningNumberSet = new HashSet<int>();
            var cardNumberSet = new HashSet<int>();

            AddParsedNumbersToSet(winningNumbers, winningNumberSet);
            AddParsedNumbersToSet(cardNumbers, cardNumberSet);

            return new Tuple<int, HashSet<int>, HashSet<int>>(cardNumber, winningNumberSet, cardNumberSet);
        }

        private static void AddParsedNumbersToSet(IEnumerable<string> numbers, HashSet<int> numberSet)
        {
            foreach (var number in numbers)
            {
                if (!String.IsNullOrEmpty(number))
                {
                    var parsedNumber = int.Parse(number);
                    numberSet.Add(parsedNumber);
                }
            }
        }
   }
}