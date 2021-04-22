using System;

namespace Lab5
{
    enum Ranks
    {
        OP,
        SWAT,
        Army,
        FBI
    }
    class Police : Human
    {
        private Ranks rank;
        public Ranks Rank
        {
            private set
            {
                if (value > Ranks.FBI)
                {
                    value = Ranks.FBI;
                }

                rank = value;
            }
            get
            {
                return rank;
            }
        }
        private int merit;
        public int Merit
        {
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value >= 100)
                {
                    Rank += 1;
                    value = 0;
                }

                merit = value;
            }
            get
            {
                return merit;
            }
        }
        public Police()
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
            Rank = Ranks.OP;
            Merit = 0;
            Fill();
            Console.WriteLine("Object is created!\n");
        }
        public override void Fill()
        {
            Console.Write("Enter name: ");
            this["Name"] = Console.ReadLine();
        }
        public void Arrest(Gangster target)
        {
            if (target.Wanted != 0)
            {
                target.DropWeapon();
                target.ClearWanted();
                Merit += 10;

                if (Rank == Ranks.OP)
                {
                    Money += 100;
                }

                if (Rank == Ranks.SWAT)
                {
                    Money += 150;
                }

                if (Rank == Ranks.Army)
                {
                    Money += 200;
                }

                if (Rank == Ranks.FBI)
                {
                    Money += 250;
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

                    if (target.Wanted != 0)
                    {
                        Merit += 10;

                        if (Rank == Ranks.OP)
                        {
                            Money += 100;
                        }

                        if (Rank == Ranks.SWAT)
                        {
                            Money += 150;
                        }

                        if (Rank == Ranks.Army)
                        {
                            Money += 200;
                        }

                        if (Rank == Ranks.FBI)
                        {
                            Money += 250;
                        }
                    }
                    else
                    {
                        Merit -= 5;
                    }
                }
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

            Console.WriteLine("Rank - " + Rank);
            Console.WriteLine("Merit - " + Merit);
            Console.WriteLine("Money - " + Money + "$\n");
        }
    }
}
