namespace Logic;
public class Edge
{
    public MapNode Destination { get; }
    public int? RequiredStrength { get; set; }
    public int? RequiredAgility { get; set; }
    public int? RequiredIntelligence { get; set; }
    public string? RequiredItem { get; set; }

    public Edge(MapNode to) {  Destination = to; }

    public bool CanTraverse(Hero hero)
    {
        if (RequiredStrength.HasValue && hero.Strength < RequiredStrength)
            return false;
        if (RequiredAgility.HasValue && hero.Agility < RequiredAgility)
            return false;
        if (RequiredIntelligence.HasValue && hero.Wisdom < RequiredIntelligence)
            return false;
        if (!string.IsNullOrEmpty(RequiredItem) && !hero.HasItem(RequiredItem))
            return false;
        return true;
    }
}
