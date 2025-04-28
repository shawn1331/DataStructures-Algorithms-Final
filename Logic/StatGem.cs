namespace Logic;
public class StatGem : Items
{
    public int StatAmount { get; }
    public StatGem(int statAmount = 5) : base("StatGem") { StatAmount = statAmount; }

    public override int ApplyTo(Hero hero)
    {
        return StatAmount;
    }
}
