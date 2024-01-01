using AdventOfCode2023.Library;

namespace AdventOfCode2023.Tests
{

    [TestClass]
    public class DayThreeTests
    {
         [TestMethod]
        public void SampleGrid_Should_ReturnLenghtOf100()
        {
            //load sample file 
            var filePath = "../../../../inputs/day3sample.txt";
            var schematic = DayThreeProcessor.DeserializeGrid(filePath);
            Assert.AreEqual(100, schematic.Grid?.Length);
        }

        [TestMethod]
        public void SampleGrid_Should_Return_TenPossiblePartNumbers()
        {
            //load sample file 
            var filePath = "../../../../inputs/day3sample.txt";
            var schematic = DayThreeProcessor.DeserializeGrid(filePath);
            Assert.IsTrue(schematic.PartNumbers.Count == 10);
        }

        [TestMethod]
        public void SampleGrid_Should_Return_SixPossibleSchematicSymbols()
        {
            //load sample file 
            var filePath = "../../../../inputs/day3sample.txt";
            var schematic = DayThreeProcessor.DeserializeGrid(filePath);
            Assert.IsTrue(schematic.Symbols.Count == 6);
        }


        [TestMethod]
        public void SampleGrid_Should_Return_CorrectPartNumberSum()
        {
            //load sample file 
            var filePath = "../../../../inputs/day3sample.txt";
            var schematic = DayThreeProcessor.DeserializeGrid(filePath);

            Assert.AreEqual(4361, schematic.GetPartNumberSum());
        }

        [TestMethod]
        public void Grid_Should_Return_CorrectPartNumberSum()
        {
            //load sample file 
            var filePath = "../../../../inputs/day3.txt";
            var schematic = DayThreeProcessor.DeserializeGrid(filePath);

            Assert.AreEqual(512794, schematic.GetPartNumberSum());
        }

    }

}