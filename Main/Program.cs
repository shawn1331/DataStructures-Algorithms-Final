// Shawn Miner 4/18/25 Hero Quest Final Project 

using Logic;

bool playAgain = true;

while (playAgain)
{
    string heroName = GetHeroName();
    Hero hero = GetHeroChoice(heroName);
    Game game = new(hero);
    game.RunGame();

}















static string GetHeroName()
{
    Console.WriteLine("Please enter the name of your hero.");
    string? name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("That was an invalid entry try again");
        return GetHeroName();
    }

    return name;
}

static int GetUserInput()
{
    Console.WriteLine("Which direction would you like to go?");


}

static Hero GetHeroChoice(string name)
{
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
            _ => null
        };
    }
    else
    {
        Console.Clear();
        return GetHeroChoice(name);
    }
}
