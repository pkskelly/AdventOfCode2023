using AdventOfCode2023.Library;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class DayFourTests
    {
        [TestMethod]
        public void SampleCard_Deserialized_HasSixCards()
        {
            var filePath = "../../../../inputs/day4sample.txt";
            var scratchCards = LotteryTickets.DeserializeLotteryTickets(filePath).ScratchCards;
            Assert.AreEqual(6, scratchCards.Count);
        }

        [TestMethod]
        public void SampleCard_Deserialized_CardOne_HasFiveWinningNumbers()
        {
            var filePath = "../../../../inputs/day4sample.txt";
            var scratchCards = LotteryTickets.DeserializeLotteryTickets(filePath).ScratchCards;
            Assert.AreEqual(5, scratchCards[0].WinningNumbers.Count);
        }

        [TestMethod]
        public void SampleCard_Deserialized_CardFive_HasEightCardNumbers()
        {
            var filePath = "../../../../inputs/day4sample.txt";
            var scratchCards = LotteryTickets.DeserializeLotteryTickets(filePath).ScratchCards;
            Assert.AreEqual(8, scratchCards[4].CardNumbers.Count);
        }

        [TestMethod]
        public void SampleCards_SumIs_ThirteenPoints()
        {
            var filePath = "../../../../inputs/day4sample.txt";
            var lotteryTickets = LotteryTickets.DeserializeLotteryTickets(filePath);
            var totalPoints = lotteryTickets.CalculateTotalPoints();
            Assert.AreEqual(13, totalPoints);
        }

        [TestMethod]
        public void LottertyTickets_Has_TotalSum()
        {
            var filePath = "../../../../inputs/day4.txt";
            var lotteryTickets = LotteryTickets.DeserializeLotteryTickets(filePath);
            var totalPoints = lotteryTickets.CalculateTotalPoints();
            Assert.AreEqual(25174, totalPoints);
        }
    }
}

