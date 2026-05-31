using Uno.Models;

namespace Uno.Methods;

public class GameRules
{
    public bool CanPlay(Card playedCard, Card topCard)
    {
       bool canPlay = playedCard.Color == topCard.Color || playedCard.NumberOfCard  == topCard.NumberOfCard ;
       return canPlay;
    }
}