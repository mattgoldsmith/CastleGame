import java.util.Scanner;

public class Controller {
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
//            System.out.println("Username is: " + input);  // Output user input
            String[] words = input.split(" ");
            for (String word : words) {
                System.out.println(word);
            }
        }

    }

    private void makeRooms() {
        //TODO add functionality to make the rooms + descriptions
    }

    private void makeItems() {
        //TODO add functionality to make the items + descriptions
    }
}
