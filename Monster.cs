namespace DungenGame
{
    public class Monster : Creature
    {
        public int Aggression;
        public Monster(string name, int hitPoints, Weapon weapon, Armor armor, int aggression)
        {
            Name = name;
            HitPoints = hitPoints;
            Weapon = weapon;
            Armor = armor;
            Aggression = aggression;
        }
    }
}