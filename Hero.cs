using System;
using System.Collections.Generic;

namespace DungenGame
{
    public class Hero : Creature
    {
        private readonly int maxInventorySpace = 5;
        private List<Item> _inventory;
        private int _treasure;
        private Room currentRoom;

        public Hero(string name, int hitPoints, Weapon weapon, Armor armor)
        {
            Name = name;
            HitPoints = hitPoints;
            Weapon = weapon;
            Armor = armor;
            _treasure = 0;
            _inventory = new List<Item>(maxInventorySpace);
        }

        public List<Item> GetInventory()
        {
            return _inventory;
        }

        public void AddItem(Item i)
        { 
            if(_inventory.Count < maxInventorySpace) //verify you can add item to inventory
                _inventory.Add(i);
        }
        
        public Item DropItem(Item i)
        {
            _inventory.Remove(i);
            return i;
        }

        public void addTreasure(int i)
        {
            _treasure += i;
        }

        public void SetCurrentRoom(Room r)
        {
            currentRoom = r;
        }

        public Room CurrentRoom()
        {
            return currentRoom;
        }
        
        public void UsePotion(int potionAmt)
        {
            HitPoints += potionAmt;
            if (HitPoints > 100) HitPoints = 100;
        }       

    }
    
}