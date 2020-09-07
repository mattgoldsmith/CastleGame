import java.util.HashMap;

public class Room {


    private String name;
    private HashMap<String,String> neighbors;
    private String description;

    public Room(String name, HashMap<String,String> neighbors, String description) {
        setName(name);
        setNeighbors(neighbors);
        setDescription(description);
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public HashMap<String, String> getNeighbors() {
        return neighbors;
    }
    public void setNeighbors(HashMap<String, String> neighbors) {
        this.neighbors = neighbors;
    }

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }
}
