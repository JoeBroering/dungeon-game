namespace DungenGame
{
    public class Armor
    {
        private int Defence{ get; set;}
        private string _name;
        
        public Armor(string name, int defence)
        {
            _name = name;
            Defence = defence;
        }

        public int GetDefence()
        {
            return Defence;
        }
    }
}