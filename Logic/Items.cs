namespace Logic;
public abstract class Items
{
    string Name { get; set; }

    protected Items(string name) { Name = name; }

    public virtual void ApplyTo(Hero hero) { }

    public override string ToString() => Name;
}