namespace Uno.Models;

public class Card
{
    public Enum Color { get; set; }
    public int NumberOfCard { get; set; }
    public Enum SpecialCard { get; set; }
    public string RandomCentreCard { get; set; }
    
    public List<Card> DeckOfCards { get; set; }
    
}