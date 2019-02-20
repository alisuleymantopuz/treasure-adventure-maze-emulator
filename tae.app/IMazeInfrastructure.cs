using System.Collections.Generic;

namespace tae.app
{
    /// <summary>
    /// Maze base infrastructure contract
    /// </summary>
    public interface IMazeInfrastructure
    {
        Dictionary<char, IMovement> MovementLookup { get; set; }
        Room[,] Maze { get; set; }
        int MazeSize { get; set; }
    }
}
