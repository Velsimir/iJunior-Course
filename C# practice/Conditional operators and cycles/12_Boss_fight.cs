namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int minHP = 300;
            int maxHP = 400;
            int bossHP = random.Next(minHP, maxHP);
            int playerHP = 120;
            int minDamage = 5;
            int maxDamage = 5;
            int bossDamage = random.Next(minDamage, maxDamage);
            int poisonDamage = 15;
            int archBuffDamage = 2;
            int magicSpellDamage = 3;
            int swordSpellDamage = 3;
            int archDamage = 20;
            int archSkill = archDamage * archBuffDamage;
            int swordDamage = 30;
            int swordSkill = swordDamage * swordSpellDamage;
            int magicDamage = 70;
            int magicSkill = magicDamage * magicSpellDamage;
            int cooldownCount = 0;
            int cooldownTurns = 2;
            int playerChose;
            bool isPlayerLive = true;
            bool isBossLive = true;
            bool isBossHpVisible = false;
            bool isArchEquiped = false;
            bool isSwordEquiped = false;
            bool isStaffEquiped = false;
            bool isSkillCooldown = false;
            bool isPoisonActivated = false;
            bool isBuffActivated = false;

            Console.Write($"Босс качалки вышибает дверь и направляется к Вам!" +
                    $"\nХотите узнать его здоровье?" +
                    $"\nДа - 1" +
                    $"\nНет - 2" +
                    $"\nВаш выбор: ");

            playerChose = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (playerChose)
            {
                case 1:
                    Console.WriteLine($"Вы присматриваетесь к латексной броне и видите здоровье босса качалки!" +
                        $"\n Здоровье босса качалки = {bossHP}");
                    isBossHpVisible = true;
                    break;

                case 2:
                    Console.WriteLine("\nВы срываете с себя броню и бросаетесь в бой!");
                    break;
            }

            Console.Write("\n\nВыбери оружие для сражения:" +
                "\nФингер - 1" +
                "\nЧерный баклажан - 2" +
                "\nВолшебные латексные рукавицы - 3" +
                "\nВыш выбор: ");

            playerChose = Convert.ToInt32(Console.ReadLine());

            switch (playerChose)
            {
                case 1:
                    isSwordEquiped = true;
                    break;

                case 2:
                    isArchEquiped = true;
                    break;

                case 3:
                    isStaffEquiped = true;
                    break;
            }

            while (isBossLive && isPlayerLive)
            {
                Console.Clear();

                if (isBossHpVisible)
                {
                    Console.WriteLine($"Здоровье босса качалки: {bossHP}\n" +
                        $"\nБосс качалки бъет кулаками по шкафчику и готовится нанести {bossDamage} урона" +
                        $"\nУ вас осталось {playerHP} здоровья");
                }
                else
                {
                    Console.WriteLine($"\nБосс качалки бъет кулаками по шкафчику и готовится нанести {bossDamage} урона" +
                        $"\nУ вас осталось {playerHP} здоровья");
                }

                if (isPoisonActivated)
                {
                    Console.WriteLine($"\nБосс качалки, кричит и получает урон в размере {poisonDamage}");
                }

                if ((isBuffActivated || isSkillCooldown) && cooldownCount < cooldownTurns)
                {
                    cooldownCount += 1;
                }
                else
                {
                    isBuffActivated = false;
                    isSkillCooldown = false;
                    cooldownCount = 0;
                }

                if (isSwordEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                            $"\nСтик йор фингер ин босс эсс ({swordDamage} урона) - 1");
                    if (isSkillCooldown == false)
                    {
                        Console.WriteLine($"Серия удачных проникновений фингером ({swordSkill} перезарядка {cooldownTurns} хода) - 2)");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Смазать фингер огненной смазкой ({poisonDamage} урона за каждый новый ход) - 3");
                    }

                    Console.Write("Ваш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case 1:
                            bossHP -= swordDamage;
                            break;

                        case 2:
                            bossHP -= swordSkill;
                            isSkillCooldown = true;
                            break;

                        case 3:
                            isPoisonActivated = true;
                            break;
                    }
                }

                if (isArchEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                        $"\nЯростный бросок черного баклажана в лицо ({archDamage} урона) - 1");

                    if (isBuffActivated == false)
                    {
                        Console.WriteLine($"Навернуть Рататуй (увеличивает урон в 2 раза, действует {cooldownTurns} хода) - 2");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Смазать баклажан огненной смазкой ({poisonDamage} урона каждый ход) - 3");
                    }

                    Console.Write("Ваш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case 1:
                            if (isSkillCooldown)
                            {
                                bossHP -= archSkill;
                            }
                            else
                            {
                                bossHP -= archDamage;
                            }
                            break;

                        case 2:
                            isBuffActivated = true;
                            isSkillCooldown = true;
                            break;

                        case 3:
                            isPoisonActivated = true;
                            break;
                    }
                }

                if (isStaffEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                        $"\nТелепатический массаж эсс ({magicDamage} урона) - 1");

                    if (isSkillCooldown == false)
                    {
                        Console.WriteLine($"Вызвать мужицкий дождь({swordSkill} перезарядка {cooldownTurns} хода) - 2)");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Призвать отряд кожевенников ({poisonDamage} урона каждый ход) - 3");
                    }

                    Console.Write("\nВаш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case 1:
                            bossHP -= magicDamage;
                            break;

                        case 2:
                            bossHP -= magicSkill;
                            isSkillCooldown = true;
                            break;

                        case 3:
                            isPoisonActivated = true;
                            break;
                    }
                }

                playerHP -= bossDamage;

                if (playerHP <= 0)
                {
                    isPlayerLive = false;
                }

                if (bossHP <= 0)
                {
                    isBossLive = false;
                }
            }

            if (isPlayerLive)
            {
                Console.WriteLine("Босс качалки со слезами на глазах чинит дверь и быстро ретируется из качалки" +
                    "\nHell YEAH!");
            }
            else
            {
                Console.WriteLine("Дип Дарк фэнтэзи Босса качалки сбылись " +
                    "Вы убегаете из качалки:(");
            }
        }
    }
}
