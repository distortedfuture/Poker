using System;
using System.Collections.Generic;

namespace Cards
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand;

        public void GetCard(Deck deck)
        {
            Hand.Add(deck.DealCard());
        }

        public void ShowHand()
        {
            Hand result = Checker.CheckCards(Hand);
            Console.WriteLine($"{ Name }'s hand:");
            foreach (var card in Hand)
            {
                card.ReadCard();
            }
        }
        public void GetHand(List<Card> hand)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Hand.Add(hand[i]);
            }
        }

        public Player()
        {
            Hand = new List<Card>();
            Name = "CPU";
        }
        public Player(string name)
            : this()
        {
            Name = name;
        }
    }
}