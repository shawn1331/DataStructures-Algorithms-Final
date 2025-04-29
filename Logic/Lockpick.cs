namespace Logic;
internal class Lockpick : Items
{
    public Lockpick() : base("Lockpick") { }

    public override int ApplyTo(Hero hero) => throw new InvalidOperationException("Lockpicks cannot be used this way.");
}
