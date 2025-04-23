namespace Logic;
public class StatGem : Items
{
    public int StatAmount { get; }
    public StatGem(int statAmount = 5) : base("StatGem") { StatAmount = statAmount; }

    public override void ApplyTo(Hero hero)
    {
        string? result = null;
        Console.WriteLine("Choose a stat to boost: Strength, Agility, Intelligence");
        string? choice = Console.ReadLine()?.Trim().ToLower();

        if (choice is not null)
        {
            result = choice switch
            {
                "strength" => IncreaseStat(() => hero.Strength += 5, "Strength"),
                "agility" => IncreaseStat(() => hero.Agility += 5, "Agility"),
                "intelligence" => IncreaseStat(() => hero.Wisdom += 5, "Intelligence"),
                _ => "Invalid choice. No stat increased."
            };
        }

        Console.WriteLine(result);
    }

    private string IncreaseStat(Action increaseAction, string statName)
    {
        increaseAction();
        return $"{statName} increased by 5!";
    }
}
