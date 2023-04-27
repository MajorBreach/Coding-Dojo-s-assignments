

public class Ranged : Enemy
{
public Ranged(int Distance = 5) : base("Archer",50)
{}
    public int Distance;

    public void backflip(Ranged Target)
    {
        Target.Distance = Target.Distance + 20;
        System.Console.WriteLine($"{Target.Name} Did a Backflip and they're {Target.Distance} far away.");
    }

}