using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public Game()
        {
        }
        public Game(string[] Pos)
        {
            this.Pos = Pos;
        }

        public string[] EnterPlayers()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("         TIC - TAC - TOE for 2 players           ");
            Console.WriteLine();
            Console.WriteLine(@"    Game Rules:
            1.Traditionally the first player plays with ""X"".
              So you can decide who wants to go ""X"" and who wants go with ""O"".
            2.Only one player can play at a time.
            3.If any of the players have filled a square then the other player 
              and the same player cannot override that square.
            4.There are only two conditions that may be match will be draw or may be win.
            5.The player that succeeds in placing three respective marks (X or O) 
              in a horizontal, vertical or diagonal row wins the game.");
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("What is the name of player 1 who goes first with 'X' ?");
            var player1 = Console.ReadLine();
            if (string.IsNullOrEmpty(player1))
            {
                player1 = "Player 1";
            }
            Console.WriteLine("What is the name of player 2 who goes second with 'O' ?");
            var player2 = Console.ReadLine();
            if (string.IsNullOrEmpty(player2))
            {
                player2 = "Player 2";
            }
            Console.WriteLine("Great, {0} is X and {1} is O. Good luck to you both!", player1, player2);
            Console.WriteLine("{0} goes first.", player1);
            Console.ReadLine();
            Console.Clear();

            return new[] { player1, player2 };
        }

        public void PlayGame(string[] players)
        {
            bool isGameWon = false;
            bool isGameOver = false;
            int playerIndex = 0;

            while (isGameOver == false)
            {
                var player = players[playerIndex];
                var sign = signs[playerIndex];
                var nextPlayerIndex = 1 - playerIndex;
                var opponentSign = signs[nextPlayerIndex];

                PlayerMakesAMove(players, scores, player, sign, opponentSign);

                isGameWon = CheckWin(sign);
                isGameOver = isGameWon || CheckDraw();

                if (isGameOver == false)
                {
                    playerIndex = nextPlayerIndex;
                }
            }

            Console.Clear();
            DrawBoard();

            if (isGameWon)
            {
                Console.WriteLine("{0} wins!", players[playerIndex]);
            }
            else
            {
                Console.WriteLine("No one wins - it is a draw.");
            }
        }

        private bool TryToPlaceASign(string player, string playerSign, string opponentsSign)
        {
            Console.WriteLine("{0}'s ({1}) turn", player, playerSign);
            var move = AskThePlayer("Which square would you like to mark?", 1, 9);
            if (!IsSquareTaken(playerSign, opponentsSign, move))
            {
                Pos[move] = playerSign;
                return true;
            }

            Console.WriteLine("That square is taken. ");
            Console.Write("Please try again.");
            Console.ReadLine();
            Console.Clear();
            return false;
        }

        private readonly string[] Pos = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] signs = { "X", "O" };
        private int[] scores = { 0, 0 };

        private void DrawBoard()
        {
            Console.WriteLine("     {0}  |   {1}  |   {2}  ", Pos[1], Pos[2], Pos[3]);
            Console.WriteLine("     ------------------");
            Console.WriteLine("     {0}  |   {1}  |   {2}  ", Pos[4], Pos[5], Pos[6]);
            Console.WriteLine("     ------------------");
            Console.WriteLine("     {0}  |   {1}  |   {2}  ", Pos[7], Pos[8], Pos[9]);
        }

        private void PlayerMakesAMove(string[] players, int[] scores, string player, string sign, string opponentSign)
        {
            do
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("");
            } while (!TryToPlaceASign(player, sign, opponentSign));
        }

        private static bool CheckDraw()
        {
            return false;
        }

        private bool IsSquareTaken(string playerSign, string opponentsSign, int move)
        {
            return Pos[move] == opponentsSign || Pos[move] == playerSign;
        }

        private int AskThePlayer(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                int choice = int.Parse(Console.ReadLine());

                if (choice >= min && choice <= max)
                {
                    return choice;
                }
            }
        }

        public bool CheckWin(string sign)
        {
            return CheckFirstRow(sign)      ||
                   CheckSecondRow(sign)     ||
                   CheckThirdRow(sign)      ||
                   CheckFirstColumn(sign)   ||
                   CheckSecondColumn(sign)  ||
                   CheckThirdColumn(sign)   ||
                   CheckBackslashLine(sign) ||
                   CheckForwardlashLine(sign);
        }
        
        private bool CheckFirstRow(string sign)
        {
            return Pos[1] == sign && Pos[2] == sign && Pos[3] == sign;
        }

        private bool CheckSecondRow(string sign)
        {
            return Pos[4] == sign && Pos[5] == sign && Pos[6] == sign;
        }

        private bool CheckThirdRow(string sign)
        {
            return Pos[7] == sign && Pos[8] == sign && Pos[9] == sign;
        }

        private bool CheckFirstColumn(string sign)
        {
            return Pos[1] == sign && Pos[4] == sign && Pos[7] == sign;
        }

        private bool CheckSecondColumn(string sign)
        {
            return Pos[2] == sign && Pos[5] == sign && Pos[8] == sign;
        }

        private bool CheckThirdColumn(string sign)
        {
            return Pos[3] == sign && Pos[6] == sign && Pos[9] == sign;
        }

        private bool CheckBackslashLine(string sign)
        {
            return Pos[1] == sign && Pos[5] == sign && Pos[9] == sign;
        }

        private bool CheckForwardlashLine(string sign)
        {
            return Pos[7] == sign && Pos[5] == sign && Pos[3] == sign;
        }
    }
}

