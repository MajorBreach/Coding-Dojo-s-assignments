
public class Enemy
{
    public List<Attack> SkillList = new List<Attack>();
    public string Name;
    public int HP = 300;
    public Enemy(string name, int hp = 300)
    {
        Name = name;
        HP = hp;
    }

    public void RandAttack()
    {
        if (SkillList.Count > 0)
        {
            Random random = new Random();
            int idx = random.Next(0, SkillList.Count);
            Attack bash = SkillList[idx];
            System.Console.WriteLine($"{Name} Picked {bash.Name} and Savaged for {bash.Dmg} ");
        }
        else
        {
            System.Console.WriteLine("Missed");
        }
    }
    public void AddAttack(Attack bash)
    {
        SkillList.Add(bash);
    }

    public void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.HP = Target.HP - ChosenAttack.Dmg;
        System.Console.WriteLine($"{Name} Attacks {Target.Name}, Dealing {ChosenAttack.Dmg} damage and reducing {Target.Name}'s health to {Target.HP}");
    }
}