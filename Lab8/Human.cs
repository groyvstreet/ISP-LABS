using System;

namespace Lab8
{
    enum Weapons
    {
        MicroUzi,
        Tec9,
        MP5,
        Colt45,
        DesertEagle,
        M4
    }

    enum BodyType
    {
        Thin,
        Normal,
        Fat
    }

    abstract class Human : IHuman, ICloneable
    {
        public delegate void GetMessage();
        protected static int amount;
        public int Id { protected set; get; }
        protected string name;

        public string Name
        {
            set
            {
                value = value.Trim();
                bool correct;

                do
                {
                    correct = true;

                    for (int i = 0; i < value.Length; i++)
                    {
                        if (Char.IsDigit(value[i]))
                        {
                            correct = false;
                        }
                    }

                    if (!correct || value == "")
                    {
                        Console.WriteLine("Invalid input!\n");
                        Console.Write("Enter name: ");
                        value = Console.ReadLine();
                    }
                }
                while (!correct);

                name = value.Trim();
            }
            get
            {
                return name;
            }
        }

        public bool Dead { set; get; }
        protected int armor;

        public int Armor
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }

                if (value < 0)
                {
                    value = 0;
                }

                armor = value;
            }
            get
            {
                return armor;
            }
        }

        protected int health;

        public int Health
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }

                if (value <= 0)
                {
                    value = 0;
                    Dead = true;
                }

                health = value;
            }
            get
            {
                return health;
            }
        }

        public int Money { set; get; }
        public BodyType Body { set; get; }
        protected int fatIndex;

        public int FatIndex
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value < 20)
                {
                    if (strength < 20)
                    {
                        Body = BodyType.Thin;
                    }
                    else
                    {
                        Body = BodyType.Normal;
                    }
                }
                else
                {
                    if (strength < 20)
                    {
                        Body = BodyType.Fat;
                    }
                    else
                    {
                        Body = BodyType.Normal;
                    }
                }

                fatIndex = value;
            }
            get
            {
                return fatIndex;
            }
        }

        public bool HaveWeapon { set; get; }
        protected Weapons weapon;

        public Weapons Weapon
        {
            set
            {
                HaveWeapon = true;
                weapon = value;
            }
            get
            {
                return weapon;
            }
        }

        public int Punch { set; get; }
        protected int strength;

        public int Strength
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }

                if (value < 5)
                {
                    value = 5;
                }

                if (fatIndex < 20)
                {
                    if (value < 20)
                    {
                        Body = BodyType.Thin;
                    }
                    else
                    {
                        Body = BodyType.Normal;
                    }
                }
                else
                {
                    if (value < 20)
                    {
                        Body = BodyType.Fat;
                    }
                    else
                    {
                        Body = BodyType.Normal;
                    }
                }

                strength = value;
                Punch = strength / 5;
            }
            get
            {
                return strength;
            }
        }

        public string this[string prop]
        {
            set
            {
                if (prop == "Name")
                {
                    Name = value;
                }
            }
            get
            {
                switch (prop)
                {
                    case "Id": return Id.ToString();
                    case "Name": return name;
                    case "Weapon":
                        if (HaveWeapon)
                        {
                            switch (Weapon)
                            {
                                case Weapons.MicroUzi: return "Micro-Uzi";
                                case Weapons.Tec9: return "Tec-9";
                                case Weapons.MP5: return "MP5";
                                case Weapons.Colt45: return "Colt45";
                                case Weapons.DesertEagle: return "Desert Eagle";
                                case Weapons.M4: return "M4";
                                default: return null;
                            }
                        }
                        else
                        {
                            return "No weapon";
                        }
                    default: throw new Exception("Invalid argument");
                }
            }
        }

        public abstract void Fill();

        public abstract void Info();

        public void ShowMessage(GetMessage message)
        {
            message?.Invoke();
        }

        public void TakeWeapon(Weapons weapon)
        {
            HaveWeapon = true;
            Weapon = weapon;
        }

        public void DropWeapon()
        {
            HaveWeapon = false;
        }

        public void BuyArmor()
        {
            if (Money >= 100)
            {
                Money -= 100;
                Armor = 100;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }

        public void Eat()
        {
            if (Money >= 5)
            {
                Money -= 5;
                FatIndex += 5;
                Strength -= 1;
                Health += 10;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }

        public void Gym()
        {
            if (Money >= 10)
            {
                Money -= 10;
                Strength += 5;
                FatIndex -= 5;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
