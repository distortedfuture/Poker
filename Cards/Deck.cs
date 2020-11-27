using System;
using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        private List<Card> deck;
        private void BuildDeck()
        {
            for (int i = 0; i < 4; i++ ) // 4 SUITS
            {
                for (int j = 2; j <= 14; j++) //13 VALUES   
                {
                    deck.Add(new Card(j, (Suit)i));
                }
            }
        }
        public Card DealCard()
        {
            var index = deck.Count-1;
            Card card = deck[index];
            deck.RemoveAt(index);
            return card;
        }
        private void Shuffle()
        {
            /*
                loop thru cards
                swap each value with a random value
            */
            Random random = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int randomIndex =random.Next(0, deck.Count -1);
                var old = deck[i];
                deck[i] = deck[randomIndex];
                deck[randomIndex] = old;
            }
        }
        public void CountSuits()
        {
            int clubs, dias, spades, hearts;
            clubs = dias = spades = hearts = 0;
            for (int i = 0; i < deck.Count; i++)
            {
                if(deck[i].suit == Suit.Clubs)
                    clubs++;
                if(deck[i].suit == Suit.Diamonds)
                    dias++;
                if(deck[i].suit == Suit.Spades)
                    spades++;
                if(deck[i].suit == Suit.Hearts)
                    hearts++;
            }
            Console.WriteLine($"club count: { clubs.ToString() }");
            Console.WriteLine($"diamond count: { dias.ToString() }");
            Console.WriteLine($"spade count: { spades.ToString() }");
            Console.WriteLine($"heart count: { hearts.ToString() }");
        }
        public void LoopThruCards()
        {
            foreach (var card in deck)
            {
                card.ReadCard();
                // Console.WriteLine();
            }
        }
        public Deck()
        {
            deck = new List<Card>();
            BuildDeck();
            Shuffle();
            // Shuffle();
            // Shuffle();
        }
    }
}
