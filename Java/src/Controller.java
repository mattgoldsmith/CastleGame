import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class Controller {
    private ArrayList<Room> rooms;
    private ArrayList<Item> items;

    Controller(){
        makeRooms();
        makeItems();
        startInput();
    }

    private void startInput() {
        Scanner scan = new Scanner(System.in);  // Create a Scanner object
        System.out.println("You enter a spooky castle");
        String input = "";

        while(!input.equals("quit")){
            input = scan.nextLine().toLowerCase();  // Read user input
            String[] words = input.split(" ");
            System.out.println(input);
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
        HashMap<String,String> entranceNeighbours = new HashMap<>();
        entranceNeighbours.put("North","Corridor");

        HashMap<String,String> corridorNeighbours = new HashMap<>();
        corridorNeighbours.put("North","Armory");
        corridorNeighbours.put("South","Entrance Hall");
        corridorNeighbours.put("West","Kitchen");

        HashMap<String,String> kitchenNeighbours = new HashMap<>();
        kitchenNeighbours.put("East","Corridor");

        HashMap<String,String> armoryNeighbours = new HashMap<>();
        armoryNeighbours.put("North","Ballroom");
        armoryNeighbours.put("South","Corridor");

        HashMap<String,String> ballroomNeighbours = new HashMap<>();
        ballroomNeighbours.put("North","Lookout");
        ballroomNeighbours.put("East","Dungeon");
        ballroomNeighbours.put("South","Armory");
        ballroomNeighbours.put("West","Smithy");

        HashMap<String,String> smithyNeighbours = new HashMap<>();
        smithyNeighbours.put("East","Ballroom");

        HashMap<String,String> lookoutNeighbours = new HashMap<>();
        lookoutNeighbours.put("South","Ballroom");

        HashMap<String,String> dungeonNeighbours = new HashMap<>();
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
}
