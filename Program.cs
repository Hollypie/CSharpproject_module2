// This file should do the following
// Show the welcome screen
// Display the menu
// Run the main game loop
// Call other classes (Player, Game, Scoreboard, etc.)
// Handle quitting the program

Console.WriteLine("Welcome to my Game Systems Prototype!");
GameLoop();

void GameLoop()
{
    bool running = true;

    while (running)
    {
        Console.WriteLine();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Exit");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine() ?? "";

        if (choice == "1")
        {
            Console.WriteLine();
            Console.WriteLine("You chose to create a new game");
            Console.WriteLine();

            // Create a Player object
            Player player = new Player("Hero");

            // Use the player object
            Console.WriteLine("New game started!");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Health: {player.Health}");

        }
        else if (choice == "2")
        {
            Console.WriteLine("You chose to load a game");
        }
        else if (choice == "3")
        {
            Console.WriteLine("You have chosen to exit the program.");
            running = false;
        }
        else
        {
            Console.WriteLine("That is an incorrect input. Try again.");
        }
    }
}
