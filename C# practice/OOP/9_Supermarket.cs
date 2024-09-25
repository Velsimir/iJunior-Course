using System;
using System.Collections.Generic;
using System.Linq;

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
            ClientFactory clientFactory = new ClientFactory();

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
                        superMarket.AddClients(clientFactory.CreateClients(superMarket.Products));
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
        private Queue<Client> _clients = new Queue<Client>();

        public Supermarket()
        {
            Products = new List<Product>();
            
            Products.Add(new Product("Сыр", 149));
            Products.Add(new Product("Колбаса", 239));
            Products.Add(new Product("Хлеб", 99));
            Products.Add(new Product("Молоко", 89));
            Products.Add(new Product("Яйца", 119));
            Products.Add(new Product("Картофель 1кг", 78));
            Products.Add(new Product("Шоколад", 129));
            Products.Add(new Product("Лимонад", 119));
            Products.Add(new Product("Печенье", 47));
            Products.Add(new Product("Мясо", 339));
            Products.Add(new Product("Гречка", 79));
            Products.Add(new Product("Макароны", 79));
        }
        
        public List<Product> Products { get; private set; }
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

        public void AddClients(Queue<Client> clients)
        {
            foreach (var client in clients)
            {
                _clients.Enqueue(client);
            }
        }

        private int CalculatePriceProducts(Client client)
        {
            int basketCost = 0;
            List<Product> products = client.Basket;

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

                if (client.CanPay(basketCost))
                {
                    client.RemoveRandomProduct();
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
        private List<Product> _bag;

        public int Money { get; private set; }

        public Client()
        {
            int minMoney = 500;
            int maxMoney = 1500;
            _shoppingBasket = new List<Product>();
            _bag = new List<Product>();

            Money = UserUtils.GetRandomNumber(maxMoney, minMoney);
        }
    
        public int ProductsCount => _shoppingBasket.Count();
        public List<Product> Basket => new List<Product>(_shoppingBasket);

        public bool CanPay(int basketCost)
        {
            return basketCost >= Money;
        }

        public void RemoveRandomProduct()
        {
            Product product = _shoppingBasket[UserUtils.GetRandomNumber(_shoppingBasket.Count)];
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

        public void FillBasket(List<Product> products)
        {
            foreach (var product in products)
            {
                _shoppingBasket.Add(product);
            }
        }
    
        private void TransferProductsToBag(List<Product> boughtProducts)
        {
            foreach (var product in boughtProducts)
            {
                _bag.Add(product);
            }
        
            boughtProducts.Clear();
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
    
    public class ClientFactory
    {
        private List<Product> _tempProducts;

        public Queue<Client> CreateClients(List<Product> products)
        {
            Queue<Client> clients = new Queue<Client>();
        
            int countOfClients = UserUtils.GetRandomNumber(10);

            for (int i = 0; i < countOfClients; i++)
            {
                clients.Enqueue(Create(products));
            }

            return clients;
        }

        private Client Create(List<Product> products)
        {
            Client client = new Client();

            CreateBasket(products);
        
            client.FillBasket(_tempProducts);

            return client;
        }

        private void CreateBasket(List<Product> products)
        {
            _tempProducts = new List<Product>();
        
            int minProducts = 5;
            int maxProducts = 15;

            int countOfProducts = UserUtils.GetRandomNumber(maxProducts, minProducts);

            for (int i = 0; i < countOfProducts; i++)
            {
                Product product = TakeRandomProduct(products);
                _tempProducts.Add(product);
            }
        }

        private Product TakeRandomProduct(List<Product> products)
        {
            int firstProduct = 0;
            int lastProduct = products.Count();
            int randomIndex = UserUtils.GetRandomNumber(lastProduct,firstProduct);

            return products[randomIndex];
        }
    }
    
    public static class UserUtils
    {
        private const int MinValue = 0;
        private const int MaxValue = 101;

        private static Random _random = new Random();

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(MinValue, max);
        }
    }
}
