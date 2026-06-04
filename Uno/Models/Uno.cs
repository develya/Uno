using Uno.Methods;

namespace Uno.Models;

public class Uno
{
    public Player Player
    {
        get;
        set;
    }

    public List<Player> Players
    {
        get;
        set;
    }

    public List<Card> Cards
    {
        get;
        set;
    }

    public DiscardStack DiscardStack
    {
        get;
        set;
    }

    public DeckOfCards DeckOfCards
    {
        get;
        set;
    }

    public bool SkipNextTurn
    {
        get;
        set;
    }

    public Color? CurrentColor
    {
        get;
        set;
    }

    public bool IsReversed
    {
        get;
        set;
    } = false;


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

        bool canPlay = rules.CanPlay(playedCard, topCard, CurrentColor);

        if (!canPlay)
        {
            return false;
        }

        if (playedCard.SpecialType == SpecialCard.SkipTurn)
        {
            SkipNextTurn = true;
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

    private void ShowTopCard()
    {
        var topCard = DiscardStack.GetTopCard();
        if (topCard == null)
        {
            return;
        }

        Console.WriteLine($"Top card: {topCard.Color} {topCard.NumberOfCard}");
    }

    private void ShowPlayerCards(Player player)
    {
        Console.WriteLine("Your cards:");
        for (int i = 0; i < player.Cards.Count; i++)
        {
            var card = player.Cards[i];

            if (card.SpecialType == SpecialCard.ChangeColor ||
                card.SpecialType == SpecialCard.ChangeColorPlusFour)
            {
                Console.WriteLine($"{i}. {card.SpecialType}");
            }
            else if (card.SpecialType != null)
            {
                Console.WriteLine($"{i}. {card.Color} {card.SpecialType}");
            }
            else
            {
                Console.WriteLine($"{i}. {card.Color} {card.NumberOfCard}");
            }
        }
    }

    private void TakeTwoCards(Player player, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var card = DeckOfCards.ReturnOneCard();

            if (card == null)
            {
                return;
            }

            player.TakeCard(card);
        }
    }

    private void PersonTurn(Player player)
    {
        bool played = false;
        while (!played)
        {
            ShowPlayerCards(player);
            Console.WriteLine("Choose the card you would like to play: (-1 - you can take one more card");
            int index = int.Parse(Console.ReadLine());
            if (index == -1)
            {
                var newCard = DeckOfCards.ReturnOneCard();
                if (newCard != null)
                {
                    player.TakeCard(newCard);
                    Console.WriteLine($"Your cnew card : {newCard.Color} {newCard.NumberOfCard}");
                }

                continue;
            }

            var card = player.Cards[index];
            played = PlayTurn(player, card);

            if (!played)
            {
                Console.WriteLine("Wrong card you would like to play:");
            }
            else
            {
                if (card.SpecialType == SpecialCard.ChangeColor || card.SpecialType == SpecialCard.ChangeColorPlusFour)
                {
                    CurrentColor = ChooseColor();
                    Console.WriteLine($"Color changed to {CurrentColor}");
                }
                else
                {
                    CurrentColor = card.Color;
                }
            }
        }
    }

    private void BotTurn(Bot bot)
    {
        Console.WriteLine("Bot turn");
        var topCard = DiscardStack.GetTopCard();
        if (topCard == null)
        {
            return;
        }

        var botCard = bot.ChooseCard(topCard, DeckOfCards, CurrentColor);
        if (botCard != null)
        {
            DiscardStack.AddCard(botCard);

            if (botCard.SpecialType == SpecialCard.ChangeColor ||
                botCard.SpecialType == SpecialCard.ChangeColorPlusFour)
            {
                CurrentColor = (Color) new Random().Next(0, 4);
                Console.WriteLine($"Bot put card {botCard.SpecialType}");
                Console.WriteLine($"Bot changed color to {CurrentColor}");
            }
            else
            {
                CurrentColor = botCard.Color;
                Console.WriteLine($"Bot put card {botCard.Color} {botCard.NumberOfCard}");
            }


        }
        else
        {
            Console.WriteLine("No card played");
        }
    }

    private Color ChooseColor()
    {
        Console.WriteLine("Choose color: 0-Red, 1-Green, 2-Blue, 3-Yellow");
        return (Color) int.Parse(Console.ReadLine());
    }


    public void Run(Player player, Bot bot)
    {
        bool skipNextTurn = false;

        while (true)
        {
            ShowTopCard();

            var topCardBeforePerson = DiscardStack.GetTopCard();

            if (skipNextTurn)
            {
                Console.WriteLine("Your turn skipped");
                skipNextTurn = false;
            }
            else
            {
                PersonTurn(player);
            }

            if (HasWinner(player))
            {
                Console.WriteLine("Congratulations! You won!");
                break;
            }

            var topCard = DiscardStack.GetTopCard();

            if (topCard != topCardBeforePerson)
            {
                if (topCard?.SpecialType == SpecialCard.PlusTwo)
                {
                    TakeTwoCards(bot.Player, 2);
                    Console.WriteLine("Bot takes 2 cards");
                }

                if (topCard?.SpecialType == SpecialCard.ChangeColorPlusFour)
                {
                    TakeTwoCards(bot.Player, 4);
                    Console.WriteLine("Bot takes 4 cards");
                    skipNextTurn = true;
                }

                if (topCard?.SpecialType == SpecialCard.SkipTurn)
                {
                    skipNextTurn = true;
                }

                if (topCard?.SpecialType == SpecialCard.Reverse)
                {
                    skipNextTurn = true;
                    Console.WriteLine("Direction changed!");
                }
            }

            if (skipNextTurn)
            {
                Console.WriteLine("Bot turn skipped");
                skipNextTurn = false;
            }
            else
            {
                var topCardBeforeBot = DiscardStack.GetTopCard();
                BotTurn(bot);
                topCard = DiscardStack.GetTopCard();

                if (topCard != topCardBeforeBot)
                {
                    if (topCard?.SpecialType == SpecialCard.PlusTwo)
                    {
                        TakeTwoCards(player, 2);
                        Console.WriteLine("You take 2 cards");
                    }

                    if (topCard?.SpecialType == SpecialCard.ChangeColorPlusFour)
                    {
                        TakeTwoCards(player, 4);
                        Console.WriteLine("You take 4 cards");
                        skipNextTurn = true;
                    }
                    if (topCard?.SpecialType == SpecialCard.SkipTurn)
                    {
                        skipNextTurn = true;
                    }

                    if (topCard?.SpecialType == SpecialCard.Reverse)
                    {
                        skipNextTurn = true;
                        Console.WriteLine("Direction changed!");
                    }
                }
            }

            if (HasWinner(bot.Player))
            {
                Console.WriteLine("Bot won!");
                break;
            }
        }
    }
}




