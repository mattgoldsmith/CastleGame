#pragma once
#include <string>
#include <unordered_map>

extern std::string desc;
extern std::string description;
extern std::unordered_map<std::string, std::string> neighbours;

//Room(std::string description, std::unordered_map<std::string, std::string> neighbours);

std::string getDescription();
std::unordered_map<std::string, std::string> getNeighbours();

//class Room
//{
//protected:
//	std::string desc;
//private:
//	std::string description;
//	std::unordered_map<std::string, std::string> neighbours;
//public:
//	std::string d;
//	Room(std::string description, std::unordered_map<std::string, std::string> neighbours);
//	//{
//	//	/*this->description = description;
//	//	this->neighbours = neighbours;*/
//	//}
//
//	std::string getDescription();
//	//{
//	//	/*return description;*/
//	//}
//
//	std::unordered_map<std::string, std::string> getNeighbours();
//	//{
//	//	/*return neighbours;*/
//	//}
//};

