// Imports the needed libraries to work with JSON's and to create/read/write to a file, and to randomize results.
using System;
using System.IO;
using System.Text.Json;

// Creates the Game class
public class Game
{
    private Player? player;
    private Random random = new Random();
    private string savePath = "savegame.json"; // always in project folder

    // Displays the menu to the user
    public void ShowMainMenu()
    {
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Random Encounter");
        Console.WriteLine("4. Save Game");
        Console.WriteLine("5. Exit");
        Console.WriteLine();
    }

    // Gets users choice
    public string GetMenuChoice()
    {
        Console.Write("Enter your choice: ");
        return Console.ReadLine() ?? "";
    }

    // Logic to handle the users choice from the menu
    public bool HandleMenuChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                StartNewGame();
                return true;
            case "2":
                LoadGame();
                return true;
            case "3":
                RandomEncounter();
                return true;
            case "4":
                SaveGame();
                return true;
            case "5":
                Console.WriteLine("Exiting program...");
                return false;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return true;
        }
    }

    // Starts a new game
    public void StartNewGame()
    {
        player = new Player("Hero");
        Console.WriteLine("\nNew game started!");
        player.PrintStats();
    }

    // Saves the current game. Game details are saved to a savegame.json that is created or altered in the main folder.
    public void SaveGame()
    {
        if (player == null)
        {
            Console.WriteLine("No game to save.");
            return;
        }

        string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(savePath, json);
        Console.WriteLine($"Game saved at: {Path.GetFullPath(savePath)}");
    }

    // Loads a game saved to a json in the main folder
    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string json = File.ReadAllText(savePath);
        player = JsonSerializer.Deserialize<Player>(json);
        Console.WriteLine("Game loaded!");
        player?.PrintStats();
    }

    // This is the most complicated method in the project. This generates a random encounter. The hero can either encounter a Skeleton or Goblin and has a high probability of killing the enemy.  If the enemy is killed, then the hero collects loot which is saved to a list storing the loot the hero has previously collected. 
    public void RandomEncounter()
    {
        if (player == null)
        {
            Console.WriteLine("Start a game first!");
            return;
        }

        if (player.Stats.Health <= 1)
        {
            Console.WriteLine("Your hero is too weak! Start a new game first!");
            return;
        }

        // Randomize enemy type
        Enemy encounter = random.Next(2) == 0 ? new Skeleton() : new Goblin();

        // Randomize enemy HP and Strength within a range
        encounter.Stats.Health = random.Next(10, 21);      // HP between 10 and 20
        encounter.Stats.Strength = random.Next(2, 6);      // Strength between 2 and 5
        encounter.Stats.Defense = random.Next(0, 3);       // Defense between 0 and 2

        Console.WriteLine($"\nA wild {encounter.Name} appears!");
        encounter.PrintEnemyStats();

        // Combat loop
        while (encounter.IsAlive() && player.Stats.Health > 0)
        {
            // Hero attacks: random damage in a range
            int damageToEnemy = random.Next(player.Stats.Strength / 2, player.Stats.Strength + 1)
                                - encounter.Stats.Defense;
            if (damageToEnemy < 1) damageToEnemy = 1;
            encounter.Stats.TakeDamage(damageToEnemy);
            Console.WriteLine($"Hero attacks {encounter.Name} for {damageToEnemy} damage!");

            if (!encounter.IsAlive())
            {
                Console.WriteLine($"{encounter.Name} was defeated!");
                Console.WriteLine($"{player.Name} remaining health is: {player.Stats.Health}");
                if (!string.IsNullOrEmpty(encounter.Loot))
                {
                    Console.WriteLine($"Hero gains loot: {encounter.Loot}");
                    player.Inventory.Add(encounter.Loot);
                }
                player.GainXP(20); // simple XP reward
                break; // exit combat loop
            }

            // Enemy attacks: random damage
            int damageToHero = random.Next(encounter.Stats.Strength / 2, encounter.Stats.Strength + 1)
                               - player.Stats.Defense;
            if (damageToHero < 1) damageToHero = 1;
            player.Stats.TakeDamage(damageToHero);
            Console.WriteLine($"{encounter.Name} attacks Hero for {damageToHero} damage!");

            if (player.Stats.Health <= 0)
            {
                Console.WriteLine("XXXXXXXXXX Hero has been defeated! XXXXXXXXXX");
                player.Stats.Health = 1; // prevent death for simplicity
                break;
            }
        }

        // Save automatically after encounter
        SaveGame();
    }


}


