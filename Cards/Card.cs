using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card
    {
        public int value;
        public Suit suit;
        public void ReadCard()
        {
            switch(suit)
            {
                case (Suit.Clubs):
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case (Suit.Spades):
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case (Suit.Diamonds):
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case (Suit.Hearts):
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
            Console.WriteLine(GetName());
            Console.ResetColor();
        }
        public string GetName()
        {
            string val;
            string _suit;
            switch (value)
            {
                case (11):
                    val = "Jack";
                    break;
                case (12):
                    val = "Queen";
                    break;
                case (13):
                    val = "King";
                    break;
                case (14):
                    val = "Ace";
                    break;
                default:
                    val = value.ToString();
                    break;
            }
            switch(suit)
            {
                case (Suit.Clubs):
                    _suit = "\u2663";
                    break;
                case (Suit.Spades):
                    _suit = "\u2660";
                    break;
                case (Suit.Diamonds):
                    _suit = "\u2666";
                    break;
                case (Suit.Hearts):
                    _suit = "\u2665";
                    break;
                default:
                    _suit = "unknown";
                    break;
            }
            string result = val + "" + _suit;
            return result;
        }

        public static void SortByValue(List<Card> cards)
        {
            if (cards.Count != 5)
                throw new InvalidOperationException("Hand must contain exactly five cards");

            for (int i = 0; i < cards.Count; i++)
            {
                var min = i;
                for (int j = i+1; j < cards.Count; j++)
                {
                    if(cards[j].value < cards[i].value)
                        min = j;
                }
                Card help = cards[min];
                cards[min] = cards[i];
                cards[i] = help;
            }
        }
        public static bool IsPair(List<Card> hand)
        {
            SortByValue(hand);
            for (int i = 0; i < hand.Count -1; i++)
            {
                if (hand[i].value == hand[i+1].value)
                {
                    var last = hand[4];
                    hand[4] = hand[i];
                    hand[i] = last;
                    return true;
                }                
            }
            return false;
        }
        public static bool IsTwos(List<Card> hand)
        {
            var count = 0;
            SortByValue(hand);
            for (int i= 0; i < hand.Count -1; i++)
            {
                if (hand[i].value == hand[i+1].value)
                {
                    count++;
                }
            }
            if (count == 2)
                return true;

            return false;
        }
        public static bool IsSet(List<Card> hand)
        {
            SortByValue(hand);
            bool a, b, c;
            // xxxyz
            a = hand[0].value == hand[1].value && hand[1].value == hand[2].value;
            // yxxxz
            b = hand[1].value == hand[2].value && hand[2].value == hand[3].value;
            // yzxxx
            c = hand[2].value == hand[3].value && hand[3].value == hand[4].value;

            if (a)
            {
                var last = hand[4];
                hand[4] = hand[0];
                hand[0] = last;
                return true;
            } else if (b)
            {
                var last = hand[4];
                hand[4] = hand[2];
                hand[2] = last;
                return true;
            } else if (c)
            {
                return true;
            }

            return false;
        }
        public static bool IsStraight(List<Card> hand)
        {
            SortByValue(hand);
            for (int i = 0; i < hand.Count - 1; i++)
            {
                if (hand[i].value +1 != hand[i+1].value)
                    return false;
            }
            return true;
        }
        public static bool IsFlush(List<Card> hand)
        {
            SortByValue(hand);

            for (int i = 0; i < hand.Count-1; i++)
            {
                if (hand[i].suit != hand[i+1].suit)
                    return false;
            }

            return true;
        }
        public static bool IsFullHouse(List<Card> hand)
        {
            SortByValue(hand);
            bool a,b;

            // XX YYY
            a = hand[0].value == hand[1].value &&
                hand[2].value == hand[3].value &&
                hand[3].value == hand[4].value; 
            // XXX YY
            b = hand[0].value == hand[1].value &&
                hand[1].value == hand[2].value &&
                hand[3].value == hand[4].value;
            
            if (b)
            {
                var last = hand[4];
                hand[4] = hand[0];
                hand[0] = last;
                return true;
            } else if (a)
            {
                return true;
            }
            
            return false;
        }
        public static bool IsFours(List<Card> hand)
        {
            SortByValue(hand);
            bool a,b;
            // xxxxy
            a = hand[0].value == hand[1].value &&
                hand[1].value == hand[2].value &&
                hand[2].value == hand[3].value;
            // yxxxx
            b = hand[1].value == hand[2].value && 
                hand[2].value == hand[3].value && 
                hand[3].value == hand[4].value;
            
            if (a)
            {
                var last = hand[4];
                hand[4] = hand[0];
                hand[0] = last;
                return true;
            } else if (b)
            {
                return true;
            }
            return false;
        }
        public static bool IsStraightFlush(List<Card> hand)
        {
            SortByValue(hand);
            return (IsFlush(hand) && IsStraight(hand));
        }
        public static bool IsRoyalFlush(List<Card> hand)
        {
            SortByValue(hand);
            return (IsStraightFlush(hand) && hand[4].value == 14);
        }
        public Card(int val, Suit _suit)
        {
            if (val >= 2 && val <= 14)
            {
                value = val;
                suit = _suit;
            } else { throw new InvalidOperationException("card data not valid"); }
        }
    }
}