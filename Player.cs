using System;
using System.Collections.Generic;

// Player class creates the hero object that the user uses to play the game
public class Player
{
    // Player objects attributes with getters and setters
    public string Name { get; set; }
    public int Level { get; set; }
    public int CurrentXP { get; set; }
    public int XPToNextLevel { get; set; }

    // Every hero has their stats instantiated
    public Stats Stats { get; set; }
    public List<string> Inventory { get; set; }

    // Parameterless constructor needed for JSON deserialization
    public Player()
    {
        Name = "Hero";                       // default name
        Level = 1;
        CurrentXP = 0;
        XPToNextLevel = 100;                 // safe default XP to level
        Stats = new Stats(25, 10, 1);       // default stats
        Inventory = new List<string>();      // empty inventory
    }

    // Constructor with a name
    public Player(string name) : this()
    {
        Name = name;
    }

    // Writes Stats and inventory to the console. Shown when the game is loaded and new game is created.
    public void PrintStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"XP: {CurrentXP}/{XPToNextLevel}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0)
            Console.WriteLine(" - (empty)");
        else
        {
            foreach (var item in Inventory)
                Console.WriteLine($" - {item}");
        }
    }

    // how to hero gains XP during combat.
    public void GainXP(int amount)
    {
        CurrentXP += amount;
        Console.WriteLine($"Gained {amount} XP!");

        // Safety check to prevent eternal loop
        while (XPToNextLevel > 0 && CurrentXP >= XPToNextLevel)
        {
            CurrentXP -= XPToNextLevel;
            LevelUp();
        }
    }

    // How to hero levels up due to gaining XP during combat.
    private void LevelUp()
    {
        Level++;
        XPToNextLevel = (int)(XPToNextLevel * 1.5);

        // Increase max stats without healing current health
        Stats.Strength += 2;
        Stats.Defense += 1;

        Console.WriteLine($"Leveled up! Now at level {Level}.");
        Console.WriteLine($"Stats increased! Strength: {Stats.Strength}, Defense: {Stats.Defense}");
    }

}
