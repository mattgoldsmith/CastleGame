using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CastleGame
{
    class Controller
    {
        private string input = null;
        private string currentRoom = "Entrance Hall";
        private string prevRoom;
        private List<string> roomNames = new List<string>();
        //private List<string> items = new List<string>();
        private List<Room> rooms = new List<Room>();
        private List<Item> items = new List<Item>();
        private List<Item> bag = new List<Item>();
        private List<string> keywords = new List<string>() { { "take" }, { "use" }, { "bag" } };
        //private List<string> directions = new List<string>() { { "north" }, { "east" }, { "south" }, { "west" } };
        public Controller()
        {
            //show debug messages
            bool debug = false;

            CreateRooms();
            if (debug == true)
            {
                foreach (string name in roomNames)
                {
                    Console.WriteLine(name);
                }
            }
            CreateItems();
            if (debug == true)
            {
                foreach (Item item in items)
                {
                    Console.WriteLine($"{item.GetName()}: {item.GetRoom()}");
                }
            }

            Console.WriteLine("You enter a spooky castle");
            Console.WriteLine("You can move either North, South, East or West");
            Console.WriteLine("You must find a key to exit the castle");
            Console.WriteLine("Enter 'quit' to exit");
            Console.WriteLine("Please enter a direction to move");
            Console.WriteLine("-----------");
            //Console.WriteLine("Please enter your name"); //change to relevant text
            Thread.Sleep(50);
            //Console.WriteLine($"You are currently in the {currentRoom}");
            //    Thread.Sleep(50);
            Console.WriteLine(GetRoomDescription());
                Thread.Sleep(50);
            Console.WriteLine(GetValidDirectionsString());
                Thread.Sleep(50);
            while (input != "quit")
            {
                prevRoom = currentRoom;

                Console.WriteLine("-----------");
                    Thread.Sleep(50);
                input = Console.ReadLine().ToString().ToLower().Trim();
                string[] input_words = input.Split(' ');
                if(GetValidDirections(currentRoom).Contains(input))
                {
                    Console.WriteLine($"You went {input}");
                        Thread.Sleep(50);
                    Move(input);
                    Console.WriteLine($"You are currently in the {currentRoom}");
                        Thread.Sleep(50);
                    Console.WriteLine(GetRoomDescription());
                        Thread.Sleep(50);
                    Console.WriteLine(GetValidDirectionsString());
                        Thread.Sleep(50);
                }
                if(input_words[0] == "take")
                {
                    bool itemExists = false;
                    foreach(Item item in items)
                    {
                        if(input_words[1] == item.GetName().ToLower() && item.GetTaken() == false)
                        {
                            itemExists = true;
                            if(item.GetRoom() == currentRoom)
                            {
                                Console.WriteLine($"You picked up the {item.GetName()}");
                                    Thread.Sleep(50);
                                bag.Add(item);
                                item.SetTaken(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That item doesn't exist!");
                                    Thread.Sleep(50);
                            }
                        }
                    }
                    if(itemExists == false)
                    {
                        Console.WriteLine("That item doesn't exist!");
                            Thread.Sleep(50);
                    }
                }
                if(input_words[0] == "use")
                {
                    if (bag.Count > 0)
                    {
                        bool exitFor = false;
                        foreach (Item item in bag)
                        {
                            if (input_words[1] == item.GetName().ToLower())
                            {
                                if (item.GetUseRoom() == currentRoom)
                                {
                                    foreach (Room room in rooms)
                                    {
                                        if (room.GetName() == currentRoom)
                                        {
                                            Console.WriteLine(room.GetItemUsedDesciption());
                                            Thread.Sleep(50);
                                            foreach (Item heldItem in bag)
                                            {
                                                if (heldItem.GetName().ToLower() == item.GetName().ToLower())
                                                {
                                                    bag.Remove(heldItem);
                                                    //required or a null pointer exception will occur
                                                    exitFor = true;
                                                    break; 
                                                }
                                            }
                                            if(currentRoom == "Dungeon")
                                            {
                                                input = "quit";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This isn't the time to use that!");
                                        Thread.Sleep(50);
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have this item");
                            }
                            if(exitFor == true)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bag is empty! Find an item to pick up");
                    }
                }
                if (input_words[0] == "bag")
                {
                    if(bag.Count > 0)
                    {
                        foreach(Item item in bag)
                        {
                            Console.WriteLine(item.GetName());
                                Thread.Sleep(50);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bag is empty");
                    }
                        

                }
                if (input != "quit" && GetValidDirections(prevRoom).Contains(input) == false && !keywords.Contains(input_words[0]))
                {
                    Console.WriteLine($"{input} is not a valid direction");
                        Thread.Sleep(50);
                    Console.WriteLine(GetValidDirectionsString());
                        Thread.Sleep(50);
                }
                
            }
            Console.WriteLine("Goodbye!");
                Thread.Sleep(50);
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

            string Entrance_Hall_Desc = "You enter a large entrance hall with many paintings of previous owners. The faces seem to be obscured.";
            string Corridor_Desc = "You move into a long corridor. There is a scary suit of armor that always seems to be facing you, but without moving.";
            string Kitchen_Desc = "There is a pot bubbling on the stove in the kitchen. There is a particularly smelly piece of cheese that catches your eye.";
            string Armory_Desc = "You find many strange looking weapons in the armory. There are many different types of armor on stands, ready to be used if needed.";
            string Ballroom_Desc = "The ballroom is a large open expansive room. You can see a grandfather clock, a candlestick, a teapot and a teacup with a small chip.";
            string Smithy_Desc = "In the smithy, you find multiple tools for forging armor. There appears to be a small mouse running around.";
            string Smithy_ItemUsedDesc = "You give the cheese to the mouse. He grabs it and runs off knocking some items from a nearby shelf. You notice a key fall from the shelf.";
            string Lookout_Desc = "You find a large open window, perfect for spotting an attack. You can see a beautiful mountain range, with a river running towards the castle.";
            string Dungeon_Desc = "You travel down a spiral stone staircase to a dank and gloomy dungeon. You can see some light shining through the cracks of a locked door.";
            string Dungeon_ItemUsedDesc = "Congratulations! You escaped from the spooky castle. Will you brave the castle once more and play again?";

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
            Room Smithy = new Room("Smithy", Smithy_Desc, Smithy_Neighbours, Smithy_ItemUsedDesc);
            Room Lookout = new Room("Lookout", Lookout_Desc, Lookout_Neighbours);
            Room Dungeon = new Room("Dungeon", Dungeon_Desc, Dungeon_Neighbours, Dungeon_ItemUsedDesc);

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
            //itemName, takeRoom, useRoom
            Item cheese = new Item("Cheese", "Kitchen", "Smithy");
            Item key = new Item("Key", "Smithy", "Dungeon");

            items.Add(cheese);
            items.Add(key);
        }

        private string GetValidDirectionsString()
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

        private List<string> GetValidDirections(string currRoom)
        {
            List<string> directions = new List<string>();
            foreach (Room room in rooms)
            {
                if (currRoom == room.GetName())
                {
                    foreach (KeyValuePair<string, string> entry in room.GetNeighbours())
                    {
                        directions.Add(entry.Key.ToLower());
                    }
                }
            }
            return directions;
        }

        private void Move(String direction)
        {
            foreach (Room room in rooms)
            {
                if (currentRoom == room.GetName())
                {
                    foreach (KeyValuePair<string, string> entry in room.GetNeighbours())
                    {
                        if(direction == entry.Key.ToLower())
                        {
                            currentRoom = entry.Value;
                            Console.WriteLine($"You moved to the {entry.Value}");
                                Thread.Sleep(50);
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
