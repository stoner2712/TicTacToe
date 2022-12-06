using TicTacToe;
using Xunit;

namespace TicTacToeXUnitTests
{
    public class GameTests
    {
        [Fact]
        public void CheckWin_FirstRow_ShouldPass()
        {
            //Arrange
            string[] Pos = { "0", "X", "X", "X", "4", "5", "6", "7", "8", "9" };
            var game = new Game(Pos);

            //Act
            bool result = game.CheckWin("X");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWin_FirstColumn_ShouldPass()
        {
            //Arrange
            string[] Pos = { "0", "X", "2", "3", "X", "5", "6", "X", "8", "9" };
            var game = new Game(Pos);

            //Act
            bool result = game.CheckWin("X");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWin_Backslash_ShouldPass()
        {
            //Arrange
            string[] Pos = { "0", "X", "2", "3", "4", "X", "6", "7", "8", "X" };
            var game = new Game(Pos);

            //Act
            bool result = game.CheckWin("X");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWin_FirstRow_OponentSign_ShouldFail()
        {
            //Arrange
            string[] Pos = { "0", "X", "X", "X", "4", "5", "6", "7", "8", "9" };
            var game = new Game(Pos);

            //Act
            bool result = game.CheckWin("O");

            //Assert
            Assert.False(result);
        }
    }
}
