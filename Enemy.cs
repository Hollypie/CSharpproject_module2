public abstract class Enemy
{
    public string Name { get; protected set; }
    public Stats Stats { get; protected set; }

    protected Enemy(string name, Stats stats)
    {
        Name = name;
        Stats = stats;
    }

    public abstract void DecideAction();

    public void PrintEnemyStats()
    {
        Console.WriteLine($"Enemy: {Name}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
    }

    public void Attack(Player player)
    {
        int damage = Stats.Strength - player.Stats.Defense;
        if (damage < 1) damage = 1;

        Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage!");
        player.Stats.TakeDamage(damage);
    }

    public bool IsAlive()
    {
        return Stats.Health > 0;
    }

}
