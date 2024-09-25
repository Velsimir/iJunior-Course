using System;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandAddClients = "1";
            const string CommandServeClient = "2";
            const string CommandExit = "3";
            bool isWorking = true;
            string userInput;
            Supermarket superMarket = new Supermarket();

            do
            {
                Console.Clear();

                Console.WriteLine($"Касса магазина = {superMarket.Money}" +
                                  $"\nРабочий день начался, что вы хотите сделать?" +
                                  $"\n{CommandAddClients} - пригласить посетителей на кассу" +
                                  $"\n{CommandServeClient} - обслужить посетителей" +
                                  $"\n{CommandExit} - завершить рабочий день");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddClients:
                        superMarket.AddQueueClients();
                        break;

                    case CommandServeClient:
                        superMarket.ServeClients();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            } while (isWorking);
        }
    }

    class Supermarket
        { 
            private List<Product> _products = new List<Product>();
            private Queue<Client> _clients = new Queue<Client>();

            public Supermarket()
            {
                _products.Add(new Product("Сыр", 149));
                _products.Add(new Product("Колбаса", 239));
                _products.Add(new Product("Хлеб", 99));
                _products.Add(new Product("Молоко", 89));
                _products.Add(new Product("Яйца", 119));
                _products.Add(new Product("Картофель 1кг", 78));
                _products.Add(new Product("Шоколад", 129));
                _products.Add(new Product("Лимонад", 119));
                _products.Add(new Product("Печенье", 47));
                _products.Add(new Product("Мясо", 339));
                _products.Add(new Product("Гречка", 79));
                _products.Add(new Product("Макароны", 79));
            }
            
            public int Money { get; private set; } = 0;

            public void ServeClients()
            {
                bool isQueueServed = true;
                int customerNumber = 1;

                if (_clients.Count > 0)
                {
                    while (isQueueServed)
                    {
                        Client client = _clients.Dequeue();
                        Console.WriteLine($"Покупатель {customerNumber})");

                        SellProducts(client);

                        if (_clients.Count() == 0)
                        {
                            Console.WriteLine("В очереди нет посетителей");
                            isQueueServed = false;
                            Console.ReadKey();
                        }

                        Console.WriteLine();
                        customerNumber++;
                    }
                }
                else
                {
                    Console.WriteLine("Нет клиентов в очереди");
                    Console.ReadKey();
                }
            }

            public void AddQueueClients()
            {
                int minClients = 5;
                int maxClients = 15;
                int clientsInQueue = UserUtils.GetCustomRandomNumber(maxClients, minClients);

                for (int i = 0; i < clientsInQueue; i++)
                {
                    Client client = new Client(_products);
                    _clients.Enqueue(client);
                }
            }

            private int CalculatePriceProducts(Client client)
            {
                int basketCost = 0;
                List<Product> products = client.GiveBasket();

                for (int i = 0; i < products.Count(); i++)
                {
                    basketCost += products[i].Cost;
                }

                return basketCost;
            }

            private void SellProducts(Client client)
            {
                int basketCost;

                do
                {
                    basketCost = CalculatePriceProducts(client);

                    if (client.CheckEnoughMoney(basketCost))
                    {
                        client.RemoveProduct();
                    }
                    else
                    {
                        client.BuyProducts(basketCost);
                        Money += basketCost;
                    }
                } while (client.ProductsCount > 0);

                Console.ReadKey();
            }
    }

    class Client
    {
        private List<Product> _shoppingBasket;

        public Client(List<Product> products)
        {
            int minMoney = 500;
            int maxMoney = 1500;
            _shoppingBasket = new List<Product>();

            Money = UserUtils.GetCustomRandomNumber(maxMoney, minMoney);

            FillBasket(products);
        }
        
        public int Money { get; private set; }
        public int ProductsCount => _shoppingBasket.Count();

        public bool CheckEnoughMoney(int basketCost)
        {
            return basketCost >= Money;
        }

        public List<Product> GiveBasket()
        {
            List<Product> products = new List<Product>();

            foreach (var product in _shoppingBasket)
            {
                products.Add(product);
            }

            return products;
        }

        public void RemoveProduct()
        {
            Product product = _shoppingBasket[GetRandomIndex(_shoppingBasket.Count)];
            _shoppingBasket.Remove(product);

            Console.WriteLine($"Из корзины убрал продукт: {product.Name}");
        }

        public void BuyProducts(int cost)
        {
            foreach (var product in _shoppingBasket)
            {
                Console.WriteLine($"Приобрел: {product.Name} за цену - {product.Cost}");
            }

            Money -= cost;
        }

        private int GetRandomIndex(int maxProducts)
        {
            int lastProduct = maxProducts;
            int randomIndex = UserUtils.GetCustomRandomNumber(lastProduct);

            return randomIndex;
        }

        private Product TakeRandomProduct(List<Product> products)
        {
            int firstProduct = 0;
            int lastProduct = products.Count();
            int randomIndex = UserUtils.GetCustomRandomNumber(lastProduct,firstProduct);

            return products[randomIndex];
        }

        private void FillBasket(List<Product> products)
        {
            int minProducts = 5;
            int maxProducts = 15;

            int countOfProducts = UserUtils.GetCustomRandomNumber(maxProducts, minProducts);

            for (int i = 0; i < countOfProducts; i++)
            {
                Product product = TakeRandomProduct(products);

                _shoppingBasket.Add(new Product(product.Name, product.Cost));
            }
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        
        public string Name { get; private set; }
        public int Cost { get; private set; }
    }
    
    public static class UserUtils
    {
        private const int MinValue = 0;
        private const int MaxValue = 101;

        private static Random _random = new Random();

        public static int GetCustomRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(MinValue, max + 1);
        }

        public static int GetRandomNumberByHundred()
        {
            return _random.Next(MinValue, MaxValue);
        }
    }
}
