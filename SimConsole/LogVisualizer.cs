using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;
internal class LogVisulizer
{
    SimulationHistory Log { get; }
    public LogVisulizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        var turnLog = Log.TurnLogs[turnIndex];
        Console.WriteLine($"{turnLog.Mappable} went {turnLog.Move}");
        Console.WriteLine("Current positions on map:");
        turnLog = Log.TurnLogs[turnIndex+1];

        foreach (var i in turnLog.Symbols)
        {
            Console.WriteLine($"{i.Value}:  [{i.Key.X}, {i.Key.Y}] ");
        }
    }
}
