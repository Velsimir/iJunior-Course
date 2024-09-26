using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
        }
    }
    
    public class Battlefield
    {
        public void FightPlatoons(Platoon platoon1, Platoon platoon2)
        {
            ShowStatusPlatoons(platoon1, platoon2);
        
            while (platoon1.IsPlatoonAnySolder && platoon2.IsPlatoonAnySolder)
            {
                FightSoldiers(platoon1, platoon2);
                platoon1.DeleteDeadSoldier();

                if (platoon1.IsPlatoonAnySolder)
                {
                    FightSoldiers(platoon2, platoon1);
                    platoon2.DeleteDeadSoldier();
                }
            }

            ShowResult(platoon1, platoon2);
        }

        private void ShowResult(Platoon country1, Platoon country2)
        {
            if (country1.IsPlatoonAnySolder == false && country2.IsPlatoonAnySolder == false)
            {
                Console.WriteLine("Оба отряда потерпели поражение");
            }
            else if (country1.IsPlatoonAnySolder == false)
            {
                Console.WriteLine("Отряд 2 одержал победу");
            }
            else if (country2.IsPlatoonAnySolder == false)
            {
                Console.WriteLine("Отряд 1 одержал победу");
            }
        }

        private void ShowStatusPlatoons(Platoon country1, Platoon country2)
        {
            Console.WriteLine("Первый отряд:");
            country1.ShowPlatoon();
        
            Console.WriteLine();
        
            Console.WriteLine("Второй отряд:");
            country2.ShowPlatoon();
        
            Console.WriteLine();
        }

        private void FightSoldiers(Platoon platoon1, Platoon platoon2)
        {
            foreach (var soldier in platoon1.Soldiers)
            {
                if (soldier.CanMultiHit)
                    soldier.AttackMultyTarget(platoon2.Soldiers);
                else
                    soldier.AttackSoloTarget(platoon2.GetRandomSoldier());
            }
        }
    }
    
    public class Barrack
    {
        private List<Soldier> _soldiers;

        public Barrack()
        {
            _soldiers = new List<Soldier>();
        
            CreateSoldiers();
        }

        public Soldier GetSoldier()
        {
            return _soldiers[UserUtils.GetRandomNumber(_soldiers.Count)];
        }

        private void CreateSoldiers()
        {
            _soldiers.Add(new Specialist());
            _soldiers.Add(new Corporal());
            _soldiers.Add(new Sergeant());
            _soldiers.Add(new StaffSergeant());
        }
    }
    
    public class Platoon
    {
        private List<Soldier> _soldiers;
        private int _maxSoldiersInPlatoon = 10;

        public Platoon()
        {
            _soldiers = new List<Soldier>();

            CreatePlatoon();
        }

        public bool IsPlatoonAnySolder => _soldiers.Count > 0;
        public List<Soldier> Soldiers 
        {
            get
            {
                return _soldiers.ToList();
            }
            private set
            {
                _soldiers = value;
            }
        }

        public void ShowPlatoon()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowRank();
            }
        }

        public void DeleteDeadSoldier()
        {
            Queue<Soldier> deadSoldiers = new Queue<Soldier>();

            foreach (var soldier in _soldiers)
            {
                if (soldier.IsDead)
                    deadSoldiers.Enqueue(soldier);
            }

            while (deadSoldiers.Count > 0)
            {
                _soldiers.Remove(deadSoldiers.Dequeue());
            }
        }

        public Soldier GetRandomSoldier()
        {
            return _soldiers[UserUtils.GetRandomNumber(_soldiers.Count)];
        }

        private void CreatePlatoon()
        {
            Barrack barrack = new Barrack();

            for (int i = 0; i < _maxSoldiersInPlatoon; i++)
            {
                _soldiers.Add(barrack.GetSoldier().Clone());
            }
        }
    }
    
    public abstract class Soldier
    {
        private int _healthPoint;

        protected Soldier(int healthPoint, int physicalAttack, bool canMultiHit, string rank)
        {
            _healthPoint = healthPoint;
            AttackPower = physicalAttack;
            CanMultiHit = canMultiHit;
            Rank = rank;
        }

        public bool CanMultiHit { get; private set; }
        public bool IsDead => _healthPoint <= 0;
        protected string Rank { get; private set; }
        protected int AttackPower { get; private set; }

        public void ShowRank()
        {
            Console.WriteLine(Rank);
        }

        public virtual void AttackSoloTarget(Soldier enemyFighter)
        {
            Console.WriteLine($"{Rank} Наносит обычный удар в {AttackPower} единиц урона {enemyFighter.Rank}");
            enemyFighter.TakeDamage(AttackPower);
        }
    
        public virtual void AttackMultyTarget(List<Soldier> enemyPlatoon) { }

        private void TakeDamage(int damage)
        {
            if (damage >= 0)
                _healthPoint -= damage;
        }

        public abstract Soldier Clone();
    }
    
    public class Corporal : Soldier
    {
        public Corporal() : base(90, 6, false,"Corporal") { }

        public override void AttackSoloTarget(Soldier enemyFighter)
        {
            base.AttackSoloTarget(enemyFighter);
        
            Console.WriteLine();
        }

        public override Soldier Clone()
        {
            return new Corporal();
        }
    }
    
    public class Sergeant : Soldier
    {
        public Sergeant() : base(133, 4, false, "Sergeant") { }

        public override void AttackSoloTarget(Soldier enemyFighter)
        {
            int damage = MultiHit();
        
            if (damage == 0)
                Console.WriteLine($"{Rank} размахался так сильно, что нанес {damage}!!! (но бил в другую сторону)");
            else
                Console.WriteLine($"{Rank} размахался так сильно, что нанес {damage}!!!");
        
            Console.WriteLine();
        }

        public override Soldier Clone()
        {
            return new Sergeant();
        }

        private int MultiHit()
        {
            int chance = 5;
        
            return UserUtils.GetRandomNumber(chance) * AttackPower;
        }
    }
    
    public class Specialist : Soldier
    {
        private int _index;
        public Specialist() : base(126, 3, true, "Specialist") { }

        public override void AttackMultyTarget(List<Soldier> enemyPlatoon)
        {
            int maxSoldiers = 5;
            maxSoldiers = enemyPlatoon.Count > maxSoldiers ? maxSoldiers : enemyPlatoon.Count;
        
            Queue<Soldier> tempSoldiers = ChooseRandomSoldiers(enemyPlatoon,UserUtils.GetRandomNumber(maxSoldiers));

            while (tempSoldiers.Count > 0)
            {
                AttackSoloTarget(tempSoldiers.Dequeue());
            }
        
            Console.WriteLine();
        }

        public override Soldier Clone()
        {
            return new Specialist();
        }

        private Queue<Soldier> ChooseRandomSoldiers(List<Soldier> enemies, int soldiersTook)
        {
            Queue<Soldier> tempSoldiers = new Queue<Soldier>();
        
            do
            {
                _index = UserUtils.GetRandomNumber(enemies.Count);
            
                tempSoldiers.Enqueue(enemies[_index]);
                enemies.RemoveAt(_index);
            
                soldiersTook--;
            } while (soldiersTook > 0);

            return tempSoldiers;
        }
    }
    
    public class StaffSergeant : Soldier
    {
        public StaffSergeant() : base(105, 3, true, "StaffSergeant") { }

        public override void AttackMultyTarget(List<Soldier> enemyPlatoon)
        {
            int maxSoldiers = 5;
            maxSoldiers = enemyPlatoon.Count > maxSoldiers ? maxSoldiers : enemyPlatoon.Count;
        
            Queue<Soldier> tempSoldiers = ChooseRandomSoldiers(enemyPlatoon,UserUtils.GetRandomNumber(maxSoldiers));

            while (tempSoldiers.Count > 0)
            {
                AttackSoloTarget(tempSoldiers.Dequeue());
            }
        
            Console.WriteLine();
        }

        public override Soldier Clone()
        {
            return new StaffSergeant();
        }

        private Queue<Soldier> ChooseRandomSoldiers(List<Soldier> enemies, int soldiersTook)
        {
            Queue<Soldier> tempSoldiersQueue = new Queue<Soldier>();
            List<Soldier> tempSoldiersList;
            int index;

            tempSoldiersList = ShuffleSoldiers(enemies);
        
            do
            {
                index = UserUtils.GetRandomNumber(tempSoldiersList.Count);
            
                tempSoldiersQueue.Enqueue(tempSoldiersList[index]);
                tempSoldiersList.RemoveAt(index);
            
                soldiersTook--;
            } while (soldiersTook > 0);

            return tempSoldiersQueue;
        }

        private List<Soldier> ShuffleSoldiers(List<Soldier> enemies)
        {
            List<Soldier> tempSoldiers = new List<Soldier>();

            foreach (var soldier in enemies)
            {
                tempSoldiers.Add(soldier);
            }
        
            Shuffle(tempSoldiers);
        
            return tempSoldiers;
        }

        private void Shuffle(List<Soldier> enemies)
        {
            Soldier tempSoldier;
            int randomIndex;
        
            for (int i = 0; i < enemies.Count; i++)
            {
                randomIndex = UserUtils.GetRandomNumber(enemies.Count);
                tempSoldier = enemies[randomIndex];
                enemies[randomIndex] = enemies[i];
                enemies[i] = tempSoldier;
            }
        }
    }
    
    public static class UserUtils
    {
        private const int MinValue = 0;

        private static Random _random = new Random();

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(MinValue, max);
        }
    }
}
