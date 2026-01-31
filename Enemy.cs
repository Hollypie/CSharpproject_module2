// Enemy.cs
public abstract class Enemy
{
    public string Name { get; protected set; }
    public Stats Stats { get; set; }

    public Enemy(string name, Stats stats)
    {
        Name = name;
        Stats = stats;
    }

    public abstract void DecideAction();

    public virtual void Attack(Player player)
    {
        Console.WriteLine($"{Name} attacks!");

        int damage = Stats.Strength;
        player.TakeDamage(damage);
    }

    public virtual void TakeDamage(int amount)
    {
        Stats.Health -= amount;
        Console.WriteLine($"{Name} takes {amount} damage! Remaining health: {Stats.Health}");

        if (Stats.Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Console.WriteLine($"{Name} has been defeated!");
    }
}
