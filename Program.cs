// This file should do the following
// Show the welcome screen
// Display the menu
// Run the main game loop
// Instantiate a Game Object from the Game class
// Handle quitting the program
// Program.cs

using System;

Console.WriteLine("Welcome to my Game Systems Prototype!");

Game myGame = new Game();

bool running = true;

while (running)
{
    myGame.ShowMainMenu();
    string choice = myGame.GetMenuChoice();
    running = myGame.HandleMenuChoice(choice);
}

Console.WriteLine("Saving game to: " + Path.GetFullPath("savegame.json"));

Console.WriteLine("Thanks for playing!");



