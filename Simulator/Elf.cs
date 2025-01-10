﻿using System;
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
        init
        {
            if (value < 0) { agility = 0; }
            else if (value > 10) { agility = 10; }
            else { agility = value; }
        }
    }
    public override int Power
        { get { return 8 * Level + 2 * Agility; } }

    // constructors
    public Elf() : base() { }
    public Elf(string name, int level = 1, int agility = 0) : base(name, level) 
        { Agility = agility; }

    // methods
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;
        if (singCounter % 3 == 0)
        { 
            if  (agility < 10) agility++; 
            Console.WriteLine($"{Name}[{Level}] increased his agility to <{Agility}> by singing");
        }

    }
    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}");

    
}