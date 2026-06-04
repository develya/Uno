using Uno.Methods;
using Uno.Models;

class Program
{
    static void Main(string[] args)
    {
        var game = new Uno.Models.Uno();
        var player = new Player { Name = "Elya", Cards = new List<Card>() };
        var botPlayer = new Player { Name = "VladaBot", Cards = new List<Card>() };
        var bot = new Bot(botPlayer);
        game.Players = new List<Player> { player, botPlayer };

        game.StartGame();

        game.Run(player, bot);


    }
}