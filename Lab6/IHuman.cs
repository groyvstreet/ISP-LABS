namespace Lab6
{
    interface IHuman
    {
        string Name { set; get; }
        bool Dead { set; get; }
        int Health { set; get; }
        int Armor { set; get; }
        int Money { set; get; }
        BodyType Body { set; get; }
        int FatIndex { set; get; }
        int Punch { set; get; }
        int Strength { set; get; }
        bool HaveWeapon { set; get; }
        Weapons Weapon { set; get; }
        void Fill();
        void Info();
        void TakeWeapon(Weapons weapon);
        void DropWeapon();
        void BuyArmor();
        void Eat();
        void Gym();
    }
}
