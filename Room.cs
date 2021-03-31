using System.Collections.Generic;

namespace DungenGame
{
    public class Room
    {
        private int _roomNum;
        private string _roomName;
        private Hero _player;
        private Monster _monster;
        private int _treasure;
        private Item _item;
        private bool _hasMagicDampeningField;
        private Room _entry;
        private List<Room> _exits;
        
        public Room(int roomNum, string roomName, Monster monster, int treasure, Item item, bool magicField)
        {
            _roomNum = roomNum;
            _roomName = roomName;
            _monster = monster;
            _treasure = treasure;
            _item = item;
            _hasMagicDampeningField = magicField;
        }

        public void EnterPlayer(Hero player)
        {
            _player = player;
        }

        public bool HasMagicField()
        {
            return _hasMagicDampeningField;
        }

        public void ActivateMagicField()
        {
            _hasMagicDampeningField = true;
        }

        public void SetEntryRoom(Room r)
        {
            _entry = r;
        }

        public void SetExitRooms(List<Room> r)
        {
            _exits = r;
        }

        public List<Room> GetExits()
        {
            return _exits;
        }

        public string RoomName()
        {
            return _roomName;
        }
        
        public int RoomNum()
        {
            return _roomNum;
        }

        public int Treasure()
        {
            return _treasure;
        }

        public Item Item()
        {
            return _item;
        }
        public Monster GetMonster()
        {
            return _monster;
        }
    }
}