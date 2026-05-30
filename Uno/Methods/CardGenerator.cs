using Uno.Models;

namespace Uno.Methods;

public class CardGenerator
{
    private List<Card> _cards { get; set; }

    public CardGenerator(List<Card> cards)
    {
        _cards = cards;
    }

    public List<Card> GenerateCards()
    {

        foreach (Color color in Enum.GetValues<Color>())
        {
            for (int i = 0; i <= 9; i++)
            {
                _cards.Add(new Card { Color = color, NumberOfCard = i });
            }
        }

        return _cards;
    }
}