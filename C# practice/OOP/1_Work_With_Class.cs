using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player1 = new Player("Artorias", 100, 20, 9);
            Player player2 = new Player("Sif", 100, 20, 9);

            player1.ShowInfo();

            player2.ShowInfo();
        }
    }
    class Player
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public Player(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя персонажа - {_name}" +
                $"\nЖизни - {_health}" +
                $"\nУрон - {_damage}" +
                $"\nЗащита - {_armor}");
        }
    }
}
