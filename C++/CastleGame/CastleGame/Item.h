#pragma once
#include <string>
class Item
{
private:
	std::string name;
	std::string room;
	std::string useRoom;
	std::string pickupDesc;
	std::string useDesc;
	bool used;
public:
	Item(std::string name, std::string room, std::string useRoom, std::string pickupDesc, std::string useDesc) {
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

