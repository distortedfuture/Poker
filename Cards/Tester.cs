using System.Collections.Generic;

namespace Cards
{
    public class Tester
    {
        public static List<Card> GetHighCard()
        {
            return new List<Card> {
                new Card(6, Suit.Clubs),
                new Card(2, Suit.Diamonds),
                new Card(9, Suit.Clubs),
                new Card(3, Suit.Diamonds),
                new Card(11, Suit.Clubs)
            };
        }
        public static List<Card> GetPair(int val)
        {
            var cards = new List<Card>() {
            new Card(val, Suit.Hearts),
            new Card(val, Suit.Spades),
            new Card(12, Suit.Diamonds),
            new Card(10, Suit.Spades),
            new Card(8, Suit.Clubs)
            };
            return cards;
        }
        public static List<Card> GetTwoPair()
        {
            var cards = new List<Card>() {
            new Card(2, Suit.Hearts),
            new Card(9, Suit.Clubs),
            new Card(7, Suit.Clubs),
            new Card(9, Suit.Spades),
            new Card(2, Suit.Diamonds)
            };
            return cards;
        }
        public static List<Card> GetSet(int val)
        {
            return new List<Card> {
                new Card(val, Suit.Clubs),
                new Card(2, Suit.Clubs),
                new Card(val, Suit.Diamonds),
                new Card(8, Suit.Spades),
                new Card(val, Suit.Spades),
            };
        }
        public static List<Card> GetStraight()
        {
            return new List<Card> {
                new Card(3, Suit.Clubs),
                new Card(4, Suit.Diamonds),
                new Card(5, Suit.Clubs),
                new Card(6, Suit.Hearts),
                new Card(7, Suit.Spades)
            };
        }
        public static List<Card> GetFlush()
        {
            return new List<Card> {
                new Card(3, Suit.Clubs),
                new Card(9, Suit.Clubs),
                new Card(5, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(13, Suit.Clubs)
            };
        }
        public static List<Card> GetFullHouse(int val1, int val2)
        {
            return new List<Card> {
                new Card(val1, Suit.Clubs),
                new Card(val1, Suit.Diamonds),
                new Card(val2, Suit.Clubs),
                new Card(val2, Suit.Diamonds),
                new Card(val1, Suit.Spades)
            };
        }
        public static List<Card> GetFours(int val)
        {
            return new List<Card> {
                new Card(val, Suit.Clubs),
                new Card(val, Suit.Hearts),
                new Card(8, Suit.Clubs),
                new Card(val, Suit.Diamonds),
                new Card(val, Suit.Spades)
            };
        }
        public static List<Card> GetStraghtFlush()
        {
            return new List<Card> {
                new Card(2, Suit.Clubs),
                new Card(3, Suit.Clubs),
                new Card(4, Suit.Clubs),
                new Card(5, Suit.Clubs),
                new Card(6, Suit.Clubs)
            };
        }
        public static List<Card> GetRoyalFlush()
        {
            return new List<Card> {
                new Card(10, Suit.Spades),
                new Card(11, Suit.Spades),
                new Card(12, Suit.Spades),
                new Card(13, Suit.Spades),
                new Card(14, Suit.Spades)
            };
        }
        public static List<Card> GetRandomHand()
        {
            Deck deck = new Deck();
            var hand = new List<Card>();

            for (int i = 0; i < 5; i ++)
                hand.Add(deck.DealCard());    
            return hand;
        }
        public static List<List<Card>> GetAllHands()
        {
            return new List<List<Card>> () {
                Tester.GetHighCard(),
                Tester.GetPair(5),
                Tester.GetTwoPair(),
                Tester.GetSet(11),
                Tester.GetStraight(),
                Tester.GetFlush(),
                Tester.GetFullHouse(12,13),
                Tester.GetFours(4),
                Tester.GetStraghtFlush(),
                Tester.GetRoyalFlush()
            };
        }
    }

}