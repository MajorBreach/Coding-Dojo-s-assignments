//Mine
Attack Crasher = new Attack("crasher",100);
Attack WK = new Attack("Wheel Kick",90);
Attack FB = new Attack("Furious Bash", 80);
//Melee
Attack Punch = new Attack("Punch", 20);
Attack Kick = new Attack("Kick", 15);
Attack Tackle = new Attack("Tackle", 25);
//ranged
Attack Arrow = new Attack("Star Arrow", 20);
Attack Throw= new Attack("Throw Secrect", 15);
//caster
Attack Fire = new Attack("Torch", 25);
Attack Lightning = new Attack("Thunder", 20);
Attack Staff = new Attack("Elemental", 10);



Melee Gladiator = new Melee();
Ranged Archer = new Ranged();
Magic Summy = new Magic();

Gladiator.AddAttack(Punch);
Gladiator.AddAttack(Kick);
Gladiator.AddAttack(Tackle);

Archer.AddAttack(Arrow);
Archer.AddAttack(Throw);

Summy.AddAttack(Fire);
Summy.AddAttack(Lightning);
Summy.AddAttack(Staff);

Gladiator.Rage(Summy , Kick);
Summy.Ioc(Summy);
Summy.Ioc(Summy);
Summy.Ioc(Summy);
Summy.Ioc(Summy);