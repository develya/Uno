namespace Uno.Models;

public class Uno
{
    public Player Player { get; set; }
    public List<Player> Players { get; set; }
    public List<Card> Cards { get; set; }
    public DiscardStack DiscardStack { get; set; }
    public DeckOfCards DeckOfCards { get; set; }

}