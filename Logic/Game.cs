using System.Numerics;

namespace Logic;
public class Game
{
    public Hero? Hero { get; }
    public DungeonMap Dungeon { get; }
    public ChallengeBST TreasureBST { get; }
    public delegate int GetInputDelegate();
    public GetInputDelegate GetDirectionInput;
    public GetInputDelegate GetStatInput;
    public GetInputDelegate GetInitialDirectionInput;
    public delegate char GetCharInputDelegate();
    public GetCharInputDelegate GetCharChoice;

    public Game(Hero? hero, GetInputDelegate getInputDelegate, GetInputDelegate getStatInput, GetInputDelegate getInitialDirectionInput, GetCharInputDelegate getCharChoice)
    {
        Hero = hero;
        Dungeon = new();
        TreasureBST = new();
        GetDirectionInput = getInputDelegate;
        GetStatInput = getStatInput;
        GetInitialDirectionInput = getInitialDirectionInput;
        GetCharChoice = getCharChoice;

        for (int i = 1; i < 33; i++)
        {
            Dungeon.AddRoom(i);
        }

        Dungeon.AddConnection(12, 1);
        Dungeon.AddConnection(22, 1);
        Dungeon.AddConnection(32, 11);
        Dungeon.AddConnection(32, 21);
        Dungeon.AddConnection(15, 4, edgeWisdom: 10);
        Dungeon.AddConnection(19, 8, edgeItem: new Lockpick());
        Dungeon.AddConnection(24, 13, edgeAgility: 10);
        Dungeon.AddConnection(27, 16, edgeItem: new Lockpick());
        Dungeon.AddConnection(14, 23, edgeWisdom: 10);
        Dungeon.AddConnection(20, 29, edgeItem: new Lockpick());
        Dungeon.AddConnection(6, 15, edgeStrength: 10);
        Dungeon.AddConnection(8, 17, edgeItem: new Lockpick());

        for (int i = 1; i < 11; i++)
        {
            Dungeon.AddConnection(i + 1, i);
            Dungeon.AddConnection(i + 12, i + 11);
            Dungeon.AddConnection(i + 22, i + 21);
        }

        TreasureBST.AddNode(2, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(3, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(4, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(5, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(6, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(7, Challenge.Trap, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(8, Challenge.Puzzle, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(9, Challenge.Combat, Random.Shared.Next(1, 21));
        TreasureBST.AddNode(10, Challenge.Trap, Random.Shared.Next(1, 21));
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
        int mapID = 1;
        MapNode start = Dungeon.Map[mapID];
        MapNode exit = Dungeon.Map[32];
        MapNode current = start;
        Dungeon.Visited.Add(current);
        List<MapNode> directionsToTravel = new();

        Console.WriteLine(@"You have entered the first room of the dungeon. You see before you 3 branching paths,
each room is filled with deadly monsters, traps, and puzzels that you must brave to reach the exit.
These encounters have a difficulty, if the required stat is below the difficulty you will lose that much health.
You have been warned!");

        int choice = GetInitialDirection();
        current = choice switch
        {
            1 => Dungeon.Map[2],
            2 => Dungeon.Map[12],
            3 => Dungeon.Map[22],
            _ => Dungeon.Map[2]
        };

        mapID = current.ID;
        Dungeon.Visited.Add(current);

        while (current != exit && Hero?.Health > 0)
        {
            BSTNode? currentChallenge = TreasureBST.GetChallenge(current.ID);


            Items? treasureFound = Dungeon.FindTreasure();

            if (treasureFound != null)
            {
                Console.WriteLine($"You found some treasure in this room! You found {treasureFound.Name}");
                Hero.AddItem(treasureFound);
            }

            Console.WriteLine($"Would you like to use the top item from your inventory? The item is {Hero.Inventory.Peek().Name}");
            char inventoryChoice = GetYOrNChoice();

            if (inventoryChoice == 'y')
            {
                Items itemToUse = Hero.GetItemToUse();

                if (itemToUse.GetType() == typeof(HealingPotion))
                    Hero.Health = itemToUse.ApplyTo(Hero);
                else if (itemToUse.GetType() == typeof(StatGem))
                {
                    int statChoice = GetStatChoice();

                    switch (statChoice)
                    {
                        case 1:
                            Hero.Strength += itemToUse.ApplyTo(Hero);
                            break;

                        case 2:
                            Hero.Agility += itemToUse.ApplyTo(Hero);
                            break;

                        case 3:
                            Hero.Wisdom += itemToUse.ApplyTo(Hero);
                            break;

                        default:
                            break;
                    }
                }
            }

            foreach (Edge edge in current.Edges)
            {
                if (edge.CanTraverse(Hero))
                {
                    MapNode nodeToAdd = edge.Destination;
                    directionsToTravel.Add(nodeToAdd);
                }
            }

            switch (directionsToTravel.Count)
            {
                case 1:
                    mapID++;
                    current = Dungeon.Map[mapID];
                    break;

                case 2:
                    choice = GetDirection();
                    if (choice == 2)
                    {
                        mapID += 11;
                        current = Dungeon.Map[mapID];
                    }
                    else
                        mapID++;
                        break;

                default:

                    break;

            }
            directionsToTravel.Clear();
        }
    }

    public int GetDirection() => GetDirectionInput();

    public int GetStatChoice() => GetStatInput();

    public int GetInitialDirection() => GetInitialDirectionInput();

    public char GetYOrNChoice() => GetCharChoice();
}