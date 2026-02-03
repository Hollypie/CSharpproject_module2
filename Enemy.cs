// Abstract base class for all enemies.
// Contains common properties and methods like Name, Stats, Loot, Attack, and health management.
// Goblin and Skeleton classes inherit from this class and define specific enemy behaviors.


public abstract class Enemy
{
    public string Name { get; protected set; }

    public string Loot { get; set; }
    public Stats Stats { get; protected set; }

    // Constructor for enemy, blueprint for the required arguments when instantiating an enemy
    protected Enemy(string name, Stats stats, string loot)
    {
        Name = name;
        Stats = stats;
        Loot = loot;
    }

    // This makes all enemy subclasses must have a DecideAction method
    public abstract void DecideAction();

    // This just prints all the enemy stats to the console.
    public void PrintEnemyStats()
    {
        Console.WriteLine($"Enemy: {Name}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
    }

    // This is the logic that allows the enemies to attack the hero. It calculates damage and then calls the players method TakeDamage. It also prints to the console.
    public void Attack(Player player)
    {
        int damage = Stats.Strength - player.Stats.Defense;
        if (damage < 1) damage = 1;

        Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage!");
        player.Stats.TakeDamage(damage);
    }

    // Is a method that returns a boolean value that determines if the enemy is still alive. This is used to determine if the hero gains loot.
    public bool IsAlive()
    {
        return Stats.Health > 0;
    }

}

