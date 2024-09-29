using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Aviary> aviaries = new List<Aviary>()
                {new Aviary(), new Aviary(), new Aviary(), new Aviary(), new Aviary()};
            
            Zoo zoo = new Zoo(aviaries);

            zoo.ShowMenu();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;

        public Zoo(List<Aviary> aviaries)
        {
            _aviaries = new List<Aviary>();
            
            _aviaries = aviaries;
        }

        public void ShowMenu()
        {
            const int CommandExit = 0;
            bool isWorking = true;
            int index;
            
            while (isWorking)
            {
                Console.Clear();

                Console.WriteLine($"Welcome to Zoo!" +
                    $"\nWhich aviar do you want to chose?" +
                    $"\nPress number to chose:" +
                    $"\n{CommandExit}) Exit");

                ShowAllAviary();

                index = UserUtils.GetIndex(_aviaries.Count);
                
                if (index > 0)
                    _aviaries[index - 1].ShowInfo();
                else
                    isWorking = false;

                Console.ReadLine();
            }
        }

        private void ShowAllAviary()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_aviaries[i].Name}");
            }
        }
    }

    class Aviary
    {
        private Animal _typeOfAnimal;
        private List<Animal> _animals;
        private int _femaleCount;
        private int _maleCount;

        public Aviary()
        {
            AddAnimals();
            CountAnimalGender();
            Name = _typeOfAnimal.Name;
        }
        
        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.Clear();

            Console.WriteLine($"Aviary:\n{_typeOfAnimal.Name} - {_typeOfAnimal.Discription}." +
                $"\nAnimals:{_animals.Count()}\tMale: {_maleCount}\tFemale: {_femaleCount}");
            _typeOfAnimal.MakeSound();
        }

        private void AddAnimals()
        {
            _typeOfAnimal = UserUtils.GetRandomAnimal();
            int minAnimals = 5;
            int maxAnimals = 15;
            int _countOfAnimalsToCreate = UserUtils.GetRandomNumber(maxAnimals, minAnimals);
            _animals = new List<Animal>();
            
            for (int i = 0; i < _countOfAnimalsToCreate; i++)
            {
                _animals.Add(_typeOfAnimal.Copy());
            }
        }

        private void CountAnimalGender()
        {
            foreach (var animal in _animals)
            {
                if (animal.Gender == Gender.Male)
                    _maleCount++;
                else
                    _femaleCount++;
            }
        }
    }

    public abstract class Animal
    {
        protected Animal(string name, string sound, string discription)
        {
            Discription = discription;
            Name = name;
            Sound = sound;
            Gender = UserUtils.GetRandomGender();
        }
        
        public string Name { get; private set; }
        public string Discription { get; private set; }
        public string Sound { get; private set; }
        public Gender Gender { get; private set; }

        public void MakeSound()
        {
            Console.Write($"Make sound {Sound}");
        }

        public abstract Animal Copy();
    }
    
    public static class UserUtils
    {
        private const int MinValue = 0;
        private const int _chanseChose = 100;
        private const int _halfChanse = 50;
        private const int _male = 0;
        private const int _female = 1;

        private static List<Animal> _allAnimals;

        private static Random _random = new Random();

        public static Animal GetRandomAnimal()
        {
            _allAnimals = new List<Animal>()
                {new Cat(), new Dog(), new Cow(), new Mouse(), new Fox()};
            
            return _allAnimals[GetRandomNumber(_allAnimals.Count)];
        }

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(min, max);
        }

        public static Gender GetRandomGender()
        {
            Gender gender;

            return gender = GetRandomNumber(_chanseChose) > _halfChanse ? Gender.Male : Gender.Female;
        }
    
        public static int GetIndex(int maxAvaries)
        {
            int index = 1;

            do
            {
                Console.WriteLine("Enter correct index: ");
            } while (int.TryParse(Console.ReadLine(), out index) == false || index > maxAvaries || index < 0);

            return index;
        }
    }

    class Cat : Animal
    {
        public Cat() : base("Cat", "Meow", "The cat (Felis catus) is a domestic species of small carnivorous mammal") { }
        
        public override Animal Copy()
        {
            return new Cat();
        }
    }

    class Dog : Animal
    {
        public Dog() : base("Dog", "Bark", "The dog (Canis familiaris or Canis lupus familiaris) is a domesticated descendant of the wolf") { }
        
        public override Animal Copy()
        {
            return new Dog();
        }
    }

    class Cow : Animal
    {
        public Cow() : base("Cow", "Moo", "Cows are peaceful animals. They are vegetarians and eat grass, giving people milk") { }
        
        public override Animal Copy()
        {
            return new Cow();
        }
    }

    class Mouse : Animal
    {
        public Mouse() : base("Mouse", "Squeak", "Characteristically, mice are known to have a pointed snout, small rounded ears, a body-length scaly tail, and a high breeding rate") { }
        
        public override Animal Copy()
        {
            return new Mouse();
        }
    }

    class Fox : Animal
    {
        public Fox() : base("Fox", "What does the fox say?", "The fox has triangular face, dark pricked ears, black eyes and elongated muzzle. Its whiskers are black the body is red and the lower part of the face and the chest are white. It has a bushy tail.") { }
        
        public override Animal Copy()
        {
            return new Fox();
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
