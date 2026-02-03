## Overview

This project is a console-based Game Systems Prototype written in C# that focuses on implementing core gameplay systems commonly used in modern game development. Rather than building a full game with graphics and UI, this project emphasizes the underlying logic that drives player progression, enemy behavior, loot generation, and game state management.

The software simulates foundational game systems such as player and enemy statistics and leveling, and optional save/load functionality. These systems are designed to be modular, extensible, and directly transferable to future Unity projects.

The purpose of this project is to strengthen my understanding of C# as an object-oriented language while practicing real-world design patterns used in game development. By focusing on reusable systems instead of presentation, this project serves as preparation for scripting gameplay mechanics in Unity using C#.

The program greets the user the offers this menu

Main Menu
1. New Game
2. Load Game
3. Random Encounter
4. Save Game
5. Exit

Then the user can choose from the menu. Random Encounter generates a fight with an enemy that concludes when either the hero or enemy dies. Hero is given loot and XP when successful. Once enough XP is generated the Hero Levels up. The game must start over when the Hero dies.

{Provide a link to your YouTube demonstration.  It should be a one minute demo of the software running and a walkthrough of the code.}

[Software Demo Video](http://youtube.link.goes.here)

## Running the project

because we are working with C#, in order to run the code. You'll need to type the following

dotnet build
dotnet run

## Development Environment

This project was developed using the following tools and technologies:

Visual Studio Code for writing and debugging C# code

.NET SDK for building and running the console application

Git and GitHub for version control

The software is written in C#, using object-oriented programming principles such as classes, structs, inheritance, abstract base classes, and encapsulation. The project also demonstrates control flow, loops, methods, and optional file input/output for saving and loading game data.

## Useful Websites

{Make a list of websites that you found helpful in this project}
* [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [.NET learn website](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)
* [Object-Oriented Programming in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop)
* [Unity C# Scripting Overview](https://learn.unity.com/tutorial/c-scripting)


