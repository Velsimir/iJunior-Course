using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandTakeCards = "Take";
            const string CommandShowHand = "ShowHand";
            const string CommandShuffleDeck = "ShuffleDeck";
            const string CommandExit = "Exit";

            bool isWorking = true;
            string userInput;
            Player player = new Player("John");
            Dealer dealer = new Dealer(player);

            while (isWorking)
            {
                Console.WriteLine($"Колода на столе, что вы хотите сделать?" +
                                  $"\nВзять карты - {CommandTakeCards}" +
                                  $"\nПосмотреть карты в руке - {CommandShowHand}" +
                                  $"\nПеремешать карты в колоде - {CommandShuffleDeck}" +
                                  $"\nДля выхода - {CommandExit}");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCards:
                        dealer.TransferCardsToPlayer();
                        break;

                    case CommandShowHand:
                        player.ShowHand();
                        break;

                    case CommandShuffleDeck:
                        dealer.ShuffleDeck();
                        break;
                    
                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод. \nНажмите клавишу, чтобы повторить...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }
    }
    
    public class Card
    {
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
    }
    
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            Generate();
        }

        public bool HasCards => _cards.Count > 0;
        
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                int index = random.Next(i + 1);

                Card tempCard = _cards[index];
                _cards[index] = _cards[i];
                _cards[i] = tempCard;
            }
        }

        public Card GiveCard()
        {
            Card card;
            
            card = _cards[0];
            _cards.RemoveAt(0);

            return card;
        }

        private void Generate()
        {
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>(); ;

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    _cards.Add(card);
                }
            }
        }
    }
    
    public class Dealer
    {
        private Deck _deck;
        private Player _player;

        public Dealer(Player player)
        {
            _player = player;
            _deck = new Deck();
            _deck.Shuffle();
        }

        public void TransferCardsToPlayer()
        {
            int count;

            Console.Clear();
            
            Console.WriteLine("Сколько карт вы хотите взять?");
            
            while (int.TryParse(Console.ReadLine(), out count) == false)
            {
                Console.WriteLine("Не корректная команда, повторите ввод: ");
            }
            
            for (int i = 0; i < count; i++)
            {
                if (_deck.HasCards)
                {
                    _player.TakeCard(_deck.GiveCard());
                }
                else
                {
                    Console.WriteLine("В коллоде закончились карты");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }
    }
    
    public class Player
    {
        private List<Card> _hand;
        private string _name;

        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowHand()
        {
            Console.Clear();
            
            Console.WriteLine($"Карты в руке игрока {_name}:");
            
            foreach (var card in _hand)
            {
                Console.WriteLine($"{card.Rank} {card.Suit}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
    
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }
    
    public enum Rank
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
