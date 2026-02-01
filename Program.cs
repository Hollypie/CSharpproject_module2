// This file should do the following
// Show the welcome screen
// Display the menu
// Run the main game loop
// Call other classes (Player, Game, Scoreboard, etc.)
// Handle quitting the program
// Program.cs

Console.WriteLine("Welcome to my Game Systems Prototype!");
bool running = true;
Game myGame = new Game();

while (running)
{
    myGame.ShowMainMenu();
    string choice = myGame.GetMenuChoice();
    running = myGame.HandleMenuChoice(choice);
}


