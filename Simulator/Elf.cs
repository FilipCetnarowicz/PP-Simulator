using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Elf : Creature
{
    // fields
    private int singCounter;
    private int agility = 0;
    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    public override int Power
        { get { return 8 * Level + 2 * Agility; } }
    public override string Info
    { get { return $"{Name} [{Level}][{Agility}]"; } }

    // constructors
    public Elf() : base() { }
    public Elf(string name, int level = 1, int agility = 0) : base(name, level) 
        { Agility = agility; }

    // methods
    public void Sing()
    {
        singCounter++;
        if (singCounter % 3 == 0)
            { if  (agility < 10) agility++; }
    }
    public override string Greeting() => 
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}";

    
}
