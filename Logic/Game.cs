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
        Dungeon.AddConnection(32, 21);
        Dungeon.AddConnection(14, 4, edgeWisdom: 10);
        Dungeon.AddConnection(18, 8, edgeItem: new Lockpick());
        Dungeon.AddConnection(23, 13, edgeAgility: 10);
        Dungeon.AddConnection(26, 16, edgeItem: new Lockpick());
        Dungeon.AddConnection(13, 23, edgeWisdom: 10);
        Dungeon.AddConnection(19, 29, edgeItem: new Lockpick());
        Dungeon.AddConnection(5, 15, edgeStrength: 10);
        Dungeon.AddConnection(7, 17, edgeItem: new Lockpick());

        for (int i = 1; i < 11; i++)
        {
            Dungeon.AddConnection(i + 1, i);
            Dungeon.AddConnection(i + 12, i + 11);
            Dungeon.AddConnection(i + 22, i + 21);
        }

        TreasureBST.AddNode(2,Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(3, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(4,Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(5,Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(6,Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(7,Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(8,Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(9,Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(10,Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(11, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(12, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(13, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(14, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(15, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(16, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(17, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(18, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(19, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(20, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(21, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(22, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(23, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(24, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(25, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(26, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(27, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(28, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(29, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(30, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(31, Challenge.Trap, Random.Shared.Next(1, 21));
    }

    public void RunGame()
    {
        MapNode current = Dungeon.Map[1];
        MapNode exit = Dungeon.Map[32];
        Dungeon.Visited.Add(current);

        while(current != exit && Hero?.Health > 0)
        {

        }
        
    }
}