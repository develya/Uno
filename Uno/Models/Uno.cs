using Uno.Methods;

namespace Uno.Models;

public class Uno
{
    public Player Player { get; set; }
    public List<Player> Players { get; set; }
    public List<Card> Cards { get; set; }
    public DiscardStack DiscardStack { get; set; }
    public DeckOfCards DeckOfCards { get; set; }

    public void StartGame()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        var mixer = new MixingOfCards(cards);
        var shafled = mixer.Shuffle();
        DeckOfCards = new DeckOfCards(shafled);
        foreach (var player in Players)
        {
            player.TakeCards(DeckOfCards.ReturnSevenCards());
        }
        DiscardStack = new DiscardStack(new List<Card>());
        var firstCard = DeckOfCards.ReturnOneCard();
        if (firstCard != null)
        {
            DiscardStack.AddCard(firstCard);
        }
    }

    public bool PlayTurn(Player player, Card playedCard)
    {
        var topCard = DiscardStack.GetTopCard();

        if (topCard == null)
        {
            return false;
        }

        var rules = new GameRules();

        bool canPlay = rules.CanPlay(playedCard, topCard);

        if (!canPlay)
        {
            return false;
        }

        var card = player.PutCard(playedCard);

        if (card == null)
        {
            return false;
        }

        DiscardStack.AddCard(card);

        return true;
    }

    public bool HasWinner(Player player)
    {
        return player.Cards.Count == 0;
    }

}