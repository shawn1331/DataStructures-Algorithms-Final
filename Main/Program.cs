// Shawn Miner 4/18/25 Hero Quest Final Project 

using Logic;

bool playAgain = true;

while (playAgain)
{
    string heroName = GetHeroName();
    Hero hero = GetHeroChoice(heroName);
    Game game = new(hero, GetUserPath, GetStatChoice, GetInitialPath);

    game.RunGame();

}















static string GetHeroName()
{
    Console.Clear();
    Console.WriteLine("Please enter the name of your hero.");
    string? name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("That was an invalid entry try again");
        return GetHeroName();
    }
    else
        return name;
}

static int GetInitialPath()
{
    Console.WriteLine(@"Which direction would you like to go?
Press the number associated with the direction you would like to travel:
1. Left path
2. Middle path
3. Right path");

    char choice = Console.ReadKey(true).KeyChar;

    if (char.IsNumber(choice) && (int)choice >= 49 && (int)choice <= 51)
    {
        return choice switch
        {
            '1' => 1,
            '2' => 2,
            '3' => 3,
            _ => GetUserPath()
        };
    }
    else
    {
        return GetUserPath();
    }
}

static int GetUserPath()
{
    Console.Clear();
    Console.WriteLine(@"Which direction would you like to go?
Press the number associated with the direction you would like to travel:
1. Continue straight down path
2. Take the branching path");

    char choice = Console.ReadKey(true).KeyChar;

    if (char.IsNumber(choice) && (int)choice >= 49 && (int)choice <= 50)
    {
        return choice switch
        {
            '1' => 1,
            '2' => 2,
            _ => GetUserPath()
        };
    }
    else
    {
        return GetUserPath();
    }
}

static Hero GetHeroChoice(string name)
{
    Console.Clear();
    Console.WriteLine(@"    CHOOSE YOUR HERO'S CLASS!

Press the number corresponding to the class you'd like.
1. Warrior
2. Rogue
3. Wizard");

    char choice = Console.ReadKey(true).KeyChar;

    if (char.IsNumber(choice) && (int)choice >= 49 && (int)choice <= 51)
    {
        return choice switch
        {
            '1' => new Warrior(name),
            '2' => new Rogue(name),
            '3' => new Wizard(name),
            _ => GetHeroChoice(name)
        };
    }
    else
    {
        return GetHeroChoice(name);
    }
}

static int GetStatChoice()
{
    Console.WriteLine(@"--Choose a stat to boost!--
Press the number associated with the stat you would like to increase:
1. Strength
2. Agility
3. Wisdom");

    char choice = Console.ReadKey(true).KeyChar;

    if (char.IsNumber(choice) && (int)choice >= 49 && (int)choice <= 51)
    {
        return choice switch
        {
            '1' => 1,
            '2' => 2,
            '3' => 3,
            _ => GetStatChoice()
        };
    }
    else
        return GetStatChoice();
}