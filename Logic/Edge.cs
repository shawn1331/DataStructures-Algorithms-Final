namespace Logic;
public class Edge
{
    public MapNode Destination { get; }
    public int? RequiredStrength { get; set; }
    public int? RequiredAgility { get; set; }
    public int? RequiredWisdom { get; set; }
    public Items? RequiredItem { get; set; }

    public Edge(MapNode toNode, int? requiredStrength = null, int? requiredAgility = null, int? requiredWisdom = null, Items? requiredItem = null )
    {
        Destination = toNode;
        RequiredStrength = requiredStrength;
        RequiredAgility = requiredAgility;  
        RequiredWisdom = requiredWisdom;
        RequiredItem = requiredItem;
    }

    public bool CanTraverse(Hero hero)
    {
        if (RequiredStrength.HasValue && hero.Strength < RequiredStrength)
            return false;
        if (RequiredAgility.HasValue && hero.Agility < RequiredAgility)
            return false;
        if (RequiredWisdom.HasValue && hero.Wisdom < RequiredWisdom)
            return false;
        if (RequiredItem != null && !hero.HasItem(RequiredItem))
            return false;
        return true;
    }
}
