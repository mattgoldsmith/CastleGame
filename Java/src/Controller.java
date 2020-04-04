import java.util.*;

public class Controller {
    private ArrayList<Room> rooms;
    private ArrayList<Item> items;
    private String currentRoom;
    private ArrayList<String> keyWords;

    Controller(){
        currentRoom = "Entrance Hall";

        keyWords = new ArrayList<>();
//        keyWords.add("go");
        keyWords.add("north");
        keyWords.add("east");
        keyWords.add("south");//
        keyWords.add("west");
        keyWords.add("take");
        keyWords.add("use");
        keyWords.add("bag");
        keyWords.add("help");
        keyWords.add("quit");

        makeRooms();
        makeItems();
        startInput();
    }

    private void startInput() {
        Scanner scan = new Scanner(System.in);  // Create a Scanner object to read user input
        System.out.println("You enter a spooky castle");
        String input = "";

        System.out.println(getDescription());
        System.out.println(getDirections());

        while(!input.equals("quit")){
            input = scan.nextLine().toLowerCase();  // Read user input and convert to lowercase
            String[] words = input.split(" ");
//            System.out.println(input);
            if(keyWords.contains(words[0])){
                //TODO: Create functions for case statements
                switch(words[0]){
                    case "take":
                        System.out.println("You took the item");
                        break;
                    case "use":
                        System.out.println("You used the item");
                        break;
                    case "bag":
                        System.out.println("Items in the bag");
                        break;
                    case "help":
                        System.out.println("You can use the following commands:");
                        break;
                    case "quit":
                        System.out.println("Thank you for playing! Goodbye!");
                        break;
                    default:
                        move(words[0]);
                        System.out.println(getDescription());
                        System.out.println(getDirections());
                }
            }
            else{
                System.out.println("Please enter a direction or command.");
                System.out.println("A list of commands can be found by entering 'help'");
            }

        }

    }

    private void makeRooms() {
        //room names
        String entranceName = "Entrance Hall";
        String corridorName = "Corridor";
        String kitchenName = "Kitchen";
        String armoryName = "Armory";
        String ballroomName = "Ballroom";
        String smithyName = "Smithy";
        String lookoutName = "Lookout";
        String dungeonName = "Dungeon";

        //room neighbours
        LinkedHashMap<String,String> entranceNeighbours = new LinkedHashMap<>();
        entranceNeighbours.put("North","Corridor");

        LinkedHashMap<String,String> corridorNeighbours = new LinkedHashMap<>();
        corridorNeighbours.put("North","Armory");
        corridorNeighbours.put("South","Entrance Hall");
        corridorNeighbours.put("West","Kitchen");

        LinkedHashMap<String,String> kitchenNeighbours = new LinkedHashMap<>();
        kitchenNeighbours.put("East","Corridor");

        LinkedHashMap<String,String> armoryNeighbours = new LinkedHashMap<>();
        armoryNeighbours.put("North","Ballroom");
        armoryNeighbours.put("South","Corridor");

        LinkedHashMap<String,String> ballroomNeighbours = new LinkedHashMap<>();
        ballroomNeighbours.put("North","Lookout");
        ballroomNeighbours.put("East","Dungeon");
        ballroomNeighbours.put("South","Armory");
        ballroomNeighbours.put("West","Smithy");

        LinkedHashMap<String,String> smithyNeighbours = new LinkedHashMap<>();
        smithyNeighbours.put("East","Ballroom");

        LinkedHashMap<String,String> lookoutNeighbours = new LinkedHashMap<>();
        lookoutNeighbours.put("South","Ballroom");

        LinkedHashMap<String,String> dungeonNeighbours = new LinkedHashMap<>();
        dungeonNeighbours.put("West","Ballroom");


        //room descriptions
        String entranceDesc = "You enter a large entrance hall with many paintings of previous owners. The faces seem to be obscured.";
        String corridorDesc = "You move into a long corridor. There is a scary suit of armor that always seems to be facing you, but without moving.";
        String kitchenDesc = "There is a pot bubbling on the stove in the kitchen. There is a particularly smelly piece of cheese that catches your eye.";
        String armoryDesc = "You find many strange looking weapons in the armory. There are many different types of armor on stands, ready to be used if needed.";
        String ballroomDesc = "The ballroom is a large open expansive room. You can see a grandfather clock, a candlestick, a teapot and a teacup with a small chip.";
        String smithyDesc = "In the smithy, you find multiple tools for forging armor. There appears to be a small mouse running around.";
        String lookoutDesc = "You find a large open window, perfect for spotting an attack. You can see a beautiful mountain range, with a river running towards the castle.";
        String dungeonDesc = "You travel down a spiral stone staircase to a dank and gloomy dungeon. You can see some light shining through the cracks of a locked door.";

        //create rooms
        Room entrance = new Room(entranceName,entranceNeighbours,entranceDesc);
        Room corridor = new Room(corridorName,corridorNeighbours,corridorDesc);
        Room kitchen = new Room(kitchenName,kitchenNeighbours,kitchenDesc);
        Room armory = new Room(armoryName,armoryNeighbours,armoryDesc);
        Room ballroom = new Room(ballroomName,ballroomNeighbours,ballroomDesc);
        Room smithy = new Room(smithyName,smithyNeighbours,smithyDesc);
        Room lookout = new Room(lookoutName,lookoutNeighbours,lookoutDesc);
        Room dungeon = new Room(dungeonName,dungeonNeighbours,dungeonDesc);

        //add rooms to ArrayList
        rooms = new ArrayList<>();

        rooms.add(entrance);
        rooms.add(corridor);
        rooms.add(kitchen);
        rooms.add(armory);
        rooms.add(ballroom);
        rooms.add(smithy);
        rooms.add(lookout);
        rooms.add(dungeon);
    }

    private void makeItems() {
        String cheesePickup = "You picked up the Cheese";
        String cheeseUse = "You give the cheese to the mouse. He grabs it and runs off knocking some items from a nearby shelf. You notice a key fall from the shelf.";

        String keyPickup = "You picked up the Key";
        String keyUse = "Congratulations! You escaped from the spooky castle. Will you brave the castle once more and play again?";
        
        Item key = new Item("Cheese","Kitchen",false,cheesePickup,cheeseUse);
        Item cheese = new Item("Key","Smithy", false,keyPickup,keyUse);

        items = new ArrayList<>();
        items.add(key);
        items.add(cheese);
    }

    private void move(String direction){
        Room thisRoom = null;

        for(Room room : rooms){
            if(room.getName().equals(currentRoom)){
                thisRoom = room;
            }
        }

        assert thisRoom != null;
        HashMap<String, String> neighbours = thisRoom.getNeighbors();

        for(String dir : neighbours.keySet()){
            String room = neighbours.get(dir);

            if(dir.toLowerCase().equals(direction)){
                currentRoom = room;
            }
        }
    }

    private String getDescription(){
        String description = null;
        for(Room room: rooms){
            if(room.getName().equals(currentRoom)){
                description = room.getDescription();
            }
        }
        return description;
    }

    private String getDirections(){
        Room room = null;
        for(Room checkRoom : rooms){
            if(checkRoom.getName().equals(currentRoom)){
                room = checkRoom;
            }
        }
        System.out.println(room.getName());
        HashMap<String,String> directions = room.getNeighbors();
        String directionString = "Available directions are ";
        for(String dir : directions.keySet()){
            directionString += dir + ", ";
        }
        return directionString.substring(0, directionString.length() - 2);
    }
}
