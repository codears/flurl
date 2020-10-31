using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestConsumer;
using System.Threading.Tasks;

namespace ConsumerTest
{
    [TestClass]
    public class DeckTest
    {
        ApiConsumer<FiltroDeck, Deck> _consumer;

        public DeckTest()
        {
            _consumer = new ApiConsumer<FiltroDeck, Deck>();
        }

        [TestMethod]
        public void ShuffleCardsTest()
        {
            Consumir();
        }

        private async Task Consumir()
        {
            using (var httpTest = new HttpTest())
            {
                // arrange
                httpTest.RespondWith("OK", 200);
                // act
                var resposta = await _consumer.ConsumirApiAsync("deck/new/shuffle/", new FiltroDeck { deck_count = 1 });
                var deckId = resposta.deck_id;
            }
        }
    }
}