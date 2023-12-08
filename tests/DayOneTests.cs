using AdventOfCode2023.Library;

namespace AdventOfCode2023.Tests
{

    [TestClass]
    public class DayOneTests
    {      
        [TestMethod]
        public void NoDigit_Should_ReturnNegativeOne_Pass()
        {
            var day1Test = "DayOne";
            Assert.IsTrue(DayOneProcessor.GetCalibrationValue(day1Test) == -1);
        }
 
        [TestMethod]
        [DataRow("Day1",11 )]
        [DataRow("Day1One",11)]
        [DataRow("Day3One",33)]
        [DataRow("9One",99)]
        [DataRow("9On8e5",95)]
        [DataRow("9On8e",98)]
        [DataRow("treb7uchet",77)]
        [DataRow("ldzpzgch325hsttqvmp9foureightmvsknbd",39)]
        public void SingleInitialDigit_Should_Pass(string value, int expected)
        {            
            Assert.AreEqual(DayOneProcessor.GetCalibrationValue(value), expected);
        }

        [TestMethod]
        [DataRow("S1ngleW8ffle",18)]
        public void TwoDigits_Should_ReturnNumber_Pass(string value, int expected)
        {            
            Assert.IsTrue(DayOneProcessor.GetCalibrationValue(value) == expected);
        }
    }

}
