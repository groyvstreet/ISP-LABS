using System;

namespace Lab8
{
    enum Gangs
    {
        Crips,
        Bloods,
        Pirus,
        Triad,
        Yakuza
    }

    enum CHead
    {
        HeadBand,
        Cap
    }

    enum CBody
    {
        TShirt,
        Hoodie
    }

    enum CLegs
    {
        Shorts,
        Trousers
    }

    struct Clothes
    {
        public CHead head;
        public CBody body;
        public CLegs legs;
    }

    class Gangster : Human
    {
        public delegate void TheftAction();
        public event TheftAction OnTheft;
        private Clothes clothes;
        public Gangs Gang { private set; get; }
        private int respect;

        public int Respect
        {
            private set
            {
                if (value > 100)
                {
                    value = 100;
                }

                if (value < 0)
                {
                    value = 0;
                }

                respect = value;
            }
            get
            {
                return respect;
            }
        }

        private int sprayPaint;

        public int SprayPaint
        {
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > 100)
                {
                    value = 100;
                }

                sprayPaint = value;
            }
            get
            {
                return sprayPaint;
            }
        }

        private int wanted;

        public int Wanted
        {
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > 5)
                {
                    value = 5;
                }

                wanted = value;
            }
            get
            {
                return wanted;
            }
        }

        public Gangster()
        {
            amount++;
            Id = amount;
            Health = 100;
            Dead = false;
            Armor = 0;
            Money = 100;
            HaveWeapon = false;
            FatIndex = 0;
            Strength = 10;
            Respect = 0;
            SprayPaint = 0;
            Wanted = 0;
            Fill();
            Console.WriteLine("Object is created!\n");
        }

        public override void Fill()
        {
            Console.Write("Enter name: ");
            this["Name"] = Console.ReadLine();
            Console.WriteLine("Select gang:\n1 - Crips\n2 - Bloods\n3 - Pirus\n4 - Triad\n5 - Yakuza");
            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "1")
                {
                    Gang = Gangs.Crips;
                    break;
                }
                else if (input == "2")
                {
                    Gang = Gangs.Bloods;
                    break;
                }
                else if (input == "3")
                {
                    Gang = Gangs.Pirus;
                    break;
                }
                else if (input == "4")
                {
                    Gang = Gangs.Triad;
                    break;
                }
                else if (input == "5")
                {
                    Gang = Gangs.Yakuza;
                    break;
                }
            }

            Console.WriteLine("1 - HeadBand\n2 - Cap");

            while (true)
            {
                input = Console.ReadLine();

                if (input == "1")
                {
                    clothes.head = CHead.HeadBand;
                    break;
                }
                else if (input == "2")
                {
                    clothes.head = CHead.Cap;
                    break;
                }
            }

            Console.WriteLine("1 - TShirt\n2 - Hoodie");

            while (true)
            {
                input = Console.ReadLine();

                if (input == "1")
                {
                    clothes.body = CBody.TShirt;
                    break;
                }
                else if (input == "2")
                {
                    clothes.body = CBody.Hoodie;
                    break;
                }
            }

            Console.WriteLine("1 - Shorts\n2 - Trousers");

            while (true)
            {
                input = Console.ReadLine();

                if (input == "1")
                {
                    clothes.legs = CLegs.Shorts;
                    break;
                }
                else if (input == "2")
                {
                    clothes.legs = CLegs.Trousers;
                    break;
                }
            }
        }

        public override void Info()
        {
            Console.WriteLine("Id - " + Id);
            Console.WriteLine("Name - " + Name);
            Console.WriteLine("Health - " + Health);
            Console.WriteLine("Armor - " + Armor);
            Console.WriteLine("Strength - " + Strength);
            Console.WriteLine("Fat - " + FatIndex);
            Console.WriteLine("Body - " + Body);

            if (HaveWeapon)
            {
                Console.WriteLine("Weapon - " + Weapon);
            }
            else
            {
                Console.WriteLine("No weapon");
            }

            Console.WriteLine("Gang - " + Gang);
            Console.WriteLine("Respect - " + Respect);
            Console.WriteLine("SprayPaint - " + SprayPaint);
            Console.WriteLine("Money - " + Money + "$");
            Console.WriteLine("Wanted level - " + Wanted);
            Console.WriteLine("Clothes - " + clothes.head + " - " + clothes.body + " - " + clothes.legs + "\n");
        }

        public void TheftAuto()
        {
            Respect += 2;
            Money += 300;
            Wanted += 1;
            OnTheft?.Invoke();
        }

        public void RobShop()
        {
            Respect += 1;
            Money += 85;
            Wanted += 1;
        }

        public void PaintGraffiti()
        {
            if (sprayPaint > 0)
            {
                SprayPaint--;
                Respect += 4;
            }
            else
            {
                Console.WriteLine("Spray is empty!");
            }
        }

        public void BuySpray()
        {
            if (Money >= 15)
            {
                Money -= 15;
                SprayPaint += 100;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }

        public void AddHealth(int h)
        {
            Health += h;
        }

        public void AddArmor(int a)
        {
            Armor += a;
        }

        public void ClearWanted()
        {
            Wanted = 0;
        }

        public void Attack(Gangster target)
        {
            if (target.Dead)
            {
                Console.WriteLine("Target is dead!");
            }
            else
            {
                target.Health -= Punch;

                if (target.Dead)
                {
                    Money += target.Money;
                    Console.WriteLine($"{this["Name"]} killed {target["Name"]}!");
                    Console.WriteLine($"{this["Name"]} +{target.Money}$");

                    if (Gang == target.Gang)
                    {
                        Respect -= 8;
                    }
                    else
                    {
                        Respect += 6;
                    }
                }
            }
        }

        public void Attack(Gangster target, Weapons weapon)
        {
            if (target.Dead)
            {
                Console.WriteLine($"{target["Name"]} is dead!");
            }
            else
            {
                int damage = 0;

                if (weapon == Weapons.Colt45)
                {
                    damage = 15;
                }
                else if (weapon == Weapons.DesertEagle)
                {
                    damage = 30;
                }
                else if (weapon == Weapons.M4)
                {
                    damage = 40;
                }
                else if (weapon == Weapons.MicroUzi)
                {
                    damage = 20;
                }
                else if (weapon == Weapons.MP5)
                {
                    damage = 30;
                }
                else if (weapon == Weapons.Tec9)
                {
                    damage = 17;
                }

                int temp = target.Armor - damage;
                target.Armor -= damage;

                if (temp < 0)
                {
                    target.Health += temp;
                }

                if (target.Dead)
                {
                    Money += target.Money;
                    Console.WriteLine($"{this["Name"]} killed {target["Name"]}!");
                    Console.WriteLine($"{this["Name"]} +{target.Money}$");

                    if (Gang == target.Gang)
                    {
                        Respect -= 8;
                    }
                    else
                    {
                        Respect += 6;
                    }
                }
            }
        }

        public void Attack(Police target, Weapons weapon)
        {
            if (target.Dead)
            {
                Console.WriteLine($"{target["Name"]} is dead!");
            }
            else
            {
                int damage = 0;

                if (weapon == Weapons.Colt45)
                {
                    damage = 15;
                }
                else if (weapon == Weapons.DesertEagle)
                {
                    damage = 30;
                }
                else if (weapon == Weapons.M4)
                {
                    damage = 40;
                }
                else if (weapon == Weapons.MicroUzi)
                {
                    damage = 20;
                }
                else if (weapon == Weapons.MP5)
                {
                    damage = 30;
                }
                else if (weapon == Weapons.Tec9)
                {
                    damage = 17;
                }

                int temp = target.Armor - damage;
                target.AddArmor(-damage);

                if (temp < 0)
                {
                    target.AddHealth(temp);
                }

                if (target.Dead)
                {
                    Money += target.Money;
                    Console.WriteLine($"{this["Name"]} killed {target["Name"]}!");
                    Console.WriteLine($"{this["Name"]} +{target.Money}$");

                    if (target.Rank == Ranks.OP)
                    {
                        Respect += 2;
                    }

                    if (target.Rank == Ranks.OP)
                    {
                        Respect += 4;
                    }

                    if (target.Rank == Ranks.OP)
                    {
                        Respect += 6;
                    }

                    if (target.Rank == Ranks.OP)
                    {
                        Respect += 8;
                    }
                }
            }
        }
    }
}
