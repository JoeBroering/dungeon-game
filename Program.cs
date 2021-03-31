using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungenGame
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int hitPoints = 100;
            
            // Weapon
            var bSword = new Weapon("Buster Sword", 30, 2, false);
            var claws = new Weapon("claws",15,3,false);
            var plasmaCutter = new Weapon("211-V Plasma Cutter", 70, 1, false);
            var crowBar = new Weapon("Crowbar", 10, 3, false);
            var hiddenBlade = new Weapon("Hidden Blade", 25, 2, false);
            var bladesOfChaos = new Weapon("Blades Of Chaos", 40, 2, false);

            // Armor
            var nanoSuit = new Armor("Nano suit",8);
            var powerSuit = new Armor("Power Suit",6);
            var daedricArmor = new Armor("Daedric Armor",7);
            var armorOfAltair = new Armor("Armor of Altair",5);
            var berserkerArmor = new Armor("Berserker Armor",9);
            var hide = new Armor("Hide", 3);
            
            
            // Items
            var doll = new Item("Doll");
            var gemStone = new Item("Gem Stone");
            var thunderScroll = new Item("Thunder Scroll");
            var fireScroll = new Item("Fire Scroll");
            var potion = new Item("Potion");
            
            // player
            var player = new Hero("Hero",hitPoints, bladesOfChaos, powerSuit);
            
            // Monsters
            var assassin = new Monster("assassin",hitPoints,hiddenBlade,armorOfAltair,5);
            var wolf = new Monster("wolf",hitPoints,claws,hide,30);
            var sephiroth = new Monster("sephiroth",hitPoints, bSword, berserkerArmor, 100);
            
            // Rooms
            var startRoom = new Room(0,"Starting Room", null, 10,potion,false);
            var room1 = new Room(1,"Room 1", wolf, 10,potion,false);
            var room2 = new Room(2,"Room 2", wolf, 5,potion,false);
            var room3 = new Room(3,"Room 3", assassin, 30,potion,true);
            var room4 = new Room(4,"Room 4", wolf, 5,potion,false);
            var room5 = new Room(5,"Room 5", assassin, 4,potion,true);
            var room6 = new Room(6,"Room 6", assassin, 5,potion,true);
            var room7 = new Room(7,"Room 7", wolf, 6,potion,false);
            var room8 = new Room(8,"Boss Room", sephiroth, 100,potion,true);
            
            // Connecting Rooms
            var startRoomList = new List<Room> {room1};
            var room1List = new List<Room> {room2};
            var room2List = new List<Room> {room3};
            var room3List = new List<Room> {room4};
            var room4List = new List<Room> {room5};
            var room5List = new List<Room> {room6};
            var room6List = new List<Room> {room7};
            var room7List = new List<Room> {room8};
            var room8List = new List<Room> {};

            startRoom.SetExitRooms(startRoomList);
            room1.SetExitRooms(room1List);
            room2.SetExitRooms(room2List);
            room3.SetExitRooms(room3List);
            room4.SetExitRooms(room4List);
            room5.SetExitRooms(room5List);
            room6.SetExitRooms(room6List);
            room7.SetExitRooms(room7List);
            room8.SetExitRooms(room8List);
            
            // Test
            //player.Fight(assassin);
            //Console.WriteLine("Player: " + player.GetHitPoints());
            //Console.WriteLine("Monster: " + assassin.GetHitPoints());
            
            //player.Fight(wolf);
            //Console.WriteLine("Player: " + player.GetHitPoints());
            //Console.WriteLine("Monster: " + wolf.GetHitPoints());
            
            
            // GamePlay
            var isComplete = false;
            player.SetCurrentRoom(startRoom);



            while (true)
            {
                Console.WriteLine("Choose a room to enter");

                for (var i = 0; i < player.CurrentRoom().GetExits().Count; i++) //for loop validates room
                {
                    if (player.CurrentRoom().GetExits().Count != 0) ListExits(player); //list exits for player
                    else Console.WriteLine("No Exits");
                    var roomNumber = Convert.ToInt32(Console.ReadLine());
                    if (player.CurrentRoom().GetExits()[i].RoomNum() == roomNumber)
                    {
                        player.SetCurrentRoom(player.CurrentRoom()
                            .GetExits()[i]); //set current room to the matching roomNum player entered
                        break;
                    }
                    else Console.WriteLine("No Match");
                }

                Console.WriteLine("You entered " + player.CurrentRoom().RoomName());
                Monster currentMonster = player.CurrentRoom().GetMonster();
                Console.WriteLine("In Room 1, you find a " + currentMonster.getName() + ".");
                Console.WriteLine("You fight");
                player.Fight(currentMonster); //fight method with player and monster
                if (!player.IsAlive())
                {
                    Console.WriteLine("Game Over"); //break out of game loop if you die
                    // break out of loop
                }
                else Console.WriteLine("You have " + player.GetHitPoints() + " health left");

                Console.WriteLine("You collect " + player.CurrentRoom().Treasure() + " treasure from the room.");
                player.addTreasure(player.CurrentRoom().Treasure()); //adds treasure to inventory
                Console.WriteLine("You collect a potion.");
                player.AddItem(player.CurrentRoom().Item());
                if (player.GetInventory().Count != 0)
                {
                    Console.WriteLine("Use a potion? It will restore 30 health.  (y/n)");
                    string response = Console.ReadLine();
                    if (response.Equals("y"))
                    {
                        player.UsePotion(30);
                        Console.WriteLine("You now have " + player.GetHitPoints() + " health");
                    }

                }
            }//closes game loop



        }

        public static void ListExits(Hero player)
        {
            for (var i = 0; i < player.CurrentRoom().GetExits().Count; i++)
            {
                Console.WriteLine("List of Rooms you can go to.");
                Console.WriteLine(i+1 + ": " + player.CurrentRoom().GetExits()[i].RoomName());
            }
        }
    }
}