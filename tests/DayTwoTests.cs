using AdventOfCode2023.Library;

namespace AdventOfCode2023.Tests
{

    [TestClass]
    public class DayTwoTests
    {

        [TestMethod]
        public void Deserializing_Game_Should_Return_Correct_ID()
        {
            var game1 = "Game 2: 2 blue, 3 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.AreEqual(2, game.ID);
        }

        [TestMethod]
        public void Deserializing_Game_Should_Return_Correct_Rounds_Count()
        {
            var game1 = "Game 2: 2 blue, 3 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.AreEqual(5, game.Rounds.Count);
        }

        [TestMethod]
        public void Deserializing_Game_Should_Return_Correct_Colors_Count()
        {
            var game1 = "Game 1: 2 blue, 3 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.AreEqual(2, game.Rounds[0].Colors.Count);
            Assert.AreEqual(3, game.Rounds[1].Colors.Count);
            Assert.AreEqual(2, game.Rounds[2].Colors.Count);
            Assert.AreEqual(3, game.Rounds[3].Colors.Count);
            Assert.AreEqual(2, game.Rounds[4].Colors.Count);
        }


        //only 12 red cubes, 13 green cubes, and 14 blue cubes

        [TestMethod]
        public void Invalid_Game_Red_Should_Pass()
        {
            var game1 = "Game 74: 3 blue, 7 red; 3 blue, 5 green, 2 red; 5 red, 1 green, 3 blue; 8 green, 2 blue, 11 red; 3 blue, 8 green, 10 red";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.IsTrue(game.IsValid());
        }

        [TestMethod]
        public void Invalid_Game_Red_Should_Fail()
        {
            var game1 = "Game 1: 6 blue, 13 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.IsFalse(game.IsValid());
        }

        [TestMethod]
        public void Invalid_Game_Green_Should_Fail()
        {
            var game1 = "Game 1: 14 blue, 12 red; 14 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.IsFalse(game.IsValid());
        }

        [TestMethod]
        public void Invalid_Game_Blue_Should_Fail()
        {
            var game1 = "Game 1: 14 blue, 12 red; 14 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 15 blue, 9 red; 2 red, 4 blue";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.IsFalse(game.IsValid());
        }

        [TestMethod]
        public void Should_Calculate_GameMinColorPower()
        {
            // blue 6, red 4, green 2
            var game1 = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            var game = GameDeserializer.DeserializeGame(game1);
            Assert.AreEqual(48, game.CalculateMinColorCountPower());
        }
    }
}
