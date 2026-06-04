using Uno.Methods;

namespace Uno.Models;

public class Bot
{
    public Player Player { get; set; }

    public Bot(Player player)
    {
        Player = player;
    }

    public Card? ChooseCard(Card topCard, DeckOfCards deck, Color? currentColor)
    {
        var rules = new GameRules();
        foreach (var card in Player.Cards)
        {
          bool CanPlay = rules.CanPlay(card, topCard, currentColor);
          if (CanPlay)
          {
              Player.PutCard(card);
              return card;
          }
        }

        var newCard = deck.ReturnOneCard();
        if (newCard == null)
        {
            return null;
        }
        Player.TakeCard(newCard);
        bool CanPlayNew = rules.CanPlay(newCard, topCard, currentColor);
        if (CanPlayNew)
        {
            Player.PutCard(newCard);
            return newCard;
        }
        return null;
    }
}