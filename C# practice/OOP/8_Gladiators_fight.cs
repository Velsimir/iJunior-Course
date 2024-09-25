using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Fight();
        }
    }

    public abstract class Fighter
    {
        protected int NecessaryChanceOfSuccess = 50;

        protected Fighter(int healthPoint, int manaPoint, int physicalAttack)
        {
            HealthPoint = healthPoint;
            ManaPoint = manaPoint;
            AttackPower = physicalAttack;
        }
    
        public int HealthPoint { get; protected set; }
        public int ManaPoint { get; protected set; }
        public int AttackPower { get; protected set; }
        protected int SpellChance { get; set; }

        public virtual void Attack(Fighter enemyFighter)
        {
            Console.WriteLine($"Наносит обычный удар в {AttackPower} единиц урона");
            enemyFighter.TakeDamage(AttackPower);
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoint -= damage;
        }

        public abstract Fighter Clone();
    }

    public class HumanWarrior : Fighter
    {
        public HumanWarrior() : base(126, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
        {
            SpellChance = UserUtils.GetRandomNumber(0, 100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastMultiplierAttack());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }
    
        public override Fighter Clone()
        {
            return new HumanWarrior();
        }

        private int CastMultiplierAttack()
        {
            int manaCoast = 10;

            if (ManaPoint >= manaCoast)
            {
                int minCritical = 1;
                int maxCritical = 4;
                int criticalMultiplier = UserUtils.GetRandomNumber(minCritical, maxCritical);
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

    public class HumanMage : Fighter
    {
        public HumanMage() : base(90, 100, 7) { }

        public override void Attack(Fighter enemyFighter)
        {
            SpellChance = UserUtils.GetRandomNumber(0, 100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastMagicSpell());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }
    
        public override Fighter Clone()
        {
            return new HumanMage();
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

    public class OrkWarrior : Fighter
    {
        public OrkWarrior() : base(133, 100, 4)
        {
        }

        public override void Attack(Fighter enemyFighter)
        {
            int manaCouast = 20;
            SpellChance = UserUtils.GetRandomNumber(0, 100);

            if (SpellChance > NecessaryChanceOfSuccess && ManaPoint > manaCouast)
            {
                enemyFighter.TakeDamage(CastMortalBlow(enemyFighter));
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }
    
        public override Fighter Clone()
        {
            return new OrkWarrior();
        }

        private int CastMortalBlow(Fighter fighter)
        {
            int spellDamage = 8;
            int damage;
            int killerChanse = UserUtils.GetRandomNumber(0, 10);
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
    
    public class OrkMage : Fighter
    {
        public OrkMage() : base(105, 100, 4) { }

        public override void Attack(Fighter enemyFighter)
        {
            SpellChance = UserUtils.GetRandomNumber(0, 100);

            if (SpellChance > NecessaryChanceOfSuccess)
            {
                enemyFighter.TakeDamage(CastHeal());
            }
            else
            {
                base.Attack(enemyFighter);
            }
        }
    
        public override Fighter Clone()
        {
            return new OrkMage();
        }

        private int CastHeal()
        {
            int manaCoast = 40;
            int minHealPoint = 10;
            int maxHealPoint = 25;
            int lowHealthPoint = 40;

            if (ManaPoint >= manaCoast && HealthPoint < lowHealthPoint)
            {
                int heal = UserUtils.GetRandomNumber(minHealPoint, maxHealPoint);
                int damage;

                Console.Write("Использует Heal| ");

                damage = AttackPower;
                HealthPoint += heal;
                ManaPoint -= manaCoast;

                Console.WriteLine(
                    $" наносит противнику {damage} единиц урона! А также восстанавливает {heal} единиц здоровья");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    public class ElfWarrior : Fighter
    {
        private bool _isEwade;


        public ElfWarrior() : base(133, 100, 4)
        {
        }

        public override void Attack(Fighter enemyFighter)
        {
            SpellChance = UserUtils.GetRandomNumber(0, 100);

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
    
        public override Fighter Clone()
        {
            return new ElfWarrior();
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

                Console.WriteLine(
                    $" наносит противнику {damage} единиц урона! А также готовиться увернуться от следующего удара");

                return damage;
            }

            Console.WriteLine($" Не хватает маны! Наносит противнику {AttackPower} единиц урона!");
            return AttackPower;
        }
    }

    public class ElfMage : Fighter
    {
        private int _spellChanse;
        private bool _isEwade;

        public ElfMage() : base(96, 100, 2)
        {
        }

        public override void Attack(Fighter enemyFighter)
        {
            SpellChance = UserUtils.GetRandomNumber(0, 100);

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

        public override Fighter Clone()
        {
            return new ElfMage();
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

    public class Arena
{
    private List<Fighter> _allFighters;
    private Fighter _fighterLeft;
    private Fighter _fighterRight;
    private string _nameLeftFighter = "Боец 1: ";
    private string _nameRightFighter = "Боец 2: ";

    public Arena()
    {
        ShowAllFighters(CreateFightersList());

        _fighterLeft = CreateFighter(ChoseFighter());

        CreateFightersList();

        _fighterRight = CreateFighter(ChoseFighter());

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
        
        ShowResultOfFight();
    }

    private void ShowResultOfFight()
    {
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
    }

    private void ShowFighterInfo(Fighter fighter, string nameFighter)
    {
        Console.WriteLine(
            $"{nameFighter} HP - {fighter.HealthPoint} | MP {fighter.ManaPoint} | Phys Attack {fighter.AttackPower}");
    }

    private void ShowAllFighters(List<Fighter> fighters)
    {
        int numberFighter = 1;

        foreach (var fighter in fighters)
        {
            Console.WriteLine(
                $"{numberFighter})HP - {fighter.HealthPoint} | MP {fighter.ManaPoint} | Phys Attack {fighter.AttackPower}");

            numberFighter++;
        }
    }

    private Fighter ChoseFighter()
    {
        string userInputString;
        int userInputInt;

        do
        {
            Console.WriteLine("Выбери бойца. Вам необходимо ввести число из списка: ");
            userInputString = Console.ReadLine();
        } while (int.TryParse(userInputString, out userInputInt) == false ||
                 userInputInt <= 0 ||
                 userInputInt > _allFighters.Count);


        return _allFighters[userInputInt-1];
    }

    private Fighter CreateFighter(Fighter fighter)
    {
        Fighter copyFighter = fighter.Clone();
        
        return copyFighter;
    }

    private List<Fighter> CreateFightersList()
    {
        _allFighters = new List<Fighter>();
        _allFighters.Add(new HumanWarrior());
        _allFighters.Add(new HumanMage());
        _allFighters.Add(new OrkWarrior());
        _allFighters.Add(new OrkMage());
        _allFighters.Add(new ElfWarrior());
        _allFighters.Add(new ElfMage());

        return _allFighters;
    }
}
}