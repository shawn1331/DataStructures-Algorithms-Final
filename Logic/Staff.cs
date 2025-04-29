namespace Logic;
public class Staff : Items
{
    public Staff() : base("Staff") { }

    public override int ApplyTo(Hero hero) => throw new InvalidOperationException("Weapons cannot be used this way.");
}
