

public class Magic : Enemy
{
    public Magic() : base("Summy",90)
    {}
    public void Ioc(Enemy Target)
        {
            Target.HP = Target.HP + 50;
            System.Console.WriteLine($"{Target.Name} Healed {Name} GG his Hp is now {Target.HP}");
        }
    
    }