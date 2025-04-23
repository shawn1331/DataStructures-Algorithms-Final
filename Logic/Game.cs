namespace Logic;

public class Game
{
    public Hero? Hero { get; }
    public DungeonMap? Dungeon { get; }
    public ChallengeBST? TreasureBST { get; }

    public Game(Hero? hero)
    {
        Hero = hero;
        Dungeon = new();
        TreasureBST = new();
        for (int i = 1; i < 33; i++)
        {
            Dungeon.AddRoom(i);
        }
        Dungeon.AddConnection(12, 1);
        Dungeon.AddConnection(22, 1);
        Dungeon.AddConnection(32, 11);
        Dungeon.AddConnection(32, 22);
        Dungeon.AddConnection(32, 31);
        for (int i = 1; i < 11; i++)
        {
            Dungeon.AddConnection(i + 1, i);
            Dungeon.AddConnection(i + 12, i + 11);
            Dungeon.AddConnection(i + 22, i + 21);
        }


    }
}
