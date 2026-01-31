// Skeleton.cs
public class Skeleton : Enemy
{
    public Skeleton()
        : base(
            "Skeleton",
            new Stats { Health = 20, Strength = 3, Defense = 1 }
          )
    {
    }

    public override void DecideAction()
    {
        Console.WriteLine("Skeleton rattles forward and attacks!");
    }

    // public override void DecideAction()
    // {
    //     Console.WriteLine("Skeleton rattles forward and attacks!");
    //     Attack(currentPlayer);
    // }
}