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
        Game myGame = new Game();

        myGame.ShowMainMenu();
        string choice = myGame.GetMenuChoice();

        running = myGame.HandleMenuChoice(choice);
    }
}

