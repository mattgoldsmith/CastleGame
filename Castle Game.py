x = ''
Compass = ["north", "east", "south", "west"]
#Rooms = ["Entrance Hall", "Corridor", "Kitchen", "Armory", "Ballroom", "Smithy", "Lookout", "Dungeon"]
Rooms = []
#Room Neighbors
Entrance_Hall = {"North":"Corridor"}
Corridor = {"North":"Armory", "South":"Entrance Hall", "West":"Kitchen"}
Kitchen = {"East":"Corridor"}
Armory = {"North":"Ballroom", "South":"Corridor"}
Ballroom = {"North":"Lookout", "East":"Dungeon", "South":"Armory", "West":"Smithy"}
Lookout = {"South":"Ballroom"}
Dungeon = {"West":"Ballroom"}
Smithy = {"East":"Ballroom"}

Dict_Entrance_Hall = {"Entrance Hall":Entrance_Hall}
Dict_Corridor = {"Corridor":Corridor}
Dict_Kitchen = {"Kitchen":Kitchen}
Dict_Armory = {"Armory":Armory}
Dict_Ballroom = {"Ballroom":Ballroom}
Dict_Lookout = {"Lookout":Lookout}
Dict_Dungeon = {"Dungeon":Dungeon}
Dict_Smithy = {"Smithy":Smithy}

Rooms.append(Dict_Entrance_Hall)
Rooms.append(Dict_Corridor)
Rooms.append(Dict_Kitchen)
Rooms.append(Dict_Armory)
Rooms.append(Dict_Ballroom)
Rooms.append(Dict_Lookout)
Rooms.append(Dict_Dungeon)
Rooms.append(Dict_Smithy)

Dict_desc = {}

Dict_desc["Entrance Hall"] = "You are in a large entrance hall with many paintings of previous owners. The faces seem to be obscured."
Dict_desc["Corridor"] = "You enter a long corridor. There is a scary suit of armor that always seems to be facing you, but without moving."
Dict_desc["Kitchen"] = "There is a pot bubbling on the stove in the kitchen. There is a particularly smelly piece of cheese that catches your eye."
Dict_desc["Armory"] = "You find many strange looking weapons in the armory. There are many different types of armor on stands, ready to be used if needed."
Dict_desc["Ballroom"] = "The ballroom is a large open expansive room. You can see a grandfather clock, a candlestick, a teapot and a teacup with a small chip."
Dict_desc["Smithy"] = "In the smithy, you find multiple tools for forging armor. There appears to be a small mouse running around."
Dict_desc["Lookout"] = "You find a large open window, perfect for spotting an attack. You can see a beautiful mountain range, with a river running towards the castle."
Dict_desc["Dungeon"] = "You travel down a spiral stone staircase to a dank and gloomy dungeon. You can see some light shining through the cracks of a locked door."

#print(Dict_desc)

#Items
Items = {"Kitchen":"Cheese","Smithy":"Key","Dungeon":"Door"}
#Start with an empty bag. Put items in the bag
Bag = []

Current_room = "Entrance Hall"
Dict_current_room = Dict_Entrance_Hall

#return the dictionary of neigbouring rooms (String current_room)
def getNeighbours(current_room):
    for i in range(len(Rooms)):
        room = Rooms[i]
        for key in room:
            if key == current_room:
                return room[key]

#get a string of the directions (List directions)
def getDirections(directions):
    st = ''
    l = len(directions)
    for i in range(l):
        st = st + str(directions[i])
        if i < l-2:
            st = st + ", "
        if i == l-2:
            st = st + " or "
    return st

#get the direction string (List directions)
def getDirString(directions):
    st = ''
    l = len(directions)
    if l == 1:
        st = st + "Available direction is "
    else:
        st = st + "Available directions are "
    st = st + getDirections(directions)
    return st

#move the player (Dictionary current_room, String direction)
def move(current_room,direction):
    for key in current_room:
        if direction.lower() == key.lower():
            return current_room[key]

#get a description of the current room (String room)
def roomDesc(room):
    print("You are now in the " + Current_room)
    print(Dict_desc.get(room))

#get a description of the item in the room (String room)
def itemDesc(room):
    item = Items.get(room)
    if item != None:
        return item
    else:
        return "There is nothing of use in this room"
    
#Win text
def win():
    print("Congratulations! You escaped from the spooky castle. Will you brave the castle once more and play again?")

print("You enter a spooky castle")
print("You can move either North, South, East or West")
print("You must find a key to exit the castle")
print("Enter 'quit' to exit")
print("Please enter a direction to move")
print("-----------")
roomDesc(Current_room)
moved = 1
while x.lower() != "quit":
    neighbours = getNeighbours(Current_room)
    directions = []
    directions_low = []
    for key in neighbours:
        directions.append(key)
        directions_low.append(key.lower())
    st_dir = getDirString(directions)
    if moved == 1:
        print(st_dir)
    try: 
        print("-----------")
        x = str(input())
        #List the item in the room
        if x.lower() == "item":
            print(itemDesc(Current_room))
        #Take the item
        if x.lower().split()[0] == "take":
            if Items.get(Current_room) != None:
                if Items.get(Current_room).lower() == x.lower().split()[1]:
                    print("You picked up the " + Items.get(Current_room))
                    Bag.append(Items.get(Current_room))
                    Items.pop(Current_room)
                    print(Bag)
                else:
                    print("That item doesn't exist!")
            else:
                print("No useable item in this room")
        #Use item
        if x.lower().split()[0] == "use":
            if x.lower().split()[1] == "cheese" and Current_room == "Smithy" and "Cheese" in Bag:
                print("You give the cheese to the mouse. He grabs it and runs off knocking some items from a nearby shelf. You notice a key fell from the shelf.")
                Bag.remove("Cheese")
            if x.lower().split()[1] == "key" and Current_room == "Dungeon" and "Key" in Bag:
                print("You use the key on the locked door. It swings open, flooding the dungeon with fresh air. You exit the castle through the door, never to set foot inside again.")
                win()
                x = "quit"
            if x.lower().split[1] not in Bag:
                print("You don't have this item")
        #Move to a new room
        if x.lower() in directions_low:
            print("You went " + str(x))
            Current_room = move(neighbours,x)
            roomDesc(Current_room)
            moved = 1
        #Error/incorrect input
        elif x.lower().split()[0] not in ["quit","item","take","use"]:
            moved = 0
            print("You did not move a direction")
            if len(directions) > 1:
                print("Please enter available directions, either " + getDirections(directions))
            else:
                print("Please enter available direction: " + getDirections(directions))
    except ValueError:
        print("Invalid Selection")
        print("Please enter either North, South, East or West")
        
print("Goodbye. Thank you for playing!")
        
    
