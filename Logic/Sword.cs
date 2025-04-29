namespace Logic;
public class Sword : Items
{
    public Sword() : base("Sword") { }

    public override int ApplyTo(Hero hero) => throw new InvalidOperationException("Weapons cannot be used this way.");
}
