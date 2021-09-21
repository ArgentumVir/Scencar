using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    private static Random random = new Random();
    public Game.Format DeckFormat { get; private set; }
    public List<Card> Cards { get; private set; }
    public string Name { get; private set; }

    public Deck() : this("Unnamed Deck", Game.Format.Unknown, new List<Card>()) { }

    static Deck GenerateRandomDeck(int length)
    {
        var cards = new List<Card>();
        for(int i = 0; i < length; i++)
        {
            cards.Add(new Card());
        }

        return new Deck("GeneratedRandomDeck", Game.Format.Normal, cards);
    }

    public (List<Card> deck, List<Card> hand) DealHand(Deck deck)
    {
        return (new List<Card>(), new List<Card>());
    }

    public (List<Card> deck, List<Card> hand) HandleMulligan(
        List<Card> libray,
        List<Card> hand,
        List<Card> mulliganedCards
    )
    {
        return (new List<Card>(), new List<Card>());
    }


    public Deck(string name, Game.Format format, List<Card> cards)
    {
        name = Name;
        DeckFormat = format;
        Cards = cards;
    }

    public List<Card> ShuffleDeck()
    {
        return Cards.OrderBy(c => random.Next()).ToList();
    }
}