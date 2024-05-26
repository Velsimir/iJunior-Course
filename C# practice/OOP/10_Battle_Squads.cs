using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Country country1 = new Country();
            Country country2 = new Country();
            Battlefield battlefield = new Battlefield();

            battlefield.FighеСountries(country1, country2);
        }
    }

    class Barrack
    {
        public Soldier GetSoldier()
        {
            List<Soldier> allSoldiers = new List<Soldier>();
            Random random = new Random();

            CreateSoldiers(allSoldiers);

            int soldier = (allSoldiers.Count);

            return allSoldiers[soldier];
        }

        private void CreateSoldiers(List<Soldier> allSoldiers)
        {
            allSoldiers.Add(new Specialist());
            allSoldiers.Add(new Corporal());
            allSoldiers.Add(new Sergeant());
            allSoldiers.Add(new StaffSergeant());
            allSoldiers.Add(new MasterSergeant());
            allSoldiers.Add(new FirstSergeant());
        }
    }

    abstract class Soldier
    {
        protected int NecessaryChanceOfSuccess = 50;

        public int HealthPoint { get; protected set; }
        public int RagePoint { get; protected set; }
        public int AttackPower { get; protected set; }
        public int SpellChance { get; protected set; }
        public string Rank { get; private set; }

        protected Soldier(int healthPoint, int ragePoint, int physicalAttack, string rank)
        {
            HealthPoint = healthPoint;
            RagePoint = ragePoint;
            AttackPower = physicalAttack;
            Rank = rank;
        }

        public void ShowRank()
        {
            Console.WriteLine(Rank);
        }

        public virtual void Attack(Soldier enemyFighter)
        {
            Console.WriteLine($"Наносит обычный удар в {AttackPower} единиц урона");
            enemyFighter.TakeDamage(AttackPower);
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoint -= damage;
        }
    }

    class Specialist : Soldier
    {
        private Random _random = new Random();

        public Specialist() : base(126, 100, 4, "Specialist") { }

        public override void Attack(Soldier enemyFighter)
        {
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastMultiplierAttack());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        private int CastMultiplierAttack()
        {
            int rageCost = 10;

            if (RagePoint >= rageCost)
            {
                int minCritical = 1;
                int maxCritical = 4;
                int criticalMultiplier = _random.Next(minCritical, maxCritical);
                int damage;

                Console.Write("Использует Critical Attack| ");

                damage = criticalMultiplier * AttackPower;
                RagePoint -= rageCost;

                Console.WriteLine($" и наносит противнику {damage} единиц урона!");

                return damage;
            }

            Console.WriteLine($" Не хватает ярости! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class Corporal : Soldier
    {
        private Random _random = new Random();

        public Corporal() : base(90, 100, 7, "Corporal") { }

        public override void Attack(Soldier enemyFighter)
        {
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastMagicSpell());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        public override void TakeDamage(int damage)
        {
            HealthPoint -= damage;
        }

        private int CastMagicSpell()
        {
            int rageCost = 20;
            int spellDamage = 18;
            int damage;

            if (RagePoint >= rageCost)
            {
                Console.Write("Использует Wind Strike");

                damage = spellDamage + AttackPower;

                Console.WriteLine($" и наносит противнику {damage} единиц урона!");

                RagePoint -= rageCost;

                return damage;
            }

            Console.WriteLine($" Не хватает ярости! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class Sergeant : Soldier
    {
        private Random _random = new Random();

        public Sergeant() : base(133, 100, 4, "Sergeant") { }

        public override void Attack(Soldier enemyFighter)
        {
            int rageCost = 20;
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess && RagePoint > rageCost)
            {
                enemyFighter.TakeDamage(CastMortalBlow(enemyFighter));
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        private int CastMortalBlow(Soldier fighter)
        {
            int spellDamage = 8;
            int damage;
            int killerChanse = _random.Next(10);
            int escessaryKillerChanse = 1;

            Console.Write("Использует Mortal Blow");

            if (killerChanse == escessaryKillerChanse)
            {
                damage = fighter.HealthPoint - 1;
                Console.WriteLine($" и наносит противнику {damage} единиц урона!!!!");
                return damage;
            }

            damage = spellDamage + AttackPower;

            Console.WriteLine($" и наносит противнику {damage} единиц урона!");
            return damage;
        }
    }

    class StaffSergeant : Soldier
    {
        private Random _random = new Random();

        public StaffSergeant() : base(105, 100, 4, "StaffSergeant") { }

        public override void Attack(Soldier enemyFighter)
        {
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastHeal());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        private int CastHeal()
        {
            int rageCost = 40;
            int lowHealth = 40;

            if (RagePoint >= rageCost && HealthPoint < lowHealth)
            {
                int heal = _random.Next(10, 25);
                int damage;

                Console.Write("Использует Heal| ");

                damage = AttackPower;
                HealthPoint += heal;
                RagePoint -= rageCost;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также восстанавливает {heal} единиц здоровья");

                return damage;
            }

            Console.WriteLine($" Не хватает ярости! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class MasterSergeant : Soldier
    {
        private Random _random = new Random();
        private bool _isEvade;


        public MasterSergeant() : base(133, 100, 4, "MasterSergeant") { }

        public override void Attack(Soldier enemyFighter)
        {
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastDodge());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        public override void TakeDamage(int damage)
        {
            if (_isEvade == false)
            {
                HealthPoint -= damage;
            }
            else
            {
                Console.WriteLine(" | Уворот!");
            }
        }

        private int CastDodge()
        {
            int rageCost = 10;
            _isEvade = false;

            if (RagePoint >= rageCost)
            {
                _isEvade = true;
                int damage;

                Console.Write("Использует Dodge| ");

                damage = AttackPower;
                RagePoint -= rageCost;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также готовиться увернуться от следующего удара");

                return damage;
            }

            Console.WriteLine($" Не хватает ярости! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class FirstSergeant : Soldier
    {
        private int _spellChanse;
        private Random _random = new Random();
        private bool _isEvade;

        public FirstSergeant() : base(96, 100, 4, "FirstSergeant") { }

        public override void Attack(Soldier enemyFighter)
        {
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastDisembodied());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        public override void TakeDamage(int damage)
        {
            if (_isEvade == false)
            {
                HealthPoint -= damage;
            }
            else
            {
                Console.WriteLine(" | Удар прошел насквозь!");
            }
        }

        private int CastDisembodied()
        {
            int rageCost = 20;
            _isEvade = false;

            if (RagePoint >= rageCost)
            {
                int damage;
                _isEvade = true;

                Console.Write("Использует Disembodied| ");

                damage = AttackPower + rageCost;
                RagePoint -= rageCost;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также его тело стало прозрачным");

                return damage;
            }

            Console.WriteLine($" Не хватает ярости! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class Country
    {
        private Queue<Soldier> _platoon;
        private int _maxSoldiersInPlatoon = 10;

        public Country()
        {
            _platoon = new Queue<Soldier>();

            CreatePlatoon();
        }

        public void ShowPlatoon(int positionY, int positionX)
        {
            foreach (var soldier in _platoon)
            {
                Console.SetCursorPosition(positionY, positionX);

                soldier.ShowRank();

                positionX++;
            }
        }

        public void DeleteDeadSoldier(Soldier soldier)
        {
            if (soldier.HealthPoint <= 0)
            {
                _platoon.Dequeue();
            }
        }

        public Soldier GetSoldier()
        {
            return _platoon.Peek();
        }

        public bool IsPlatoonAnySolder()
        {
            return (_platoon.Count > 0);
        }

        private void CreatePlatoon()
        {
            Barrack barrack = new Barrack();

            for (int i = 0; i < _maxSoldiersInPlatoon; i++)
            {
                _platoon.Enqueue(barrack.GetSoldier());
            }
        }
    }

    class Battlefield
    {
        public void FighеСountries(Country country1, Country country2)
        {
            while (country1.IsPlatoonAnySolder() == true && country2.IsPlatoonAnySolder() == true)
            {
                Console.Clear();

                ShowStatusPlatoons(country1, country2);

                Soldier soldier1 = country1.GetSoldier();
                Soldier soldier2 = country2.GetSoldier();

                FightSoldiers(soldier1, soldier2);

                country1.DeleteDeadSoldier(soldier1);
                country2.DeleteDeadSoldier(soldier2);
            }

            ShowResult(country1, country2);

            Console.ReadKey();
        }

        private void ShowResult(Country country1, Country country2)
        {
            if (country1.IsPlatoonAnySolder() == false && country2.IsPlatoonAnySolder() == false)
            {
                Console.WriteLine("Обе страны потерпели поражение");
            }
            else if (country1.IsPlatoonAnySolder() == false)
            {
                Console.WriteLine("Страна 2 одержала победу");
            }
            else if (country2.IsPlatoonAnySolder() == false)
            {
                Console.WriteLine("Страна 1 одержала победу");
            }
        }

        private void ShowStatusPlatoons(Country country1, Country country2)
        {
            country1.ShowPlatoon(0, 0);
            country2.ShowPlatoon(20, 0);
            Console.WriteLine();
        }

        private void FightSoldiers(Soldier soldier1, Soldier soldier2)
        {
            while (soldier1.HealthPoint > 0 && soldier2.HealthPoint > 0)
            {
                Console.WriteLine("Солдат 1: ");
                soldier1.Attack(soldier2);

                Console.WriteLine("Солдат 2: ");
                soldier2.Attack(soldier1);

                Console.ReadKey();
            }
        }
    }
}
