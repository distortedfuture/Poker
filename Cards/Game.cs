using System;

namespace Cards
{
    public class Game
    {
        public void Start()
        {
            Deck deck = new Deck();
            Console.Write("Player 1: ");
            Player playerOne = GetPlayer();
            Console.Write("Player 2: ");
            Player playerTwo = GetPlayer();

            DealCards(deck, playerOne, playerTwo);
            SwitchCards(playerOne, deck);
            SwitchCards(playerTwo, deck);

            var (winner, winningHand) = DeclareWinner(playerOne, playerTwo);
            HandleWin(winner, winningHand);

            playerOne.ShowHand();
            playerTwo.ShowHand();
        }
        private Player GetPlayer()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine().Trim();
            return new Player(name);
        }
        private void DealCards(Deck deck, Player pl1, Player pl2)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i%2 ==0)
                {
                    pl1.GetCard(deck);
                } else {
                    pl2.GetCard(deck);
                }
            }
        }
        private void SwitchCards(Player player, Deck deck)
        {

            Console.WriteLine();
            Console.WriteLine($"{ player.Name } can now change up to 2 cards in their hand");
            Console.WriteLine("enter the number displayed next to the card you want to switch");
            Console.WriteLine("enter 'x' at anytime to stop");

            int c = 0;
            foreach (var card in player.Hand)
            {
                Console.Write($"{c}: ");
                card.ReadCard();
                c++;
            }
            Console.WriteLine();

            int prev = 10;
            int count = 0;
            while(count < 2)
            {
                int index;
                var input = Console.ReadLine();
                if (input == "x")
                    break;
                try
                {
                    index = Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("not a valid number");
                    continue;
                }

                if (index >= player.Hand.Count)
                {
                    Console.WriteLine($"{index} is too high, please pick one of the options");
                    continue;
                } else if (index == prev)
                {
                    Console.WriteLine("You cannot switch a card you just swapped for");
                    continue;
                } else
                {
                    Card newCard = deck.DealCard();
                    Console.WriteLine($"{ player.Name } switched out { player.Hand[index].GetName() } for {newCard.GetName()}");
                    player.Hand[index] = newCard;
                    prev = index;
                    count++;
                }
            }
        }
        private (Player, Hand) DeclareWinner(Player player1, Player player2)
        {
            Hand playerOneHand = Checker.CheckCards(player1.Hand);
            Hand playerTwoHand = Checker.CheckCards(player2.Hand);
            int playerOneScore = (int)playerOneHand;
            int playerTwoScore = (int)playerTwoHand;
    
            if (playerOneScore > playerTwoScore)
            {
                return (player1, playerOneHand);
            } else if (playerTwoScore > playerOneScore)
            {
                return (player2, playerTwoHand);
            } else
            {
                if (player1.Hand[4].value > player2.Hand[4].value)
                {
                    return (player1, playerOneHand);
                } else if (player2.Hand[4].value > player1.Hand[4].value) {
                    return (player2, playerTwoHand);
                } else
                {
                    return (new Player("Tie"), playerOneHand);
                }
            }
        }
        private void HandleWin(Player winner, Hand winHand)
        {
            if (winner.Name == "Tie")
            {
                Console.WriteLine($"Both players have tied with a { winHand }");
            } else {
                Console.WriteLine($"{ winner.Name } has won with a { winHand }");
            }
        }
        public void Test()
        {
            var deck = new Deck();
            var pl1 = new Player("one");
            var pl2 = new Player("two");
            // pl1.GetHand(Tester.GetRandomHand());
            // pl2.GetHand(Tester.GetRandomHand());
            DealCards(deck, pl1, pl2);
            var (winner, hand) = DeclareWinner(pl1, pl2);
            HandleWin(winner, hand);
            pl1.ShowHand();
            pl2.ShowHand();
        }
    }
}
