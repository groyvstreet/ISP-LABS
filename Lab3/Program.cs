using System;

namespace Lab3
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
    class Human
    {
        private static int amount;
        public int Id { private set; get; }
        private string sex;
        public string Sex
        {
            set
            {
                while (value != "Male" && value != "Female")
                {
                    Console.WriteLine("Invalid input!\n");
                    Console.Write("Select sex(Male/Female): ");
                    value = Console.ReadLine();
                }

                sex = value;
            }
            get
            {
                return sex;
            }
        }

        private string name;
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
        public bool Dead { private set; get; }
        private int armor;
        public int Armor
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

                armor = value;
            }
            get
            {
                return armor;
            }
        }
        private int health;
        public int Health
        {
            private set
            {
                if(value > 100)
                {
                    value = 100;
                }

                if(value < 0)
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
        public int Money { private set; get; }
        public BodyType Body { private set; get; }
        private int fatIndex;
        public int FatIndex
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
        public bool HaveWeapon { private set; get; }
        private Weapons weapon;
        public Weapons Weapon
        {
            private set
            {
                HaveWeapon = true;
                weapon = value;
            }
            get
            {
                return weapon;
            }
        }
        public int Punch { private set; get; }
        private int strength;
        public int Strength
        {
            private set
            {
                if(value > 100)
                {
                    value = 100;
                }

                if(value < 5)
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
            get
            {
                switch (prop)
                {
                    case "Id": return Id.ToString();
                    case "Sex": return sex;
                    case "Name": return name;
                    case "Health": return Health.ToString();
                    case "Armor": return Armor.ToString();
                    case "Money": return Money.ToString();
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
                    default: return null;
                }
            }
        }
        public Human()
        {
            amount++;
            Id = amount;
            Health = 100;
            Dead = false;
            Armor = 0;
            Money = 1000;
            HaveWeapon = false;
            FatIndex = 0;
            Strength = 10;
            Fill();
            Console.WriteLine("Object is created!\n");
        }
        public Human(int armor, Weapons weapon)
        {
            amount++;
            Id = amount;
            Health = 100;
            Dead = false;
            Armor = armor;
            Money = 1000;
            Weapon = weapon;
            FatIndex = 0;
            Strength = 100;
            Fill();
            Console.WriteLine("Object is created!\n");
        }
        public void Fill()
        {
            Console.Write("Select sex(Male/Female): ");
            Sex = Console.ReadLine();
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
        }
        public void Info()
        {
            Console.WriteLine("Id - " + Id);
            Console.WriteLine("Sex - " + Sex);
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

            Console.WriteLine("Money - " + Money + "$\n");
        }
        public void TakeWeapon(Weapons weapon)
        {
            HaveWeapon = true;
            Weapon = weapon;
        }
        public void DropWeapon()
        {
            if (HaveWeapon)
            {
                HaveWeapon = false;
            }
            else
            {
                Console.WriteLine("No weapon!");
            }
        }
        public void Eat()
        {
            if (Money >= 5)
            {
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
                Strength += 5;
                FatIndex -= 5;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }
        public void Attack(Human target)
        {
            if (target.Dead)
            {
                Console.WriteLine("Target is dead!");
            }
            else
            {
                target.Health -= Punch;
            }
        }
        public void Attack(Human target, Weapons weapon)
        {
            if (target.Dead)
            {
                Console.WriteLine("Target is dead!");
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
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            Human target = new Human(100, Weapons.DesertEagle);

            while(true)
            {
                Console.WriteLine("1 - Create new");
                Console.WriteLine("2 - Edit");
                Console.WriteLine("3 - Info");
                Console.WriteLine("4 - Target info");
                Console.WriteLine("5 - Take weapon");
                Console.WriteLine("6 - Drop weapon");
                Console.WriteLine("7 - Eat");
                Console.WriteLine("8 - Go to the gym");
                Console.WriteLine("9 - Attack target");
                Console.WriteLine("0 - Exit");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    human = new Human();
                }
                else if (input == "2")
                {
                    Console.Clear();

                    while (true)
                    {
                        Console.WriteLine("Edit: ");
                        Console.WriteLine("1 - Full");
                        Console.WriteLine("2 - Field");
                        Console.WriteLine("0 - Back");
                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Clear();
                            human.Fill();
                            Console.WriteLine("Saved!\n");
                        }
                        else if (input == "2")
                        {
                            Console.Clear();

                            while (true)
                            {
                                Console.WriteLine("1 - Sex");
                                Console.WriteLine("2 - Name");
                                Console.WriteLine("0 - Back");
                                input = Console.ReadLine();
                                Console.Clear();

                                if (input == "1")
                                {
                                    Console.Write("Enter new sex: ");
                                    input = Console.ReadLine();
                                    human.Sex = input;
                                    Console.WriteLine("Saved!\n");
                                }
                                else if (input == "2")
                                {
                                    Console.Write("Enter new name: ");
                                    input = Console.ReadLine();
                                    human.Name = input;
                                    Console.WriteLine("Saved!\n");
                                }
                                else if (input == "0")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                }
                            }
                        }
                        else if (input == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.Clear();
                    human.Info();
                }
                else if(input == "4")
                {
                    Console.Clear();
                    target.Info();
                }
                else if (input == "5")
                {
                    Console.Clear();
                    human.TakeWeapon(Weapons.MP5);
                }
                else if (input == "6")
                {
                    Console.Clear();
                    human.DropWeapon();
                }
                else if (input == "7")
                {
                    Console.Clear();
                    human.Eat();
                }
                else if (input == "8")
                {
                    Console.Clear();
                    human.Gym();
                }
                else if (input == "9")
                {
                    Console.Clear();

                    if (human.HaveWeapon)
                    {
                        human.Attack(target, human.Weapon);
                    }
                    else
                    {
                        human.Attack(target);
                    }
                }
                else if (input == "0")
                {
                    Console.Clear();
                    Console.WriteLine("Program is finished...");
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
