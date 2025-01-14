using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator.Maps;
namespace Simulator;
public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => 
        Creatures[SimulationIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName =>
        Moves[SimulationIndex].ToString().ToLower();

    public int SimulationIndex { get; private set; } = 0;
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(SmallMap map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (map == null || creatures == null || positions == null)
            throw new ArgumentException("Simulation won't start without map and creatures on positions");
        if (creatures.Count == 0 || positions.Count() != creatures.Count())
            throw new ArgumentException("There need to be as many positions as creatures on map.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        
        if (moves == null)
            Finished = true;

        for (int i = 0; i < creatures.Count(); i++)
        {
            creatures[i].AssignToMap(map, positions[i]);
        }

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished == true) 
            throw new InvalidOperationException("Simulation is finished.");

        if ("rldu".Contains(CurrentMoveName))
            CurrentCreature.Go(DirectionParser.Parse(CurrentMoveName)[0]);

        if (SimulationIndex == Moves.Length - 1)
            Finished = true;

        SimulationIndex++;

        
    }
}
