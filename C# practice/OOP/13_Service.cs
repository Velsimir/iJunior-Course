using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DetailCreator detailCreator = new DetailCreator();

            Service service = new Service(detailCreator);
            
            service.Work();
        }
    }

    class Car
    {
        private DetailCreator _detailCreator;
        private List<Detail> _details;

        public Car(DetailCreator detailCreator)
        {
            _detailCreator = detailCreator;
            CreateListDetails();
        }
        
        public List<Detail> Details => _details.ToList();

        public bool GetDetailStatusWorkable(Detail serchingDetail)
        {
            foreach (var detail in _details)
            {
                if (detail.Name == serchingDetail.Name)
                    return detail.IsWorkable;
            }

            return false;
        }

        public void ChangeDetail(Detail newDetail)
        {
            Detail detailToChange = null;

            foreach (var detailCar in _details)
            {
                if (detailCar.Name == newDetail.Name)
                {
                    detailToChange = detailCar;
                    break;
                }
            }

            _details.Remove(detailToChange);
            _details.Add(newDetail);
        }

        private void CreateListDetails()
        {
            _details = new List<Detail>();
            
            _details = _detailCreator.GetAllForCar();
        }
    }

    class Warehouse
    {
        private DetailCreator _detailCreator;
        private Dictionary<string, Queue<Detail>> _details;
        private int _maxPlaces = 10;

        public Warehouse(DetailCreator detailCreator)
        {
            _detailCreator = detailCreator;
            _details = new Dictionary<string, Queue<Detail>>();
            
            Fill();
        }

        public void Fill()
        {
            int randomDetailsMax = 10;
            int randomDetailsMin = 5;
            
            for (int i = 0; i < UserUtils.GetRandomNumber(randomDetailsMax, randomDetailsMin); i++)
            {
                AddDetails(OrderDetails());
            }
        }
        
        public bool TryGetDetail(out Detail detail)
        {
            const string CommandNo = "нет";
            string userInput;
            Console.WriteLine("Введите название детали, чтобы ее заказать: " +
                              "\n(если детали нет на складе, напишите - нет)");
            
            ShowDetails();

            do
            {
                userInput = Console.ReadLine();
            } while (TryFindDetail(userInput) == false && userInput != CommandNo);

            if (userInput == CommandNo)
            {
                detail = null;
                return false;
            }
            else
            {
                detail = _details[userInput].Dequeue();
                DeletePosition(userInput);
                return true;
            }
            
        }

        private Queue<Detail> OrderDetails()
        {
            int minDetails = 1;
            
            Detail detail = _detailCreator.GetRandomNew();
            Queue<Detail> tempDetails = new Queue<Detail>();

            for (int i = 0; i < UserUtils.GetRandomNumber(_maxPlaces, minDetails); i++)
            {
                tempDetails.Enqueue(detail);
            }
            
            return tempDetails;
        }

        private void AddDetails(Queue<Detail> details)
        {
            if (TryFindDetail(details.Peek().Name))
            {
                for (int i = 0; i < details.Count; i++)
                {
                    _details[details.Peek().Name].Enqueue(details.Dequeue());
                }
            }
            else
            {
                _details.Add(details.Peek().Name, details);
            }
        }

        private bool TryFindDetail(string name)
        {
            foreach (var detail in _details)
            {
                if (detail.Key == name)
                    return true;
            }
            
            return false;
        }

        private void ShowDetails()
        {
            foreach (var detail in _details)
            {
                Console.WriteLine($"{detail.Key} на складе осталось = {detail.Value.Count}");
            }
        }

        private void DeletePosition(string detail)
        {
            if (_details[detail].Count == 0)
                _details.Remove(detail);
        }
    }

    class Service
    {
        private Warehouse _warehouse;
        private DetailCreator _detailCreator;
        private int _costWork = 400;
        private int _compensation = 200;
        private Queue<Car> _cars;

        public Service(DetailCreator detailCreator)
        {
            _warehouse = new Warehouse(_detailCreator);
            _detailCreator = detailCreator;
            _cars = new Queue<Car>();

            InviteNewClients();
        }
        
        public int Money { get; private set; } = 100;

        public void Work()
        {
            const string CommandYes = "Обслужить";
            const string CommandNo = "Пропустить";
            const string CommandOrder = "Заказать";
            const string CommandExit = "Выход";
        
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                
                Console.WriteLine($"Счет автосервиса: {Money}" +
                                  $"\nХотите обслужить текущего клиента? Или заказать детали?" +
                                  $"\n{CommandYes}" +
                                  $"\n{CommandNo}" +
                                  $"\n{CommandOrder}" +
                                  $"\n{CommandExit}");

                ShowCarDetails();
                
                switch (Console.ReadLine())
                {
                    case CommandYes:
                        ChangeDetail();
                        break;

                    case CommandNo:
                        SkipClient();
                        break;
                    
                    case CommandOrder:
                        _warehouse.Fill();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }
                
                Console.Clear();

                if (Money < 0)
                {
                    isWork = false;

                    Console.WriteLine("Ваш автосервис остался без средств :(");
                    Console.ReadKey();
                }
            }
        }

        public void InviteNewClients()
        {
            int maxClients = 10;
            int minClients = 1;
            
            for (int i = 0; i < UserUtils.GetRandomNumber(maxClients, minClients); i++)
            {
                _cars.Enqueue(new Car(_detailCreator));
            }
        }
        
        public void SkipClient()
        {
            if (_cars.Count > 0)
                _cars.Dequeue();
        }
        
        public void ShowCarDetails()
        {
            Console.WriteLine("\nДетали в машине:");

            foreach (var detail in _cars.Peek().Details)
            {
                if (detail.IsWorkable == false)
                {
                    Console.WriteLine($"Деталь - {detail.Name} | Статус - сломано " +
                                      $"| Цена замены {detail.Cost} (дополнительно за работу {_costWork})");
                }
                else
                {
                    Console.WriteLine($"Деталь - {detail.Name} | Статус - целое");
                }
            }
        }

        public void ChangeDetail()
        {
            Detail detail;

            if (_warehouse.TryGetDetail(out detail))
            {
                if (_cars.Peek().GetDetailStatusWorkable(detail))
                {
                    Console.WriteLine($"Вы заменили рабочую деталь! Выплата комепенсации в размере {detail.Cost + _compensation}");
                    PayCompensation(detail.Cost + _compensation);
                    Console.ReadKey();
                }
                else
                {
                    _cars.Peek().ChangeDetail(detail);

                    Money += detail.Cost + _costWork;
                }
            }
            else
            {
                Console.WriteLine($"Детали нет на складе, мы выплатили компенсацию в размере {_compensation}");
                PayCompensation(_compensation);
                Console.ReadKey();
            }
        }

        private void PayCompensation(int cost)
        {
            Money -= cost;
        }
    }

    class Detail
    {
        public  Detail(string name, int cost, bool isWorkable = true)
        {
            Name = name;
            Cost = cost;
            IsWorkable = isWorkable;
        }
        
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public bool IsWorkable { get; private set; }

        public void Broke()
        {
            IsWorkable = false;
        }

        public void Repair()
        {
            IsWorkable = true;
        }

        public Detail Copy()
        {
            return new Detail(Name, Cost);
        }
    }

    class DetailCreator
    {
        private int _maxPercent = 100;
        private List<Detail> _details;

        public DetailCreator()
        {
            Fill();
        }

        public Detail GetRandomNew()
        {
            int minIndex = 1;
            int index = UserUtils.GetRandomNumber(_details.Count, minIndex);
            
            return _details[index - 1].Copy();
        }
        
        public List<Detail> GetAllForCar()
        {
            List<Detail> tempDetail = _details.ToList();

            foreach (var detail in tempDetail)
            {
                if (GetWorkableStatus())
                    detail.Repair();
                else
                    detail.Broke();
            }

            return tempDetail;
        }

        public void Fill()
        {
            _details = new List<Detail>();
            
            _details.Add(new Detail("Дверь", 1000));
            _details.Add(new Detail("Колесо", 750));
            _details.Add(new Detail("Дворники", 350));
            _details.Add(new Detail("Зеркало заднего вида", 250));
            _details.Add(new Detail("Двигатель", 4000));
            _details.Add(new Detail("Стекла", 600));
        }

        private bool GetWorkableStatus()
        {
            int brokenChanse = UserUtils.GetRandomNumber(_maxPercent);
            int necessaryСhance = 50;

            if (brokenChanse > necessaryСhance)
                return false;
            else
                return true;
        }
    }

    public static class UserUtils
    {
        private const int MinValue = 0;

        private static Random s_random = new Random();

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return s_random.Next(min, max);
        }
    }
}
