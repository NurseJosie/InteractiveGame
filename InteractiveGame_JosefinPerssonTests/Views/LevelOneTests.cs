using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteractiveProject.Tests
{
    [TestClass()]
    public class LevelOneTests
    {
        //------------------------------------- CrossRoad ----------------------------------------------------

        [TestMethod()]
        [DataRow("a")]
        [DataRow("!")]
        [DataRow(" ")]
        public void CrossRoadTest_UserInputIsWrongString_Fail(string value)
        {
            //Arrange
            LevelOne levelOne = new();
            var expected = false;

            //Act
            var actual = levelOne.CrossRoad(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("l", false)]
        [DataRow("r", true)]
        public void CrossRoadTest_UserInputIsVaild_Pass(string value, bool expected)
        {
            //Arrange
            LevelOne levelOne = new();

            //Act
            var actual = levelOne.CrossRoad(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //------------------------------------- QFromCharacter ----------------------------------------------------

        [TestMethod()]
        [DataRow("a", true)]
        [DataRow("b", false)]
        [DataRow("c", false)]
        [DataRow("d", false)]
        [DataRow("!", false)]
        public void QFromCharacterTest_UserAnswerIsCorrect_Pass(string value, bool expected)
        {
            // Arrange
            LevelOne levelOne = new();
            Character testCharacter = new("Hi!", "TEST QUESTION", "a. alternative /  b. alternative / c. alternative", "a");
            User user = new();

            //Act
            var actual = levelOne.QFromCharacter(testCharacter, user, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}