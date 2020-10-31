using System.Collections.Generic;

namespace RestConsumer
{
    public class Deck
    {
        public string Success { get; set; }
        public string Deck_id { get; set; }
        public string Remaining { get; set; }
        public string Shuffled { get; set; }  
        public Card[] Cards { get; set; }
        public List<Card> cards { get; set; } = new List<Card>();
    }
}