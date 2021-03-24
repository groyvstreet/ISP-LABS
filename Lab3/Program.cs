using System;

namespace Lab3
{
    class Human
    {
        public static int Id { private set; get; }
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
        private int age;
        public int Age
        {
            set
            {
                bool correct = true;

                while (value <= 0 || correct == false)
                {
                    Console.WriteLine("Invalid input!\n");
                    Console.Write("Enter age: ");
                    correct = int.TryParse(Console.ReadLine(), out value);
                }

                age = value;
            }
            get
            {
                return age;
            }
        }
        private float weight;
        public float Weight
        {
            set
            {
                bool correct = true;

                while (value <= 0 || correct == false)
                {
                    Console.WriteLine("Invalid input!\n");
                    Console.Write("Enter weight: ");
                    correct = float.TryParse(Console.ReadLine(), out value);
                }

                weight = value;
            }
            get
            {
                return weight;
            }
        }
        private float growth;
        public float Growth
        {
            set
            {
                bool correct = true;

                while (value <= 0 || correct == false)
                {
                    Console.WriteLine("Invalid input!\n");
                    Console.Write("Enter growth: ");
                    correct = float.TryParse(Console.ReadLine(), out value);
                }

                growth = value;
            }
            get
            {
                return growth;
            }
        }
        public float Balance { private set; get; }
        public string Passport { private set; get; }
        public string this[string prop]
        {
            get
            {
                switch (prop)
                {
                    case "Id": return "Id - " + Id;
                    case "Sex": return "Sex - " + sex;
                    case "Name": return "Name - " + name;
                    case "Passport": return Passport;
                    case "Age": return "Age - " + age.ToString();
                    case "Weight": return "Weight - " + weight.ToString();
                    case "Growth": return "Growth - " + growth.ToString();
                    case "Balance": return "Balance - " + Balance.ToString() + "$";
                    default: return null;
                }
            }
        }
        public Human()
        {
            Id++;
            Balance = 15;
            Passport = "Passport is absent!";
            Fill();
            Console.WriteLine("Object is created!\n");
        }
        public Human(string sex, string name, int age, float weight, float growth)
        {
            Id++;
            Balance = 15;
            Passport = "Passport is absent!";
            Sex = sex;
            Name = name;
            Age = age;
            Weight = weight;
            Growth = growth;
            Console.WriteLine("Object is created!\n");
        }
        public void Fill()
        {
            Console.Write("Select sex(Male/Female): ");
            Sex = Console.ReadLine();
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter age: ");
            int.TryParse(Console.ReadLine(), out int num);
            Age = num;
            Console.Write("Enter weight: ");
            float.TryParse(Console.ReadLine(), out float numf);
            Weight = numf;
            Console.Write("Enter growth: ");
            float.TryParse(Console.ReadLine(), out numf);
            Growth = numf;
        }
        public void Info()
        {
            Console.WriteLine("Id - " + Id);
            Console.WriteLine("Sex - " + Sex);
            Console.WriteLine("Name - " + Name);
            Console.WriteLine("Age - " + Age);
            Console.WriteLine("Weight - " + Weight);
            Console.WriteLine("Growth - " + Growth);
            Console.WriteLine("Balance - " + Balance + "$");
            Console.WriteLine("Passport - " + Passport + "\n");
        }
        public void BuyPass()
        {
            if (Age >= 14)
            {
                if (Balance >= 10)
                {
                    Console.WriteLine("Passport is bought!(-10$)\n");
                    Balance -= 10;
                    Passport = "Passport is present!";
                }
                else
                {
                    Console.WriteLine("Not enough money!\n");
                }
            }
            else
            {
                Console.WriteLine("You are small!\n");
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();

            while(true)
            {
                Console.WriteLine("1 - Create new");
                Console.WriteLine("2 - Edit");
                Console.WriteLine("3 - Info");
                Console.WriteLine("4 - Buy passport");
                Console.WriteLine("0 - Exit");
                string input = Console.ReadLine();
                
                if(input == "1")
                {
                    Console.Clear();
                    while(true)
                    {
                        Console.WriteLine("1 - Own");
                        Console.WriteLine("2 - Template");
                        Console.WriteLine("0 - Back");
                        input = Console.ReadLine();

                        if(input == "1")
                        {
                            Console.Clear();
                            human = new Human();
                            break;
                        }
                        else if (input == "2")
                        {
                            Console.Clear();
                            human = new Human("Male", "Alex", 20, 75, 180);
                            break;
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
                else if(input == "2")
                {
                    Console.Clear();

                    while (true)
                    {
                        Console.WriteLine("Edit: ");
                        Console.WriteLine("1 - Full");
                        Console.WriteLine("2 - Field");
                        Console.WriteLine("0 - Back");
                        input = Console.ReadLine();

                        if(input == "1")
                        {
                            Console.Clear();
                            human.Fill();
                            Console.WriteLine("Saved!\n");
                        }
                        else if(input == "2")
                        {
                            Console.Clear();

                            while (true)
                            {
                                Console.WriteLine("1 - Sex");
                                Console.WriteLine("2 - Name");
                                Console.WriteLine("3 - Age");
                                Console.WriteLine("4 - Weight");
                                Console.WriteLine("5 - Growth");
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
                                else if (input == "3")
                                {
                                    Console.Write("Enter new age: ");
                                    input = Console.ReadLine();
                                    int.TryParse(input, out int res);
                                    human.Age = res;
                                    Console.WriteLine("Saved!\n");
                                }
                                else if (input == "4")
                                {
                                    Console.Write("Enter new weight: ");
                                    input = Console.ReadLine();
                                    float.TryParse(input, out float res);
                                    human.Weight = res;
                                    Console.WriteLine("Saved!\n");
                                }
                                else if (input == "5")
                                {
                                    Console.Write("Enter new growth: ");
                                    input = Console.ReadLine();
                                    float.TryParse(input, out float res);
                                    human.Growth = res;
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
                        else if(input == "0")
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
                else if(input == "3")
                {
                    Console.Clear();

                    while (true)
                    {
                        Console.WriteLine("Display: ");
                        Console.WriteLine("1 - All info");
                        Console.WriteLine("2 - Field");
                        Console.WriteLine("0 - Back");
                        input = Console.ReadLine();

                        if(input == "1")
                        {
                            Console.Clear();
                            human.Info();
                            break;
                        }
                        else if(input == "2")
                        {
                            Console.Clear();

                            while (true)
                            {
                                Console.WriteLine("1 - Id");
                                Console.WriteLine("2 - Sex");
                                Console.WriteLine("3 - Name");
                                Console.WriteLine("4 - Age");
                                Console.WriteLine("5 - Weight");
                                Console.WriteLine("6 - Growth");
                                Console.WriteLine("7 - Balance");
                                Console.WriteLine("8 - Passport");
                                Console.WriteLine("0 - Back");
                                input = Console.ReadLine();

                                if (input == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Id"]);
                                    Console.WriteLine();
                                }
                                else if (input == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Sex"]);
                                    Console.WriteLine();
                                }
                                else if (input == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Name"]);
                                    Console.WriteLine();
                                }
                                else if (input == "4")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Age"]);
                                    Console.WriteLine();
                                }
                                else if (input == "5")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Weight"]);
                                    Console.WriteLine();
                                }
                                else if (input == "6")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Growth"]);
                                    Console.WriteLine();
                                }
                                else if (input == "7")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Balance"]);
                                    Console.WriteLine();
                                }
                                else if (input == "8")
                                {
                                    Console.Clear();
                                    Console.WriteLine(human["Passport"]);
                                    Console.WriteLine();
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
                        else if(input == "0")
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
                else if (input == "4")
                {
                    Console.Clear();
                    human.BuyPass();
                }
                else if(input == "0")
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
