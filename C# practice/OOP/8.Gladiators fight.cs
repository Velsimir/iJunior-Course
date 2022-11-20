using System;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти. 
         * У каждого бойца могут быть свои статы.
         * Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
         * Если можно выбрать одинаковых бойцов, то это не должна быть одна и та же ссылка на одного бойца, 
         * чтобы он не атаковал сам себя.
         * Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар наносит удвоенный урон, 
         * другой имеет 30% увернуться от полученного урона, кто-то при получении урона немного себя лечит. 
         * Будут новые поля у наследников. У кого-то может быть мана и это только его особенность.
         */
        public static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Fight();
        }
    }

    abstract class Fighter
    {
        protected int NecessaryChanceOfSuccess = 50;

        public int HealthPoint { get; protected set; }
        public int ManaPoint { get; protected set; }
        public int AttackPower { get; protected set; }
        public int SpellChance { get; protected set; }

        protected Fighter(int healthPoint, int manaPoint, int physicalAttack)
        {
            HealthPoint = healthPoint;
            ManaPoint = manaPoint;
            AttackPower = physicalAttack;
        }

        public virtual void Attack(Fighter enemyFighter)
        {
            Console.WriteLine($"Наносит обычный удар в {AttackPower} единиц урона");
            enemyFighter.TakeDamage(AttackPower);
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoint -= damage;
        }
    }

    class HumanWarrior : Fighter
    {
        private Random _random = new Random();

        public HumanWarrior() : base(126, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
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
            int manaCoast = 10;

            if (ManaPoint >= manaCoast)
            {
                int minCritical = 1;
                int maxCritical = 4;
                int criticalMultiplier = _random.Next(minCritical, maxCritical);
                int damage;

                Console.Write("Использует Critical Attack| ");

                damage = criticalMultiplier * AttackPower;
                ManaPoint -= manaCoast;

                Console.WriteLine($" и наносит противнику {damage} единиц урона!");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }

    }

    class HumanMage : Fighter
    {
        private Random _random = new Random();

        public HumanMage() : base(90, 100, 7) { }

        public override void Attack(Fighter enemyFighter)
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

        private int CastMagicSpell()
        {
            int manaCouast = 20;
            int spellDamage = 18;
            int damage;

            if (ManaPoint >= manaCouast)
            {
                Console.Write("Использует Wind Strike");

                damage = spellDamage + AttackPower;

                Console.WriteLine($" и наносит противнику {damage} единиц урона!");

                ManaPoint -= manaCouast;

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class OrkWarrior : Fighter
    {
        private Random _random = new Random();

        public OrkWarrior() : base(133, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
        {
            int manaCouast = 20;
            SpellChance = _random.Next(100);

            if (SpellChance > NecessaryChanceOfSuccess && ManaPoint > manaCouast)
            {
                enemyFighter.TakeDamage(CastMortalBlow(enemyFighter));
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }

        private int CastMortalBlow(Fighter fighter)
        {
            int spellDamage = 8;
            int damage;
            int killerChanse = _random.Next(10);
            int necessaryKillerChanse = 1;

            Console.Write("Использует Mortal Blow");

            if (killerChanse == necessaryKillerChanse)
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

    class OrkMage : Fighter
    {
        private Random _random = new Random();

        public OrkMage() : base(105, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
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
            int manaCoast = 40;
            int minHealPoint = 10;
            int maxHealPoint = 25;
            int lowHP = 40;

            if (ManaPoint >= manaCoast && HealthPoint < lowHP)
            {
                int heal = _random.Next(minHealPoint, maxHealPoint);
                int damage;

                Console.Write("Использует Heal| ");

                damage = AttackPower;
                HealthPoint += heal;
                ManaPoint -= manaCoast;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также восстанавливает {heal} единиц здоровья");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class ElfWarrior : Fighter
    {
        private Random _random = new Random();
        private bool _isEwade;


        public ElfWarrior() : base(133, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
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
            if (_isEwade == false)
            {
                HealthPoint -= damage;
            }
            else
            {
                Console.Write(" | Уворот!");
            }
        }

        private int CastDodge()
        {
            int manaCoast = 10;
            _isEwade = false;

            if (ManaPoint >= manaCoast)
            {
                _isEwade = true;
                int damage;

                Console.Write("Использует Dodge| ");

                damage = AttackPower;
                ManaPoint -= manaCoast;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также готовиться увернуться от следующего удара");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }

    }

    class ElfMage : Fighter
    {
        private int _spellChanse;
        private Random _random = new Random();
        private bool _isEwade;

        public ElfMage() : base(96, 100, 2) { }

        public override void Attack(Fighter enemyFighter)
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
            if (_isEwade == false)
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
            int manaCoast = 20;
            _isEwade = false;

            if (ManaPoint >= manaCoast)
            {
                int damage;
                _isEwade = true;

                Console.Write("Использует Disembodied| ");

                damage = AttackPower + manaCoast;
                ManaPoint -= manaCoast;

                Console.WriteLine($" наносит противнику {damage} единиц урона! А также его тело стало прозрачным");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    class Arena
    {
        private Fighter[] _allFighters;
        private Fighter _fighterLeft;
        private Fighter _fighterRight;
        private string _nameLeftFighter = "Боец 1: ";
        private string _nameRightFighter = "Боец 2: ";

        public Arena()
        {
            ShowAllFighters(CreateFightersList());

            _fighterLeft = CreateFighter(TakeIndexFighter());

            CreateFightersList();

            _fighterRight = CreateFighter(TakeIndexFighter());

            Console.Clear();
            Console.WriteLine("Вы выбрали:");
            ShowFighterInfo(_fighterLeft, _nameLeftFighter);
            ShowFighterInfo(_fighterRight, _nameRightFighter);

            Console.ReadKey();
        }

        public void Fight()
        {
            while (_fighterLeft.HealthPoint > 0 && _fighterRight.HealthPoint > 0)
            {
                Console.Clear();

                ShowFighterInfo(_fighterLeft, _nameLeftFighter);

                _fighterLeft.Attack(_fighterRight);

                ShowFighterInfo(_fighterRight, _nameRightFighter);

                _fighterRight.Attack(_fighterLeft);

                Console.ReadKey();
            }

            if (_fighterLeft.HealthPoint < 0 && _fighterRight.HealthPoint < 0)
            {
                Console.WriteLine("Ого! Оба бойца отдали концы %)");
            }
            else if (_fighterLeft.HealthPoint < 0)
            {
                Console.WriteLine("Боец 2 Победил!");
            }
            else if (_fighterRight.HealthPoint < 0)
            {
                Console.WriteLine("Боец 1 Победил!");
            }

            Console.ReadKey();
        }

        private void ShowFighterInfo(Fighter fighter, string nameFighter)
        {
            Console.WriteLine($"{nameFighter} HP - {fighter.HealthPoint} | MP {fighter.ManaPoint} | Phys Attack {fighter.AttackPower}");
        }

        private void ShowAllFighters(Fighter[] fighters)
        {
            int numberFighter = 1;

            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{numberFighter})HP - {fighter.HealthPoint} | MP {fighter.ManaPoint} | Phys Attack {fighter.AttackPower}");
                numberFighter++;
            }
        }

        private int TakeIndexFighter()
        {
            string userInputString;
            int userInputInt;

            do
            {
                Console.WriteLine("Выбери бойца. Вам необходимо ввести число из списка: ");
                userInputString = Console.ReadLine();

            } while (int.TryParse(userInputString, out userInputInt) == false || userInputInt <= 0 || userInputInt > _allFighters.Length);


            return userInputInt;
        }

        private Fighter CreateFighter(int fighter)
        {
            switch (fighter)
            {
                case 1:
                    return _allFighters[fighter];

                case 2:
                    return _allFighters[fighter];

                case 3:
                    return _allFighters[fighter];

                case 4:
                    return _allFighters[fighter];

                case 5:
                    return _allFighters[fighter];

                case 6:
                    return _allFighters[fighter];
            }

            return null;
        }

        private Fighter[] CreateFightersList()
        {
            _allFighters = new Fighter[6];
            _allFighters[0] = new HumanWarrior();
            _allFighters[1] = new HumanMage();
            _allFighters[2] = new OrkWarrior();
            _allFighters[3] = new OrkMage();
            _allFighters[4] = new ElfWarrior();
            _allFighters[5] = new ElfMage();

            return _allFighters;
        }
    }
}