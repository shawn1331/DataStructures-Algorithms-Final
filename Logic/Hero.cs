namespace Logic;

public class Hero
{
    public string Name { get; }
    public int MaxHealth { get; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Wisdom { get; set; }
    public Queue<Items> Inventory { get; }

    public Hero(string name, int agility, int wisdom, int strength, Items weapon)
    {
        Name = name;
        MaxHealth = Health = 20;
        Inventory = new(5);
        Inventory.Enqueue(new HealingPotion()); // Health potion heals 30% of total health
        Inventory.Enqueue(weapon);
    }

    public void AddItem(Items item)
    {
        Items? saveItem = null;
        if (Inventory.Count == 5)
        {
            if (Inventory.Peek().GetType() == typeof(Sword)  || Inventory.Peek().GetType() == typeof(Staff) || Inventory.Peek().GetType() == typeof(Bow))
            {
                saveItem = Inventory.Dequeue(); // cannot discard weapon
            }
            Inventory.Dequeue(); // Discard oldest item that isn't a weapon
        }
        Inventory.Enqueue(item);
        if(saveItem is not null)
        Inventory.Enqueue(saveItem);
    }

    public bool HasItem(Items item) => Inventory.Contains(item);

    public void DisplayInventory() => Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
}