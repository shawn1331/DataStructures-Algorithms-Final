namespace Logic;
public class HealingPotion : Items
{
    public int HealingAmount { get; }
    public HealingPotion(int healingAmount = 6) : base ("Health Potion") { HealingAmount = healingAmount; }

    public override int ApplyTo(Hero hero)
    {
        hero.Health = Math.Min(hero.MaxHealth, hero.Health + 6);
        Console.WriteLine("You feel much better, you health has been increased by 6 points!");
        return hero.Health;
    }
}
