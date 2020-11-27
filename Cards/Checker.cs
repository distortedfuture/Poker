using System.Collections.Generic;

namespace Cards
{
    public class Checker
    {
        public static Hand CheckCards(List<Card> hand)
        {
            if (Card.IsRoyalFlush(hand))
                return Hand.RoyalFlush;
            if (Card.IsStraightFlush(hand))
                return Hand.StraightFlush;
            if (Card.IsFours(hand))
                return Hand.FourOfAKind;
            if (Card.IsFullHouse(hand))
                return Hand.FullHouse;
            if (Card.IsFlush(hand))
                return Hand.Flush;
            if (Card.IsStraight(hand))
                return Hand.Straight;
            if (Card.IsSet(hand))
                return Hand.Set;
            if (Card.IsTwos(hand))
                return Hand.TwoPair;
            if (Card.IsPair(hand))
                return Hand.Pair;

            return Hand.HighCard;
        }
    }
}
