// CastleGame.cpp : This file contains the 'main' function. Program execution begins and ends there.

//TODO: convert from single file to multi class files

#include <iostream>
#include <unordered_map>
#include <map>
#include <algorithm>
#include <cctype>
#include <string>
#include <sstream>  
#include <set>

//using namespace std;

//Room class
struct Room
{
private:
	std::string name;
	std::string description;
	std::unordered_map<std::string, std::string> neighbours;
public:
	void makeRoom(std::string name, std::string description, std::unordered_map<std::string, std::string> neighbours) {
		this->name = name;
		this->description = description;
		this->neighbours = neighbours;
	}

	std::string getName() {
		return name;
	}

	std::string getDescription() {
		return description;
	}

	std::unordered_map<std::string, std::string>* getNeighbours() {
		return &neighbours;
	}

};


//Item class
struct Item
{
private:
	std::string name;
	std::string room;
	std::string useRoom;
	std::string pickupDesc;
	std::string useDesc;
	bool used;
public:
	//No constructor so the object can be a field instantiated from a method.
	void makeItem(std::string name, std::string room, std::string useRoom, std::string pickupDesc, std::string useDesc) {
		this->name = name;
		this->room = room;
		this->useRoom = useRoom;
		this->pickupDesc = pickupDesc;
		this->useDesc = useDesc;
		used = false;
	}

	std::string getName() {
		return name;
	}

	std::string getRoom() {
		return room;
	}

	std::string getUseRoom() {
		return useRoom;
	}

	std::string getPickupDesc() {
		return pickupDesc;
	}

	std::string getUsedDesc() {
		return useDesc;
	}

	void setUsed(bool used) {
		this->used = used;
	}
	bool getUsed() {
		return used;
	}
};

//Controller class (renamed as name already taken)
class Controller1
{
private:
	//Room objects
	Room entranceHall;
	Room corridor;
	Room kitchen;
	Room armory;
	Room ballroom;
	Room smithy;
	Room lookout;
	Room dungeon;

	//Item objects
	Item cheese;
	Item key;

	//Current room string
	std::string currentRoom;

	//List of rooms
	std::list<Room> rooms;

	//List of Items
	std::list<Item> items;

	//Bag
	std::list<std::string> bag;

	//List of directions
	std::set<std::string> directions{
		{"north"},
		{"east"},
		{"south"},
		{"west"}
	};
public:

	Controller1() {
		makeRooms();
		makeItems();
		start();
	};

	void makeRooms() {

		std::string entranceHallName = "Entrance Hall";
		std::string corridorName = "Corridor";
		std::string kitchenName = "Kitchen";
		std::string armoryName = "Armory";
		std::string ballroomName = "Ballroom";
		std::string smithyName = "Smithy";
		std::string lookoutName = "Lookout";
		std::string dungeonName = "Dungeon";

		std::string entrance_Hall_Desc = "You enter a large entrance hall with many paintings of previous owners. The faces seem to be obscured.";
		std::string corridor_Desc = "You move into a long corridor. There is a scary suit of armor that always seems to be facing you, but without moving.";
		std::string kitchen_Desc = "There is a pot bubbling on the stove in the kitchen. There is a particularly smelly piece of cheese that catches your eye.";
		std::string armory_Desc = "You find many strange looking weapons in the armory. There are many different types of armor on stands, ready to be used if needed.";
		std::string ballroom_Desc = "The ballroom is a large open expansive room. You can see a grandfather clock, a candlestick, a teapot and a teacup with a small chip.";
		std::string smithy_Desc = "In the smithy, you find multiple tools for forging armor. There appears to be a small mouse running around.";
		std::string lookout_Desc = "You find a large open window, perfect for spotting an attack. You can see a beautiful mountain range, with a river running towards the castle.";
		std::string dungeon_Desc = "You travel down a spiral stone staircase to a dank and gloomy dungeon. You can see some light shining through the cracks of a locked door.";

		std::unordered_map<std::string, std::string> entranceHallNeighbors{
			{"North","Corridor"}
		};
		std::unordered_map<std::string, std::string> corridorNeighbors{
			{"North","Armory"},
			{ "South","Entrance Hall"},
			{ "West","Kitchen"}
		};
		std::unordered_map<std::string, std::string> kitchenNeighbors{
			{"East","Corridor"}
		};
		std::unordered_map<std::string, std::string> armoryNeighbors{
			{"North","Ballroom"},
			{"South","Corridor"}
		};
		std::unordered_map<std::string, std::string> ballroomNeighbors{
			{"North","Lookout"},
			{"East","Dungeon"},
			{"South","Armory"},
			{"West","Smithy"}
		};
		std::unordered_map<std::string, std::string> smithyNeighbors{
			{"East","Ballroom"}
		};
		std::unordered_map<std::string, std::string> lookoutNeighbors{
			{"South","Ballroom"}
		};
		std::unordered_map<std::string, std::string> dungeonNeighbors{
			{"West","Ballroom"}
		};

		entranceHall.makeRoom(entranceHallName, entrance_Hall_Desc, entranceHallNeighbors);
		corridor.makeRoom(corridorName, corridor_Desc, corridorNeighbors);
		kitchen.makeRoom(kitchenName, kitchen_Desc, kitchenNeighbors);
		armory.makeRoom(armoryName, armory_Desc, armoryNeighbors);
		ballroom.makeRoom(ballroomName, ballroom_Desc, ballroomNeighbors);
		smithy.makeRoom(smithyName, smithy_Desc, smithyNeighbors);
		lookout.makeRoom(lookoutName, lookout_Desc, lookoutNeighbors);
		dungeon.makeRoom(dungeonName, dungeon_Desc, dungeonNeighbors);

		rooms.push_back(entranceHall);
		rooms.push_back(corridor);
		rooms.push_back(kitchen);
		rooms.push_back(armory);
		rooms.push_back(ballroom);
		rooms.push_back(smithy);
		rooms.push_back(lookout);
		rooms.push_back(dungeon);

	}

	void makeItems() {
		std::string cheeseName = "Cheese";
		std::string cheeseRoom = "Kitchen";
		std::string cheeseUseRoom = "Armory";
		std::string cheesePickupDesc = "You picked up the Cheese";
		std::string cheeseUseDesc = "You give the cheese to the mouse. He grabs it and runs off knocking some items from a nearby shelf. You notice a key fall from the shelf.";
		cheese.makeItem(cheeseName, cheeseRoom, cheeseUseRoom, cheesePickupDesc, cheeseUseDesc);

		std::string keyName = "Key";
		std::string keyRoom = "Armory";
		std::string keyUseRoom = "Dungeon";
		std::string keyPickupDesc = "You picked up the Key";
		std::string keyUseDesc = "Congratulations! You escaped from the spooky castle. Will you brave the castle once more and play again?";

		key.makeItem(keyName, keyRoom, keyUseRoom, keyPickupDesc, keyUseDesc);

		items.push_back(cheese);
		items.push_back(key);
	}

	void start() {
		currentRoom = "Entrance Hall";
		std::string input;
		std::cout << getRoomDescription() << "\n";
		std::cout << getDirectionString() << "\n";
		//loop while input != quit
		while (input.compare("quit") != 0) {
			std::getline(std::cin, input);
			input = lower(input);
			std::list<std::string> words = splitInput(input);

			if (directions.find(words.front()) != directions.end()) {
				move(getElement(1, words));
				std::cout << currentRoom << "\n";
				std::cout << getRoomDescription() << "\n";
				std::cout << getDirectionString() << "\n";
			}
			else if (words.front().compare("take") == 0) {
				std::string second = getElement(2, words);
				for (Item item : items) {
					//TODO: take item functionality
					if (lower(item.getName()).compare(second) == 0 && item.getRoom().compare(currentRoom) == 0) {
						//take item
						bag.push_back(item.getName());
						std::cout << "take item" << "\n";
					}
				}
			}
			else if (words.front().compare("use") == 0) {
				std::cout << "use item" << "\n";
			}
			else if (words.front().compare("bag") == 0) {
				//print contents of bag
				std::cout << getBagContents() << "\n";

			}
		}
	}

	std::list<std::string> splitInput(std::string str) {
		std::list<std::string> words; 
		std::istringstream ss(str);

		do {
			std::string word;
			ss >> word;
			words.push_back(word);
		} while (ss);

		return words;
	}

	std::string getDirectionString() {

		std::unordered_map<std::string, std::string> umap;
		for (Room room : rooms) {
			if (room.getName().compare(currentRoom) == 0) {
				umap = *room.getNeighbours();
			}
		}

		//no map insertion order retention so ordering is needed
		std::map<int, std::string> dirMap;

		for (auto i = umap.begin(); i != umap.end(); i++) {
			std::string first = i->first;   //direction
			std::string second = i->second; //room

			//convert to lower case
			first = lower(first);

			//order the directions
			if (first.compare("north") == 0) {
				dirMap[1] = first;
			}
			if (first.compare("east") == 0) {
				dirMap[2] = first;
			}
			if (first.compare("south") == 0) {
				dirMap[3] = first;
			}
			if (first.compare("west") == 0) {
				dirMap[4] = first;
			}
		}
		//grammar check
		std::string directionString;
		if (dirMap.size() > 1) {
			directionString = "Available directions are ";
		}
		else {
			directionString = "Available direction is ";
		}

		for (auto i = dirMap.begin(); i != dirMap.end(); i++) {
			directionString += i->second + ", ";
		}
		//remove the last 2 characters from string
		return directionString.substr(0, directionString.size() - 2);
	}

	std::string lower(std::string string) {
		std::transform(string.begin(), string.end(), string.begin(),
			[](unsigned char c) { return std::tolower(c); });
		return string;
	}

	void move(std::string direction) {
		bool breakOut = false; //
		for (Room room : rooms) {
			if (room.getName().compare(currentRoom) == 0) {
				std::unordered_map<std::string, std::string> neighbours = *room.getNeighbours();
				for (auto i = neighbours.begin(); i != neighbours.end(); i++) {
					if (direction.compare(lower(i->first)) == 0) {
						currentRoom = i->second;
						breakOut = true;
						break;
					}
				}
			}
			if (breakOut) {
				break;
			}
		}
	}

	std::string getRoomDescription() {
		std::string desc;
		for (Room room : rooms) {
			if (room.getName().compare(currentRoom) == 0) {
				desc = room.getDescription();
			}
		}
		return desc;
	}

	std::string getElement(int e, std::list<std::string> l) {
		std::string element = "false";
		int i = 1;
		for(std::string s : l) {
			if (e == i) {
				element = s;
				break;
			}
			i++;
		}
		return element;
	}

	std::string getBagContents() {
		std::string contents;
		std::string items;

		for (std::string item : bag) {
			items += item + ", ";
		}

		if (bag.size() > 0) {
			contents = "The bag contains: " + items.substr(0, items.size() - 2);;
		}
		else {
			contents = "The bag is empty";
		}
		return contents;
	}
};



int main()
{
	//Test test;
	Controller1 controller;

    //controller.my_new_function("foo");
    return 0;

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
