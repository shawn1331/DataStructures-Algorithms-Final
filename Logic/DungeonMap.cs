namespace Logic;

public class DungeonMap
{
    public Dictionary<int, MapNode> Map { get; }
    public Stack<Items> RoomTreasures { get; }

    public DungeonMap()
    { 
        Map = new(); 
        RoomTreasures = new();
        RoomTreasures.Push(new Lockpick());
        RoomTreasures.Push(new StatGem());
        RoomTreasures.Push(new HealingPotion());
    }

    public void AddRoom(int id)
    {
        if (!Map.ContainsKey(id))
            Map[id] = new MapNode(id);
        else
            Console.WriteLine("This id already exists.");
    }

    public void RemoveRoom(int id)
    {
        if (Map.ContainsKey(id))
            Map.Remove(id);
        else
            Console.WriteLine("This id does not exists.");
    }

    public void AddConnection(int toID, int fromID)
    {
        if(Map.ContainsKey(toID) && Map.ContainsKey(fromID))
        {
            Map[fromID].Edges.Add(new Edge(Map[toID]));
            Console.WriteLine($"The edge from {fromID} to {toID} has been added.");
        }
        else
            Console.WriteLine("One or both of these id's do not exist.");
    }

    public void RemoveConnection(int toID, int fromID)
    {
        if(Map.ContainsKey(toID) && Map.ContainsKey(fromID))
        {
            Edge? edgeToRemove = Map[fromID].Edges.FirstOrDefault(e => e.Destination.ID == toID);

            if (edgeToRemove != null)
            Map[fromID].Edges.Remove(edgeToRemove);
            Console.WriteLine($"The edge from {fromID} to {toID} has been removed.");
        }
        else
            Console.WriteLine("One or both of these id's do not exist.");

    }
}