using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> people = new List<Human>
            {
                new Gangster(),
                new Police(),
                new Doctor()
            };
            Human gSave = people[0];
            Human pSave = people[1];
            Human dSave = people[2];
            string input;

            while (true)
            {
                Console.WriteLine("1 - Gangster: " + people[0]["Name"]);
                Console.WriteLine("2 - Police: " + people[1]["Name"]);
                Console.WriteLine("3 - Doctor: " + people[2]["Name"]);
                input = Console.ReadLine();
                bool run;
                Console.Clear();

                switch (input)
                {
                    case "1":
                        run = true;

                        while (run)
                        {
                            Console.WriteLine("1 - Info");
                            Console.WriteLine("2 - Take the weapon");
                            Console.WriteLine("3 - Drop the weapon");
                            Console.WriteLine("4 - Buy Armor");
                            Console.WriteLine("5 - Eat");
                            Console.WriteLine("6 - Gym");
                            Console.WriteLine("7 - Theft the auto");
                            Console.WriteLine("8 - Rob the shop");
                            Console.WriteLine("9 - Paint the graffiti");
                            Console.WriteLine("10 - Buy the spray");
                            Console.WriteLine("11 - Attack the police");
                            Console.WriteLine("12 - Save state");
                            Console.WriteLine("13 - Load state");
                            Console.WriteLine("0 - Back");
                            input = Console.ReadLine();
                            Console.Clear();

                            switch (input)
                            {
                                case "1":
                                    people[0].Info();
                                    break;
                                case "2":
                                    people[0].TakeWeapon(Weapons.MicroUzi);
                                    break;
                                case "3":
                                    people[0].DropWeapon();
                                    break;
                                case "4":
                                    people[0].BuyArmor();
                                    break;
                                case "5":
                                    people[0].Eat();
                                    break;
                                case "6":
                                    people[0].Gym();
                                    break;
                                case "7":
                                    Gangster temp = (Gangster)people[0];
                                    temp.TheftAuto();
                                    people[0] = temp;
                                    break;
                                case "8":
                                    temp = (Gangster)people[0];
                                    temp.RobShop();
                                    people[0] = temp;
                                    break;
                                case "9":
                                    temp = (Gangster)people[0];
                                    temp.PaintGraffiti();
                                    people[0] = temp;
                                    break;
                                case "10":
                                    temp = (Gangster)people[0];
                                    temp.BuySpray();
                                    people[0] = temp;
                                    break;
                                case "11":
                                    temp = (Gangster)people[0];
                                    Police temp2 = (Police)people[1];
                                    temp.Attack(temp2, temp.Weapon);
                                    people[0] = temp;
                                    people[1] = temp2;
                                    break;
                                case "12":
                                    gSave = people[0].Clone() as Human;
                                    break;
                                case "13":
                                    people[0] = gSave;
                                    break;
                                case "0":
                                    run = false;
                                    break;
                            }
                        }

                        break;

                    case "2":
                        run = true;

                        while (run)
                        {
                            Console.WriteLine("1 - Info");
                            Console.WriteLine("2 - Take the weapon");
                            Console.WriteLine("3 - Drop the weapon");
                            Console.WriteLine("4 - Buy Armor");
                            Console.WriteLine("5 - Eat");
                            Console.WriteLine("6 - Gym");
                            Console.WriteLine("7 - Arrest the gangster");
                            Console.WriteLine("8 - Attack the gangster");
                            Console.WriteLine("9 - Save state");
                            Console.WriteLine("10 - Load state");
                            Console.WriteLine("0 - Back");
                            input = Console.ReadLine();
                            Console.Clear();

                            switch (input)
                            {
                                case "1":
                                    people[1].Info();
                                    break;
                                case "2":
                                    people[1].TakeWeapon(Weapons.MP5);
                                    break;
                                case "3":
                                    people[1].DropWeapon();
                                    break;
                                case "4":
                                    people[1].BuyArmor();
                                    break;
                                case "5":
                                    people[1].Eat();
                                    break;
                                case "6":
                                    people[1].Gym();
                                    break;
                                case "7":
                                    Police temp = (Police)people[1];
                                    Gangster temp2 = (Gangster)people[0];
                                    temp.Arrest(temp2);
                                    people[1] = temp;
                                    people[0] = temp2;
                                    break;
                                case "8":
                                    temp = (Police)people[1];
                                    temp2 = (Gangster)people[0];
                                    temp.Attack(temp2, temp.Weapon);
                                    people[1] = temp;
                                    people[0] = temp2;
                                    break;
                                case "9":
                                    pSave = people[1].Clone() as Human;
                                    break;
                                case "10":
                                    people[1] = pSave;
                                    break;
                                case "0":
                                    run = false;
                                    break;
                            }
                        }

                        break;

                    case "3":
                        run = true;

                        while (run)
                        {
                            Console.WriteLine("1 - Info");
                            Console.WriteLine("2 - Buy Armor");
                            Console.WriteLine("3 - Eat");
                            Console.WriteLine("4 - Gym");
                            Console.WriteLine("5 - Heal the gangster");
                            Console.WriteLine("6 - Heal the police");
                            Console.WriteLine("7 - Save state");
                            Console.WriteLine("8 - Load state");
                            Console.WriteLine("0 - Back");
                            input = Console.ReadLine();
                            Console.Clear();

                            switch (input)
                            {
                                case "1":
                                    people[2].Info();
                                    break;
                                case "2":
                                    people[2].BuyArmor();
                                    break;
                                case "3":
                                    people[2].Eat();
                                    break;
                                case "4":
                                    people[2].Gym();
                                    break;
                                case "5":
                                    Doctor temp = (Doctor)people[2];
                                    Gangster temp2 = (Gangster)people[0];
                                    temp.Heal(temp2);
                                    people[2] = temp;
                                    people[0] = temp2;
                                    break;
                                case "6":
                                    temp = (Doctor)people[2];
                                    Police temp3 = (Police)people[1];
                                    temp.Heal(temp3);
                                    people[2] = temp;
                                    people[1] = temp3;
                                    break;
                                case "7":
                                    dSave = people[2].Clone() as Human;
                                    break;
                                case "8":
                                    people[2] = dSave;
                                    break;
                                case "0":
                                    run = false;
                                    break;
                            }
                        }

                        break;
                }
            }
        }
    }
}
