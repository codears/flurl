using RestConsumer;
using System;

namespace Principal
{
    class Program
    {
        static string _deckId;
        static FiltroDeck _filtroDeck;

        static void Main(string[] args)
        {
            _filtroDeck = new FiltroDeck();
            CriarBaralho();
            CriarBaralhoPost();
            PegarCarta();
            Console.ReadLine();
        }

        private static async void CriarBaralhoPost()
        {
            try
            {
                var consumidor = new ApiConsumer<Deck>();
                var baralho = await consumidor.PostAsync("deck/new", new { jokers_enabled = true });
                Console.WriteLine($"Id: { baralho.Deck_id }");
                Console.WriteLine();
                _deckId = baralho.Deck_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CriarBaralho()
        {
            try
            {
                _filtroDeck.deck_count = 2;
                var consumidor = new ApiConsumer<Deck>();
                var baralho = consumidor.GetAsync("deck/new/shuffle/", _filtroDeck).Result;
                Console.WriteLine($"Id: { baralho.Deck_id }");
                Console.WriteLine();
                _deckId = baralho.Deck_id;
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
                _filtroDeck.deck_count = -1;
                _filtroDeck.count = 1;
                var resposta = consumidor.GetAsync("deck", _filtroDeck, _deckId, "draw").Result;
                foreach (var carta in resposta.Cards)
                {
                    Console.WriteLine($"{ carta.Value } of { carta.Suit }");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
