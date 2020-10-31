using RestConsumer;
using System;
using System.Linq;

namespace Principal
{
    class Program
    {
        static string _deckId;
        static FiltroDeck filtroDeck;

        static void Main(string[] args)
        {
            filtroDeck = new FiltroDeck();
            CriarBaralho();
            PegarCarta();
            Console.ReadLine();
        }

        private static void CriarBaralho()
        {
            try
            {
                var consumidor = new ApiConsumer<Deck>();
                var resposta = consumidor.GetAsync("deck/new/shuffle/", filtroDeck).Result;
                Console.WriteLine(resposta.Deck_id);
                _deckId = resposta.Deck_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void PegarCarta()
        {
            try
            {
                var consumidor = new ApiConsumer<Deck>();
                filtroDeck.deck_count = -1;
                var resposta = consumidor.GetAsync("deck", new { count = 1 }, _deckId, "draw").Result;
                var carta = resposta.cards.FirstOrDefault();

                Console.WriteLine($"{ carta.Value } of { carta.Suit }");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
