using System;

namespace DungenGame
{
    public class Creature
    {
        protected int HitPoints { get; set;}
        protected string Name;
        protected Weapon Weapon;
        protected Armor Armor;
        private Random r = new Random();

        public string getName()
        {
            return Name;
        }

        public int GetHitPoints()
        {
            return HitPoints;
        }

        public bool IsAlive()
        {
            return HitPoints > 0;
        }

        public void Fight(Creature opponent)
        {
            while (IsAlive() && opponent.IsAlive())
            {
                for (int i = 0; i < Weapon.GetNumAttack(); i++)
                {
                    if (r.Next(20) < Armor.GetDefence())
                    {
                        opponent.TakeHit(Weapon.GetDamage());
                        Console.WriteLine(this.Name + " hit " + opponent.Name + " for " + Weapon.GetDamage() + " damage");
                    }
                }
                if(opponent.IsAlive())opponent.Fight(this);
                else Console.WriteLine(this.Name + " killed the " + opponent.Name);
            }
        }

        public void TakeHit(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
        }

    }
    
}