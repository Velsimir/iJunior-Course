using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandShowInventory = "Проверить инвентарь";
            const string CommandShowProducts = "Покажи товары";
            const string CommandBuy = "Купить";

            bool isWorking = true;
            string userInput;
            Trader npcSeller = new Trader("Sam", 1000);
            Player player = new Player("John", 1000);

            while (isWorking)
            {
                Console.Clear();

                Console.Write($"Что хочешь сделать на этот раз?" +
                              $"\n{CommandShowInventory}" +
                              $"\n{CommandShowProducts}" +
                              $"\n{CommandBuy}" +
                              $"\nВведите ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowInventory:
                        player.ShowBag();
                        break;

                    case CommandShowProducts:
                        npcSeller.ShowInterface();
                        break;

                    case CommandBuy:
                        npcSeller.Sell(player);
                        break;
                }
            }
        }
    }
      
    class Human
    {
        protected int Gold;
        private string _name;
        
        protected Human(string name, int gold)
        {
            _name = name;
            Gold = gold;
            Inventory = new List<Product>();
        }

        protected List<Product> Inventory
        {
            get { return Inventory; }
            private set { Inventory = value; }
        }

        protected void ShowInventory(bool isHold = true)
        {
            Console.Clear();

            Console.WriteLine($"{_name}\t" +
                              $"Золотых в наличии - {Gold}");

            Console.WriteLine("Цена:\t  Предметы:\t\t\tОписание:");

            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Price}\t  {item.Name}\t\t\t{item.Description}");
            }

            Console.WriteLine();

            if (isHold)
            {
                Console.ReadKey();
            }
        }
    }

    class Player : Human
    {
        public Player(string name, int gold) : base(name, gold) { }

        public bool TryBuy(Product product)
        {
            if (Gold >= product.Price)
            {
                Gold -= product.Price;
                return true;
            }
            else
            {
                Console.WriteLine("У вас недостаточно денег");
                Console.ReadKey();
                return false;
            }
        }

        public void AddProductToBag(Product product)
        {
            Inventory.Add(product);
        }

        public void ShowBag()
        {
            ShowInventory();
        }
    }

    class Trader : Human
    {
        public Trader(string name, int gold) : base(name, gold)
        {
            Inventory.Add(new Product("Алмаз", 20, "Используется только в самом дорогом оружии и снаряжении"));
            Inventory.Add(new Product("Амулет Змеи", 150, "Урон от яда +4"));
            Inventory.Add(new Product("Перстень Дракона", 100, "Магический урон на +10"));
            Inventory.Add(new Product("Позолоченные Наручи", 200, "Скорость атаки на +15"));
            Inventory.Add(new Product("Позолоченный Шлем", 250, "Защита 5"));
            Inventory.Add(new Product("Сапоги Эйрика", 200, "Скорость передвижения 5"));
            Inventory.Add(new Product("Доспех Викинга", 350, "Защита 12"));
            Inventory.Add(new Product("Бронзовый Щит", 190, "Шанс заблокировать атаку +7"));
            Inventory.Add(new Product("Кольцо Волка", 100, "Физический урон на +15"));
            Inventory.Add(new Product("Руна Совула", 290, "Аура защиты +10"));
            Inventory.Add(new Product("Руна Тейваз", 390, "Аура атаки +20"));
        }

        public void ShowInterface(bool isHold = true)
        {
            ShowInventory(isHold);
        }

        public void Sell(Player player)
        {
            bool isHold = false;

            ShowInterface(isHold);

            Product product;

            if (TryGetProduct(out product) == false)
            {
                Console.WriteLine("Предмет, который вы хотите приобрести, отсутствует у продавца");
                Console.ReadKey();
            }
            else
            {
                if (player.TryBuy(product) == true)
                {
                    Gold += product.Price;
                    Inventory.Remove(product);
                    player.AddProductToBag(product);
                }
            }
        }

        private bool TryGetProduct(out Product product)
        {
            string userInput;

            Console.WriteLine("Что ты хочешь купить?");
            userInput = Console.ReadLine();

            foreach (var item in Inventory)
            {
                if (userInput == item.Name)
                {
                    product = item;

                    return true;
                }
            }
            
            product = null;
            
            return false;
        }
    }

    class Product
    {
        public Product(string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
        
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
    }
}
