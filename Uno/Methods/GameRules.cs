using Uno.Models;

namespace Uno.Methods;

public class GameRules
{
    public bool CanPlay(Card playedCard, Card topCard, Color? currentColor)
    {
        if (playedCard.SpecialType == SpecialCard.ChangeColor || playedCard.SpecialType == SpecialCard.ChangeColorPlusFour)
        {
            return true;
        }

        if (currentColor != null)
        {
            return playedCard.Color == currentColor ||
                   (playedCard.SpecialType != null && playedCard.SpecialType == topCard.SpecialType);
        }

        var result =  playedCard.Color == topCard.Color || playedCard.NumberOfCard == topCard.NumberOfCard || playedCard.SpecialType == topCard.SpecialType;
        return result;
    }
}