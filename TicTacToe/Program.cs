// See https://aka.ms/new-console-template for more information

using TicTacToe;

public class ConsoleGameTicTacToe
{
    public static void Main(string[] args)
    {
        var game = new Game();

        string[] players = game.EnterPlayers();
        game.PlayGame(players);
    }
}