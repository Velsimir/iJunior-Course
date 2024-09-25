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
            int customerNumber = 1;

            while (_clients.Count > 0)
            {
                Client client = _clients.Dequeue();
                Console.WriteLine($"Покупатель {customerNumber})");

                SellProducts(client);

                Console.WriteLine();
                customerNumber++;
            }

            Console.WriteLine("Нет клиентов в очереди");
            Console.ReadKey();
        }

        public void AddQueueClients()
        {
            int minClients = 5;
            int maxClients = 15;
            int clientsInQueue = UserUtils.GetCustomRandomNumber(maxClients, minClients);

            for (int i = 0; i < clientsInQueue; i++)
            {
                Client client = new Client(GiveProducts(_products));
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

                if (client.VerifyEnoughMoney(basketCost))
                {
                    client.RemoveRundomProduct();
                }
                else
                {
                    client.BuyProducts(basketCost);
                    Money += basketCost;
                }
            } while (client.ProductsCount > 0);

            Console.ReadKey();
        }

        private List<Product> GiveProducts(List<Product> products)
        {
            List<Product> tempProducts = new List<Product>();

            foreach (var product in products)
            {
                tempProducts.Add(product);
            }

            return tempProducts;
        }
    }

    class Client
    {
        private List<Product> _shoppingBasket;
        private List<Product> _bag;

        public Client(List<Product> products)
        {
            int minMoney = 500;
            int maxMoney = 1500;
            _shoppingBasket = new List<Product>();
            _bag = new List<Product>();

            Money = UserUtils.GetCustomRandomNumber(maxMoney, minMoney);

            FillBasket(products);
        }
        
        public int Money { get; private set; }
        public int ProductsCount => _shoppingBasket.Count();

        public bool VerifyEnoughMoney(int basketCost)
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

        public void RemoveRundomProduct()
        {
            Product product = _shoppingBasket[GetRandomIndex(_shoppingBasket.Count)];
            _shoppingBasket.Remove(product);

            Console.WriteLine($"Из корзины убрал продукт: {product.Name}");
        }

        public void BuyProducts(int cost)
        {
            TransferProductsToBag(_shoppingBasket);
            
            foreach (var product in _bag)
            {
                Console.WriteLine($"Приобрел: {product.Name} за цену - {product.Cost}");
            }

            Money -= cost;
        }

        private void TransferProductsToBag(List<Product> boughtProducts)
        {
            foreach (var product in boughtProducts)
            {
                _bag.Add(product);
            }
            
            boughtProducts.Clear();
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
    }
}
