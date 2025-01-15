using Simulator.Maps;
using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        var simMap = new SmallTorusMap(10,10);
        var simCreatures = new List<Creature> { new Orc("Gorbag"), new Elf("Elandor") };
        var simPositions = new List<Point> { new Point(1, 1), new Point(9, 9) };
        string simMoves = "RLUDRLUD";
        var sim = new Simulation(simMap,simCreatures,simPositions,simMoves);

        Console.WriteLine($"Creature {sim.CurrentCreature} went '{sim.CurrentMoveName}'. ");
        Console.WriteLine($"New position - {simCreatures[sim.SimulationIndex % 2].CurrentPosition}");

        while (!sim.Finished)
        {
            try
            { 
                sim.Turn();

                if (!sim.Finished)
                {
                    Console.WriteLine($"Creature {sim.CurrentCreature} went '{sim.CurrentMoveName}'. ");
                    Console.WriteLine($"New position - {simCreatures[sim.SimulationIndex%2].CurrentPosition}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd w symulacji: {ex.Message}");
            }
        }

        Console.WriteLine("Symulacja zakończona.");
    }
}

