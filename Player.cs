using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int CurrentXP { get; set; }
    public int XPToNextLevel { get; set; }

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
