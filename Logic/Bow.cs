namespace Logic;
public class Bow : Items
{
    public Bow() : base("Bow") { }

    public override int ApplyTo(Hero hero) => throw new InvalidOperationException("Weapons cannot be used this way.");
}
