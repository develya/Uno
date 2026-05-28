namespace Uno.Models;

public class Card
{
    public Enum Color { get; set; }
    public int NumberOfCard { get; set; }
    public int AmountOfCard { get; set; } // кількість одного номеналу
    public Enum SpecialCard { get; set; }
    public string RandomCentreCard { get; set; }    //перша карта

    public List<Card> DeckOfCards { get; set; } //колода карт
    public List<Card> DiscardStack { get; set; }    // типу отбой
    public List<Card> OwnStack { get; set; }   //власні карти
}