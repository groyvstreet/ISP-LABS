using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    enum Statuses
    {
        Assistant,
        Junior,
        Senior
    }
    class Doctor : Human
    {
        private Statuses status;
        public Statuses Status
        {
            private set
            {
                if (value > Statuses.Senior)
                {
                    value = Statuses.Senior;
                }

                status = value;
            }
            get
            {
                return status;
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
                    Status += 1;
                    value = 0;
                }

                merit = value;
            }
            get
            {
                return merit;
            }
        }
        public Doctor()
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
            Status = Statuses.Assistant;
            Merit = 0;
            Fill();
            Console.WriteLine("Object is created!\n");
        }
        public override void Fill()
        {
            Console.Write("Enter name: ");
            this["Name"] = Console.ReadLine();
        }
        public void Heal(Gangster gangster)
        {
            if (Status == Statuses.Assistant)
            {
                gangster.AddHealth(20);
                Money += 25;
            }

            if (Status == Statuses.Junior)
            {
                gangster.AddHealth(40);
                Money += 40;
            }

            if (Status == Statuses.Senior)
            {
                gangster.AddHealth(60);
                Money += 55;
            }

            Merit += 3;
        }
        public void Heal(Police police)
        {
            if (Status == Statuses.Assistant)
            {
                police.AddHealth(20);
                Money += 120;
            }

            if (Status == Statuses.Junior)
            {
                police.AddHealth(40);
                Money += 160;
            }

            if (Status == Statuses.Senior)
            {
                police.AddHealth(60);
                Money += 200;
            }

            Merit += 6;
        }
        public void Heal(Doctor doctor)
        {
            if (Status == Statuses.Assistant)
            {
                doctor.Health += 20;
                Money += 100;
            }

            if (Status == Statuses.Junior)
            {
                doctor.Health += 40;
                Money += 125;
            }

            if (Status == Statuses.Senior)
            {
                doctor.Health += 60;
                Money += 150;
            }

            Merit += 5;
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

            Console.WriteLine("Status - " + Status);
            Console.WriteLine("Merit - " + Merit);
            Console.WriteLine("Money - " + Money + "$\n");
        }
    }
}
