using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class CardDeck
    {
        private readonly List<Card> cards = new();
        public CardDeck() => GenerateCards();

        public Card Take()
        {
            if (IsEmpty) return null;
            var card = cards[new Random().Next(cards.Count)];
            cards.Remove(card);

            return card;
        }

        public bool IsEmpty => !cards.Any();
        public int Count => cards.Count;

        private void GenerateCards()
        {
            foreach (var type in Enum.GetValues<CardEnum>())
            {
                if (type is CardEnum.Number)
                {
                    for (int i = 2; i <= 9; i++)
                    {
                        cards.AddRange(CreateCardsByType(type, i));
                    }
                }
                else
                {
                    cards.AddRange(CreateCardsByType(type));
                }
            }
        }

        private IEnumerable<Card> CreateCardsByType(CardEnum type, int value = 0)
        {
            List<Card> result = new();

            for (int i = 0; i < 4; i++)
            {
                Card card = type switch
                {
                    CardEnum.Number => new($"{value}", value, type),
                    CardEnum.Jack => new($"Валет", 10, type),
                    CardEnum.Queen => new($"Дама", 10, type),
                    CardEnum.King => new($"Король", 10, type),
                    CardEnum.Ace => new($"Туз", 11, type),
                };

                result.Add(card);
            }

            return result;
        }
    }
}
