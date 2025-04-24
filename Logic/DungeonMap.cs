namespace Logic;
public class DungeonMap
{
    public Dictionary<int, MapNode> Map { get; }
    public Stack<Items> RoomTreasures { get; }
    public HashSet<BSTNode> Visited { get; }

    public DungeonMap()
    {
        Map = new();
        RoomTreasures = new();
        Visited = new();
        RoomTreasures.Push(new HealingPotion());
        RoomTreasures.Push(new StatGem());
        RoomTreasures.Push(new Lockpick());
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

    public void AddConnection(int toID, int fromID, int? edgeStrength = null, int? edgeAgility = null, int? edgeWisdom = null, Items? edgeItem = null)
    {
        if (Map.ContainsKey(toID) && Map.ContainsKey(fromID))
        {
            Map[fromID].Edges.Add(new Edge(Map[toID], edgeStrength, edgeAgility, edgeWisdom, edgeItem));
            Console.WriteLine($"The edge from {fromID} to {toID} has been added.");
        }
        else
            Console.WriteLine("One or both of these id's do not exist.");
    }

    public void RemoveConnection(int toID, int fromID)
    {
        if (Map.ContainsKey(toID) && Map.ContainsKey(fromID))
        {
            Edge? edgeToRemove = Map[fromID].Edges.FirstOrDefault(e => e.Destination.ID == toID);

            if (edgeToRemove != null)
                Map[fromID].Edges.Remove(edgeToRemove);
            Console.WriteLine($"The edge from {fromID} to {toID} has been removed.");
        }
        else
            Console.WriteLine("One or both of these id's do not exist.");

    }

    public Items? FindTreasure() => Random.Shared.Next(10) == 0 ? RoomTreasures.Pop() : null;

    public List<MapNode> BFS(int startID, int exitID)
    {
        List<MapNode> path = new();
        MapNode startNode = Map[startID];
        MapNode endNode = Map[exitID];
        HashSet<MapNode> visited = new();
        Dictionary<MapNode, MapNode> previousNodes = new(); // key is the node and the value is the previous node
        previousNodes[startNode] = startNode;
        Queue<MapNode> queue = new();
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            MapNode node = queue.Dequeue();

            if (node == endNode)
            {
                visited.Add(node);
                break;
            }
            else
            {
                foreach (Edge edge in node.Edges)
                {
                    MapNode neighbor = edge.Destination;

                    if (!queue.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        previousNodes[neighbor] = node;
                    }
                }
            }
        }

        MapNode current = Map[exitID];

        while(current != startNode)
        {
            path.Add(current);
            current = previousNodes[current];
        }

        path.Add(startNode);
        path.Reverse();
        return path;
    }
}