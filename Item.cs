using System;

namespace DungenGame
{
    public class Item
    {
        private string Name;
        public Item(string name)
        {
            Name = name;
        }
        
        public void CastMagicField(Room room)
        {
            room.ActivateMagicField();
        }
        
        public string GetName()
        {
            return Name;
        }
    }
}