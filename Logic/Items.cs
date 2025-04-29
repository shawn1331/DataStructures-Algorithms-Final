namespace Logic;
public abstract class Items
{
   public string Name { get; }

    protected Items(string name) { Name = name; }

    public abstract int ApplyTo(Hero hero);

    public override string ToString() => Name;
}