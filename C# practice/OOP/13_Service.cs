using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using System.Threading.Channels;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
         * У вашего автосервиса есть баланс денег и склад деталей.
         * Когда приезжает автомобиль, у него сразу ясна его поломка, 
         * и эта поломка отображается у вас в консоли вместе 
         * с ценой за починку(цена за починку складывается из цены детали + цена за работу).
         * Поломка всегда чинится заменой детали, но количество деталей ограничено тем, 
         * что находится на вашем складе деталей.Если у вас нет нужной детали на складе, 
         * то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
         * Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
         * За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.
         * Класс Деталь не может содержать значение “количество”. 
         * Деталь всего одна, за количество отвечает тот, кто хранит детали. 
         * При необходимости можно создать дополнительный класс для конкретной детали и работе с количеством.
         */
        public static void Main(string[] args)
        {
            const string CommandYes = "y";
            const string CommandNo = "n";
            const string CommandExit = "e";

            bool isWorking = true;
            string userInput;
            Service service = new Service();

            while (isWorking)
            {
                Console.Clear();

                Console.WriteLine($"Счет автосервиса: {service.Money}" +
                    $"\nХотите обслужить текущего клиента?" +
                    $"\n{CommandYes} - Да" +
                    $"\n{CommandNo} - Нет" +
                    $"\n{CommandExit} - Выход");

                service.ShowCarDetails();

                userInput = Console.ReadLine();

                Console.Clear();

                service.ShowCarDetails();

                switch (userInput)
                {
                    case CommandYes:
                        service.ChangeDetail();
                        break;

                    case CommandNo:
                        service.InviteNewClient();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }

                if (service.Money < 0)
                {
                    isWorking = false;

                    Console.WriteLine("Ваш автосервис остался без средств :(");
                    Console.ReadKey();
                }
            }
        }

        class Client
        {
            private Car _car;

            public Client()
            {
                _car = new Car();
            }

            public Car GiveCar()
            {
                return _car;
            }
        }

        class Car
        {
            private List<Detail> _details;

            public Car()
            {
                _details = new List<Detail>();

                CreateListDetails();
            }

            public void ChangeDetail(Detail detailNew)
            {
                Detail detailToChange = null;

                foreach (var detailCar in _details)
                {
                    if (detailCar.Name == detailNew.Name)
                    {
                        detailToChange = detailCar;
                    }
                }

                _details.Remove(detailToChange);
                _details.Add(detailNew);
            }

            public List<Detail> GetDetails()
            {
                List<Detail> allDetails = new List<Detail>();

                foreach (var detail in _details)
                {
                    allDetails.Add(detail);
                }

                return allDetails;
            }

            private void CreateListDetails()
            {
                _details.Add(new WindScreenWiper());
                _details.Add(new Wheel());
                _details.Add(new Bumper());
                _details.Add(new Door());
            }
        }

        class Warehouse
        {
            private Queue<Detail> _windScreenWipers;
            private Queue<Detail> _wheels;
            private Queue<Detail> _bumpers;
            private Queue<Detail> _doors;
            private int _maxPlaces = 10;

            public Warehouse()
            {
                _windScreenWipers = new Queue<Detail>();
                _wheels = new Queue<Detail>();
                _bumpers = new Queue<Detail>();
                _doors = new Queue<Detail>();

                for (int i = 0; i < _maxPlaces; i++)
                {
                    Fill(TypeOfDetail.windScreenWiper);
                    Fill(TypeOfDetail.wheel);
                    Fill(TypeOfDetail.bumper);
                    Fill(TypeOfDetail.door);
                }
            }

            public bool TryGetDetail(TypeOfDetail typeOfDetail)
            {
                switch (typeOfDetail)
                {
                    case TypeOfDetail.windScreenWiper:
                        return 0 < _windScreenWipers.Count;

                    case TypeOfDetail.bumper:
                        return 0 < _bumpers.Count;

                    case TypeOfDetail.wheel:
                        return 0 < _wheels.Count;

                    case TypeOfDetail.door:
                        return 0 < _doors.Count;
                }

                return typeOfDetail == null;
            }

            public Detail SwitchDetail(TypeOfDetail typeOfDetail)
            {
                Detail detail = null;

                switch (typeOfDetail)
                {
                    case TypeOfDetail.windScreenWiper:
                        return _windScreenWipers.Dequeue();

                    case TypeOfDetail.bumper:
                        return _bumpers.Dequeue();

                    case TypeOfDetail.wheel:
                        return _wheels.Dequeue();

                    case TypeOfDetail.door:
                        return _doors.Dequeue();
                }

                return detail;
            }

            public TypeOfDetail ChoseDetail()
            {
                string userInputString;
                int userInputInt;

                do
                {
                    do
                    {
                        ShowMenu();

                        userInputString = Console.ReadLine();

                    } while (int.TryParse(userInputString, out userInputInt) == false);

                } while ((userInputInt < 1 || userInputInt > Enum.GetNames(typeof(TypeOfDetail)).Length));

                return (TypeOfDetail)userInputInt;
            }

            private void Fill(TypeOfDetail typeOfDetail)
            {
                switch (typeOfDetail)
                {
                    case TypeOfDetail.windScreenWiper:
                        AddDetail(_windScreenWipers, new WindScreenWiper(true));
                        break;

                    case TypeOfDetail.bumper:
                        AddDetail(_bumpers, new Bumper(true));
                        break;

                    case TypeOfDetail.wheel:
                        AddDetail(_wheels, new Wheel(true));
                        break;

                    case TypeOfDetail.door:
                        AddDetail(_doors, new Door(true));
                        break;
                }
            }

            private void ShowMenu()
            {
                Console.WriteLine("\nКакую деталь для замены взять со склада?");
                Console.WriteLine($"{TypeOfDetail.windScreenWiper.GetHashCode()} - Дворники (остаток на складе {_windScreenWipers.Count})" +
                    $"\n{TypeOfDetail.wheel.GetHashCode()} - Колесо (остаток на складе {_wheels.Count})" +
                    $"\n{TypeOfDetail.bumper.GetHashCode()} - Бампер (остаток на складе {_bumpers.Count})" +
                    $"\n{TypeOfDetail.door.GetHashCode()} - Дверь (остаток на складе {_doors.Count})");
            }

            private void AddDetail(Queue<Detail> details, Detail detail)
            {
                if (details.Count < _maxPlaces)
                {
                    details.Enqueue(detail);
                }
            }
        }

        class Service
        {
            private Warehouse _warehouse;
            private int _costWork = 40;
            private int _compensation = 20;
            private Client _client;
            private Car _carClient;
            private List<Detail> _detailsToRepair;

            public int Money { get; private set; } = 100;

            public Service()
            {
                _warehouse = new Warehouse();
                _detailsToRepair = new List<Detail>();

                InviteNewClient();
            }

            public void InviteNewClient()
            {
                _client = new Client();
                _carClient = _client.GiveCar();
                _detailsToRepair = _carClient.GetDetails();
            }

            public void ShowCarDetails()
            {
                _detailsToRepair = _carClient.GetDetails();

                Console.WriteLine("\nДетали в машине клиента:");
                for (int i = 0; i < _detailsToRepair.Count(); i++)
                {
                    if (_detailsToRepair[i].IsWorkable == false)
                    {
                        Console.WriteLine($"{i + 1}) Деталь - {_detailsToRepair[i].Name} | Статус - сломано " +
                            $"| Цена замены {_detailsToRepair[i].Cost} (дополнительно за работу {_costWork})");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}) Деталь - {_detailsToRepair[i].Name} | Статус - целое");
                    }
                }
            }

            public void ChangeDetail()
            {
                Detail detail;

                TypeOfDetail typeOfDetail = _warehouse.ChoseDetail();

                if (_warehouse.TryGetDetail(typeOfDetail))
                {
                    detail = _warehouse.SwitchDetail(typeOfDetail);

                    if (CancelChange(detail) == false)
                    {
                        _carClient.ChangeDetail(detail);

                        Money += detail.Cost + _costWork;
                    }
                    else
                    {
                        Console.WriteLine($"Вы заменили рабочую деталь! Выплата комепенсации в размере {detail.Cost + _compensation}");
                        PayCompensation(detail.Cost + _compensation);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"Детали нет на складе, мы выплатили компенсацию в размере {_compensation}");
                    PayCompensation(_compensation);
                    Console.ReadKey();
                }
            }

            private bool CancelChange(Detail detailService)
            {
                foreach (var detailCar in _detailsToRepair)
                {
                    if (detailCar.Name == detailService.Name)
                    {
                        return detailCar.IsWorkable;
                    }
                }

                return false;
            }

            private void PayCompensation(int cost)
            {
                Money -= cost;
            }
        }
    }

    abstract class Detail
    {
        private Random _random = new Random();
        private int _maxPercent = 100;

        public string Name { get; private set; }
        public int Cost { get; private set; }
        public bool IsWorkable { get; private set; }

        protected Detail(string name, int cost, bool isNew = false)
        {
            if (isNew == false)
            {
                SetWorkableStatus();
            }
            else
            {
                IsWorkable = true;
            }

            Name = name;
            Cost = cost;
        }

        private void SetWorkableStatus()
        {
            int brokenChanse = _random.Next(_maxPercent);
            int necessaryСhance = 50;

            if (brokenChanse > necessaryСhance)
            {
                IsWorkable = false;
            }
            else
            {
                IsWorkable = true;
            }
        }
    }

    class WindScreenWiper : Detail
    {
        public WindScreenWiper(bool isNew = false) : base("Дворники", 100, isNew) { }
    }

    class Wheel : Detail
    {
        public Wheel(bool isNew = false) : base("Колесо", 200, isNew) { }
    }

    class Bumper : Detail
    {
        public Bumper(bool isNew = false) : base("Бампер", 300, isNew) { }
    }

    class Door : Detail
    {
        public Door(bool isNew = false) : base("Дверь", 500, isNew) { }
    }

    enum TypeOfDetail { windScreenWiper = 1, wheel, bumper, door }
}
