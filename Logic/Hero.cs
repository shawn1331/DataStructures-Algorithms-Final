namespace Logic;
public class Hero
{
    public string Name { get; }
    public int Health { get; }
    public int Agility { get; }
    public int Wisdon { get; }
    public Queue<string> Inventory { get; }

    public Hero(string name)
    {
        Name = name;
        Health = 20;
        Inventory = new();
        Inventory.Enqueue("Health Potion");
        Inventory.Enqueue("Sword");

    }
}
