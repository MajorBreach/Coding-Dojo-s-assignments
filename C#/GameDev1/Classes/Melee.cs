public class Melee : Enemy
{
public Melee() : base("Gladiator",150)
{}
    public void Rage(Enemy Target , Attack attack)
    {
        attack.Dmg = attack.Dmg + 10;
        Target.HP = Target.HP - attack.Dmg;
        System.Console.WriteLine($"{Target.Name} Striked down with {attack.Dmg} dmg and targets hp is {Target.HP}");
    }

}