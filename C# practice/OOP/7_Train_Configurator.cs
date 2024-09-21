using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandCreateRace = "Да";
            const string CommandExit = "Нет";

            bool isWorking = true;
            string userInput;
            Dispetcher dispetcher = new Dispetcher();

            while (isWorking)
            {
                Console.Clear();

                dispetcher.ShowInfo();

                Console.WriteLine("Хотите принять пассажиров на рейс?");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCreateRace:
                        dispetcher.CreateRoute();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный воод...");
                        break;
                }
            }
        }
    }
        
    class RailwayCarriage
    {
        private List<int> _passengers = new List<int>();
        private int _minPlaces = 10;
        private int _maxPlaces = 20;

        public RailwayCarriage()
        {
            FreePlaces = new Random().Next(_minPlaces, _maxPlaces);
        }

        public int FreePlaces { get; private set; }

        public void SeatPassengers(int passengers)
        {
            for (int i = 0; i < passengers; i++)
            {
                _passengers.Add(i + 1);
            }
        }
    }

    class Train
    {
        private List<RailwayCarriage> _railwayCarriages;

        public Train(int passengers)
        {
            _railwayCarriages = new List<RailwayCarriage>();

            AddRailwayCarriages(passengers);
        }

        public int GetCountRailwayCarriages()
        {
            return _railwayCarriages.Count;
        }

        private void AddRailwayCarriages(int passengers)
        {
            while (passengers > 0)
            {
                RailwayCarriage railwayCarriage = new RailwayCarriage();
                int countMaxPassengers;

                if (railwayCarriage.FreePlaces < passengers)
                {
                    countMaxPassengers = railwayCarriage.FreePlaces;
                    passengers -= railwayCarriage.FreePlaces;
                }
                else
                {
                    countMaxPassengers = passengers;
                    passengers = 0;
                }

                _railwayCarriages.Add(railwayCarriage);

                railwayCarriage.SeatPassengers(countMaxPassengers);
            }
        }
    }

    class Route
    {
        private Train _train;

        public Route(int id, Direction direction, int passengers)
        {
            Id = id;
            CountOfPassengers = passengers;
            Direction = direction;
            _train = new Train(passengers);
        }

        public int Id { get; private set; }
        public int CountOfPassengers { get; private set; }
        public Direction Direction { get; private set; }

        public int GetCountRailwayCarriages()
        {
            return _train.GetCountRailwayCarriages();
        }
    }

    class Dispetcher
    {
        private List<Route> _routes = new List<Route>();
        private int _idTrain = 1;
        private CreatorOfPeople _creator = new CreatorOfPeople();

        public void CreateRoute()
        {
            Route route = new Route(_idTrain, ChoseDirection(), _creator.Generate());

            _routes.Add(route);

            _idTrain++;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Рейс\t\tНаправление\t\tКоличество вагонов\t\tКоличество пассажиров");

            if (_routes.Count() > 0)
            {
                foreach (var route in _routes)
                {
                    Console.WriteLine($"{route.Id}\t\t{route.Direction.From}-{route.Direction.To}" +
                                      $"\t\t{route.GetCountRailwayCarriages()}\t\t{route.CountOfPassengers}");
                }
            }
            else
            {
                Console.WriteLine("В настоящий момент маршрутов нет");
            }
        }

        private Direction ChoseDirection()
        {
            string from;
            string to;

            Console.WriteLine("С какой станции вы хотите отправиться?");
            from = Console.ReadLine();

            Console.WriteLine("В какой город планируете поездку?");
            to = Console.ReadLine();

            return new Direction(from, to);
        }
    }

    class CreatorOfPeople
    {
        private Random _random = new Random();
        private int _minPassengers = 1;
        private int _maxPassengers = 1001;

        public int Generate()
        {
            return Passengers = _random.Next(_minPassengers, _maxPassengers);
        }
        
        public int Passengers { get; private set; }
    }

    struct Direction
    {
        public Direction(string from, string to)
        {
            From = from;
            To = to;
        }
        
        public string From { get; private set; }
        public string To { get; private set; }
    }
}
