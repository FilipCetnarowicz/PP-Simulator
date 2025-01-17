using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {

            var CurrentPositions = new Dictionary<Point, char>();
            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    var location = _simulation.Map.At(x, y);
                    if (location.Count() == 1)
                        CurrentPositions.Add(new Point(x, y), location[0].Symbol[0]);
                    if (location.Count() > 1)
                        CurrentPositions.Add(new Point(x, y), 'X');
                }
            }
            TurnLogs.Add
                (
                    new SimulationTurnLog
                    {
                        Mappable = _simulation.CurrentMappable.ToString(),
                        Move = _simulation.CurrentMoveName,
                        Symbols = CurrentPositions
                    }
                );
            _simulation.Turn();
        }
    }
}
