using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int  CommandYes = 1;
            const int  CommandNo = 2;
            const int  ChooseFinger = 1;
            const int  ChooseBlackEggplant = 2;
            const int  ChooseLatexGloves = 3;
            const int  ChooseFirstSpell = 1;
            const int  ChooseSecondSpell = 2;
            const int  ChooseThirdSpell = 3;
            
            Random random = new Random();
            int minHPBoss = 300;
            int maxHPBoss = 400;
            int bossHP = random.Next(minHPBoss, maxHPBoss);
            int playerHP = 120;
            int minDamageBoss = 5;
            int maxDamageBoss = 5;
            int bossDamage = random.Next(minDamageBoss, maxDamageBoss);
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
            int playerChose = 0;
            int oneSecond = 1;
            int zeroSecond = 0;
            bool isPlayerLive = true;
            bool isBossLive = true;
            bool isBossHpVisible = false;
            bool isEggplantEquiped = false;
            bool isFingerEquiped = false;
            bool isGlovesEquiped = false;
            bool isSkillCooldown = false;
            bool isPoisonActivated = false;
            bool isBuffActivated = false;

            Console.Write("Босс качалки вышибает дверь и направляется к Вам!" +
                    $"\nХотите узнать его здоровье?" +
                    $"\nДа - {CommandYes}" +
                    $"\nНет - {CommandNo}" +
                    "\nВаш выбор: ");

            playerChose = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (playerChose)
            {
                case CommandYes:
                    Console.WriteLine("Вы присматриваетесь к латексной броне и видите здоровье босса качалки!" +
                        $"\n Здоровье босса качалки = {bossHP}");
                    isBossHpVisible = true;
                    break;

                case CommandNo:
                    Console.WriteLine("\nВы срываете с себя броню и бросаетесь в бой!");
                    break;
            }

            Console.Write("\n\nВыбери оружие для сражения:" +
                $"\nФингер - {ChooseFinger}" +
                $"\nЧерный баклажан - {ChooseBlackEggplant}" +
                $"\nВолшебные латексные рукавицы - {ChooseLatexGloves}" +
                "\nВыш выбор: ");

            playerChose = Convert.ToInt32(Console.ReadLine());

            switch (playerChose)
            {
                case ChooseFinger:
                    isFingerEquiped = true;
                    break;

                case ChooseBlackEggplant:
                    isEggplantEquiped = true;
                    break;

                case ChooseLatexGloves:
                    isGlovesEquiped = true;
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
                    cooldownCount += oneSecond;
                }
                else
                {
                    isBuffActivated = false;
                    isSkillCooldown = false;
                    cooldownCount = zeroSecond;
                }

                if (isFingerEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                            $"\nСтик йор фингер ин босс эсс ({swordDamage} урона) - {ChooseFirstSpell}");
                    if (isSkillCooldown == false)
                    {
                        Console.WriteLine($"Серия удачных проникновений фингером ({swordSkill} перезарядка {cooldownTurns} хода) - {ChooseSecondSpell})");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Смазать фингер огненной смазкой ({poisonDamage} урона за каждый новый ход) - {ChooseThirdSpell}");
                    }

                    Console.Write("Ваш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case ChooseFirstSpell:
                            bossHP -= swordDamage;
                            break;

                        case ChooseSecondSpell:
                            bossHP -= swordSkill;
                            isSkillCooldown = true;
                            break;

                        case ChooseThirdSpell:
                            isPoisonActivated = true;
                            break;
                    }
                }

                if (isEggplantEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                        $"\nЯростный бросок черного баклажана в лицо ({archDamage} урона) - {ChooseFirstSpell}");

                    if (isBuffActivated == false)
                    {
                        Console.WriteLine($"Навернуть Рататуй (увеличивает урон в 2 раза, действует {cooldownTurns} хода) - {ChooseSecondSpell}");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Смазать баклажан огненной смазкой ({poisonDamage} урона каждый ход) - {ChooseThirdSpell}");
                    }

                    Console.Write("Ваш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case ChooseFirstSpell:
                            if (isSkillCooldown)
                            {
                                bossHP -= archSkill;
                            }
                            else
                            {
                                bossHP -= archDamage;
                            }
                            break;

                        case ChooseSecondSpell:
                            isBuffActivated = true;
                            isSkillCooldown = true;
                            break;

                        case ChooseThirdSpell:
                            isPoisonActivated = true;
                            break;
                    }
                }

                if (isGlovesEquiped)
                {
                    Console.WriteLine($"\nВыберите атаку" +
                        $"\nТелепатический массаж эсс ({magicDamage} урона) - {ChooseFirstSpell}");

                    if (isSkillCooldown == false)
                    {
                        Console.WriteLine($"Вызвать мужицкий дождь({swordSkill} перезарядка {cooldownTurns} хода) - {ChooseSecondSpell})");
                    }

                    if (isPoisonActivated == false)
                    {
                        Console.WriteLine($"Призвать отряд кожевенников ({poisonDamage} урона каждый ход) - {ChooseThirdSpell}");
                    }

                    Console.Write("\nВаш выбор: ");

                    playerChose = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (playerChose)
                    {
                        case ChooseFirstSpell:
                            bossHP -= magicDamage;
                            break;

                        case ChooseSecondSpell:
                            bossHP -= magicSkill;
                            isSkillCooldown = true;
                            break;

                        case ChooseThirdSpell:
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
