using System.ComponentModel;

namespace Simulator;

public class Birds : Animals
{
    // fields
    public bool CanFly { get; init; } = true;

    public override string Info
    { 
        get 
        { 
            if (CanFly == true) return $"{Description} (fly+) <{Size}>";
            else return $"{Description} (fly-) <{Size}>"; 
        } 
    }
    // constructors

    // methods
    
}