namespace Logic;

public class MapNode
{
    public List<Edge> Edges { get; }
    public int ID { get; }

    public MapNode(int id)
    {
        Edges = new();
        ID = id;
    }

}
