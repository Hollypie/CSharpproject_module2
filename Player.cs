public class Player
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int CurrentXP { get; set; }
    public int XPToNextLevel { get; set; }


    public Stats Stats { get; private set; }
    public List<string> Inventory { get; set; }

    public Player(string name)
    {
        Name = name;
        Level = 1;
        CurrentXP = 0;
        XPToNextLevel = 100;
        Inventory = new List<string>();
        Stats = new Stats(100, 10, 5);
    }

    public void PrintStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0) Console.WriteLine(" - (empty)");
        else foreach (var item in Inventory) Console.WriteLine($" - {item}");
    }

    public void Attack(Enemy enemy)
    {
        int damage = Stats.Strength - enemy.Stats.Defense;
        if (damage < 1) damage = 1;

        Console.WriteLine($"{Name} attacks {enemy.Name} for {damage} damage!");
        enemy.Stats.TakeDamage(damage);
    }

    public bool IsAlive()
    {
        return Stats.Health > 0;
    }

    public void GainXP(int amount)
    {
        CurrentXP += amount;
        Console.WriteLine($"{Name} gained {amount} XP!");

        if (CurrentXP >= XPToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        CurrentXP = 0;
        XPToNextLevel += 50;

        Stats.Health += 10;
        Stats.Strength += 2;
        Stats.Defense += 1;

        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }

}
