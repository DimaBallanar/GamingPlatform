using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack;

internal class Player
{
    private CardDeck deck;
    private List<Card> cards = new();

    public Player(string name, CardDeck deck)
        => (Name, this.deck) = (name, deck);

    public string Name { get; init; }
    public int Money { get; private set; } = 1000;
    public int Score { get; private set; }
    public int Cards => cards.Count;
    public bool IsLost => Score > 21;

    public bool Take()
    {
        if (IsLost) return false;
        var card = deck.Take();
        cards.Add(card);
        Score += card.Value;
        return !IsLost;
    }

    public void Reset()
    {
        Score = 0;
        cards.Clear();
    }
}
