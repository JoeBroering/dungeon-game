using System;

namespace DungenGame
{
    public class Weapon
    {
        private string _name;
        private readonly bool _isMagical;
        private readonly int _damage;
        private int numAttack;
        private Random r = new Random();
        public Weapon(string name, int damage, int numAttack, bool isMagical)
        {
            _name = name;
            _isMagical = isMagical;
            this.numAttack = numAttack;
            _damage = damage;
        }

        public bool IsMagicalWeapon()
        {
            return _isMagical;
        }

        public int GetDamage()
        {
            return r.Next(1,_damage);
        }
        
        public int GetNumAttack()
        {
            return numAttack;
        }
    }
}