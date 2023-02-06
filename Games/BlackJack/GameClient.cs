using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    public class GameClient
    {
        private CardDeck deck = new();
        private Player[] players;

        public GameClient()
        {
            players = new[]
            {
             new Player("Дилер", deck),
             new Player("Игрок", deck)
         };

            Start();
        }

        public bool IsEnded { get; private set; }

        public void Start()
        {
            bool replay = true;
            while (replay)
            {
                Console.Clear();
                Turn();
                IsEnded = players.Any(x => x.IsLost);

                Console.ReadLine();

                if (IsEnded)
                    replay = Replay();
            }
        }

        private void Turn()
        {
            foreach (var player in players)
            {
                var status = player.Take() ? "Еще в игре" : "Проиграл";
                Console.WriteLine($"У {player.Name} {player.Score}, он {status}");
            }
        }

        private bool Replay()
        {
            bool result = false;

            while (true)
            {
                Console.Clear();
                Console.Write("Повторить? (y/n): ");
                var value = Console.ReadLine();

                if (value is "y" or "n")
                {
                    result = value is "y";
                    break;
                }
            }

            if (result)
            {
                Reset();
            }

            return result;
        }

        private void Reset()
        {
            deck = new();
            foreach (var player in players)
            {
                player.Reset();
            }
        }
    }
}
