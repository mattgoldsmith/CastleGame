using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGame
{
    class Controller
    {
        private string input = null;
        private string currentRoom = "Entrance Hall";
        private List<string> roomNames = new List<string>();
        //private List<string> items = new List<string>();
        private List<Room> rooms = new List<Room>();
        private List<Item> items = new List<Item>();
        private List<Item> bag = new List<Item>();
        private List<string> directions = new List<string>() { { "north" }, { "east" }, { "south" }, { "west" } };
        public Controller()
        {
            CreateRooms();
            foreach (string name in roomNames)
            {
                Console.WriteLine(name);
            }
            CreateItems();
            foreach (Item item in items)
            {
                Console.WriteLine($"{item.GetName()}: {item.GetRoom()}");
            }
            Console.WriteLine("Please enter your name"); //change to relevant text
            while (input != "quit")
            {
                Console.WriteLine($"You are currently in the {currentRoom}");
                Console.WriteLine(GetRoomDescription());
                Console.WriteLine(GetValidDirections());
                input = Console.ReadLine().ToString().ToLower();
                if(directions.Contains(input))
                {
                    Console.WriteLine($"You went {input}");
                    Move(input);
                }
                if(input != "quit" && directions.Contains(input) == false)
                {
                    Console.WriteLine($"{input} is not a valid direction");
                    Console.WriteLine(GetValidDirections());
                }
                
            }
            Console.WriteLine("Goodbye!");
        }

        private void CreateRooms()
        {
            roomNames.Add("Entrance Hall");
            roomNames.Add("Corridor");
            roomNames.Add("Kitchen");
            roomNames.Add("Armory");
            roomNames.Add("Ballroom");
            roomNames.Add("Smithy");
            roomNames.Add("Lookout");
            roomNames.Add("Dungeon");

            string Entrance_Hall_Desc = "You are in a large entrance hall with many paintings of previous owners. The faces seem to be obscured.";
            string Corridor_Desc = "You enter a long corridor. There is a scary suit of armor that always seems to be facing you, but without moving.";
            string Kitchen_Desc = "There is a pot bubbling on the stove in the kitchen. There is a particularly smelly piece of cheese that catches your eye.";
            string Armory_Desc = "You find many strange looking weapons in the armory. There are many different types of armor on stands, ready to be used if needed.";
            string Ballroom_Desc = "The ballroom is a large open expansive room. You can see a grandfather clock, a candlestick, a teapot and a teacup with a small chip.";
            string Smithy_Desc = "In the smithy, you find multiple tools for forging armor. There appears to be a small mouse running around.";
            string Lookout_Desc = "You find a large open window, perfect for spotting an attack. You can see a beautiful mountain range, with a river running towards the castle.";
            string Dungeon_Desc = "You travel down a spiral stone staircase to a dank and gloomy dungeon. You can see some light shining through the cracks of a locked door.";

            Dictionary<string, string> Entrance_Hall_Neighbours = new Dictionary<string, string>()
            {
                {"North","Corridor"}
            };
            Dictionary<string, string> Corridor_Neighbours = new Dictionary<string, string>()
            {
                {"North","Armory"},
                { "South","Entrance Hall"},
                { "West","Kitchen"}
            };
            Dictionary<string, string> Kitchen_Neighbours = new Dictionary<string, string>()
            {
                {"East","Corridor"}
            };
            Dictionary<string, string> Armory_Neighbours = new Dictionary<string, string>()
            {
                {"North","Ballroom"},
                {"South","Corridor"}
            };
            Dictionary<string, string> Ballroom_Neighbours = new Dictionary<string, string>()
            {
                {"North","Lookout"},
                {"East","Dungeon"}, 
                {"South","Armory"}, 
                {"West","Smithy"}
            };
            Dictionary<string, string> Smithy_Neighbours = new Dictionary<string, string>() 
            {
                {"East","Ballroom"}
            };
            Dictionary<string, string> Lookout_Neighbours = new Dictionary<string, string>() 
            { 
                {"South","Ballroom"}
            };
            Dictionary<string, string> Dungeon_Neighbours = new Dictionary<string, string>() 
            {
                {"West","Ballroom"}
            };

            Room Entrance_Hall = new Room("Entrance Hall", Entrance_Hall_Desc, Entrance_Hall_Neighbours);
            Room Corridor = new Room("Corridor", Corridor_Desc, Corridor_Neighbours);
            Room Kitchen = new Room("Kitchen", Kitchen_Desc,Kitchen_Neighbours );
            Room Armory = new Room("Armory", Armory_Desc,Armory_Neighbours);
            Room Ballroom = new Room("Ballroom", Ballroom_Desc, Ballroom_Neighbours);
            Room Smithy = new Room("Smithy", Smithy_Desc, Smithy_Neighbours);
            Room Lookout = new Room("Lookout", Lookout_Desc, Lookout_Neighbours);
            Room Dungeon = new Room("Dungeon", Dungeon_Desc, Dungeon_Neighbours);

            rooms.Add(Entrance_Hall);
            rooms.Add(Corridor);
            rooms.Add(Kitchen);
            rooms.Add(Armory);
            rooms.Add(Ballroom);
            rooms.Add(Smithy);
            rooms.Add(Lookout);
            rooms.Add(Dungeon);
        }

        private void CreateItems()
        {
            Item cheese = new Item("Cheese", "Kitchen");
            Item key = new Item("Key", "Smithy");

            items.Add(cheese);
            items.Add(key);
        }

        private string GetValidDirections()
        {
            string text = "No valid directions";
            foreach (Room room in rooms)
            {
                if(currentRoom == room.GetName())
                {
                    if (room.GetNeighbours().Count > 1)
                    {
                        text = "Available directions are ";
                    }
                    else
                    {
                        text = "Available direction is ";
                    }
                    foreach (KeyValuePair<string, string> entry in room.GetNeighbours())
                    {
                        //TODO Add a check for the last entry so the last two characters do not have to be removed later
                        text += $"{entry.Key}, ";
                    }
                }
            }
            //remove the last two characters from string (", ")
            return text[0..^2];
        }

        private void Move(String direction)
        {
            foreach (Room room in rooms)
            {
                if (currentRoom == room.GetName())
                {
                    Console.WriteLine("CurrentRoom");
                    foreach (KeyValuePair<string, string> entry in room.GetNeighbours())
                    {
                        if(direction == entry.Key.ToLower())
                        {
                            currentRoom = entry.Value;
                            Console.WriteLine($"You moved to the {entry.Value}");
                        }
                    }
                    break;
                }
            }
        }

        private string GetRoomDescription()
        {   string desc = "";
            foreach (Room room in rooms)
            {
                if(room.GetName() == currentRoom)
                {
                    desc = room.GetDesciption();
                }
            }
            return desc;
        }
    }
}
