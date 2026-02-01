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

    public Player()
    {
        // Parameterless constructor needed for JSON deserialization
    }

    public Player(string name)
    {
        Name = name;
        Level = 1;
        CurrentXP = 0;
        XPToNextLevel = 100;
        Inventory = new List<string>();
        Stats = new Stats(health: 100, strength: 10, defense: 1);
    }

    public void PrintStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0)
            Console.WriteLine(" - (empty)");
        else
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($" - {item}");
            }
        }
    }

    public void GainXP(int amount)
    {
        CurrentXP += amount;
        Console.WriteLine($"Gained {amount} XP!");

        while (CurrentXP >= XPToNextLevel)
        {
            CurrentXP -= XPToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        XPToNextLevel = (int)(XPToNextLevel * 1.5);
        Stats.Health += 10;
        Stats.Strength += 2;
        Stats.Defense += 1;

        Console.WriteLine($"Leveled up! Now at level {Level}.");
        Console.WriteLine($"Stats increased! Health: {Stats.Health}, Strength: {Stats.Strength}, Defense: {Stats.Defense}");
    }
}
