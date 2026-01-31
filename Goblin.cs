// Goblin.cs
public class Goblin : Enemy
{
    public Goblin()
        : base(
            "Goblin",
            new Stats { Health = 30, Strength = 5, Defense = 2 }
          )
    {
    }

    public override void DecideAction()
    {
        Console.WriteLine("Goblin snarls and attacks!");
    }
}
