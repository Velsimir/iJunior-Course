using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace iJunior
{
    class MainClass
    {
        /*Есть колода с картами. Игрок достает карты, пока не решит, 
         * что ему хватит карт (может быть как выбор пользователя, 
         * так и количество сколько карт надо взять). 
         * После выводиться вся информация о вытянутых картах.
         * Возможные классы: Карта, Колода, Игрок.
         */
        public static void Main(string[] args)
        {
            const string CommandTakeCard = "Take";
            const string CommandTakeFew = "TakeFew";
            const string CommandShowHand = "ShowHand";
            const string CommandExit = "Exit";

            bool isWorking = true;
            string userInput;
            Deck deck = new Deck();
            Player player = new Player("John");

            while (isWorking)
            {
                Console.WriteLine($"Колода на столе, что вы хотите сделать?" +
                    $"\nВзять карту - {CommandTakeCard}" +
                    $"\nВзять несколько карт - {CommandTakeFew}" +
                    $"\nПосмотреть карты в руке - {CommandShowHand}" +
                    $"\nДля выхода - {CommandExit}");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCard:
                        player.TakeCard(deck.GiveCard());
                        break;

                    case CommandTakeFew:
                        player.TakeFewCards(deck);
                        break;

                    case CommandShowHand:
                        player.ShowHand();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Не корректный воод. \nНажмите клавишу, чтобы повторить...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }
    }

    enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    enum Rank
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

    class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }

    class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            Generate();
        }

        public Card GiveCard()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            else
            {
                WriteError();
                return null;
            }
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

            Shuffle();
        }

        private void Shuffle()
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

        private void WriteError()
        {
            Console.WriteLine("Вы забрали все карты из коллоды\nНажмите клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void TakeCard(Card card)
        {
            if (card == null)
            {
                Console.WriteLine("Карту взять не удалось.");
                Console.ReadKey();
            }
            else
            {
                _hand.Add(card);
            }
        }

        public void TakeFewCards(Deck deck)
        {
            string messege = "Сколько карт вы хотите взять?";
            int value = GetNumber(messege);

            for (int i = 0; i < value; i++)
            {
                Card card = deck.GiveCard();

                if (card == null)
                {
                    break;
                }

                _hand.Add(card);
            }
        }

        public void ShowHand()
        {
            if (_hand.Count > 0)
            {
                foreach (var card in _hand)
                {
                    Console.WriteLine($"{card.Rank}  {card.Suit}");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("У вас в руке нет карт.\nНажмите клавишу клавишу, чтобы повторить...");
                Console.ReadKey();
            }
        }

        private int GetNumber(string message)
        {
            int value = 1;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write($"{message}");

                if (int.TryParse((Console.ReadLine()), out value))
                {
                    isWorking = false;

                    Console.Clear();
                    return value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. \nНажмите клавишу, чтобы повторить...");
                    Console.ReadKey();
                }
            }

            return value;
        }
    }
}