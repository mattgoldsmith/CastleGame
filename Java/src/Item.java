public class Item {
    private String name;
    private String room;
    private String useRoom;
    private boolean taken;
    private String pickup;
    private String use;

    public Item(String name, String room, String useRoom, boolean taken, String pickup, String use){
        setName(name);
        setRoom(room);
        setUseRoom(useRoom);
        setTaken(taken);
        setPickup(pickup);
        setUse(use);
    }

    private void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }

    private void setRoom(String room){
        this.room = room;
    }
    public String getRoom() {
        return room;
    }

    private void setUseRoom(String useRoom){
        this.useRoom = useRoom;
    }
    public String getUseRoom(){
        return useRoom;
    }

    public void setTaken(boolean taken) {
        this.taken = taken;
    }
    public Boolean getTaken() {
        return taken;
    }

    public void setPickup(String pickup) {
        this.pickup = pickup;
    }
    public String getPickup() {
        return pickup;
    }

    public void setUse(String use) {
        this.use = use;
    }
    public String getUse() {
        return use;
    }
}
