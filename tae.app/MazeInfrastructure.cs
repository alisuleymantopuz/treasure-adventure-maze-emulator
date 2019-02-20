using System.Collections.Generic;

namespace tae.app
{
    /// <summary>
    /// Maze infrastructure
    /// </summary>
    public class MazeInfrastructure :IMazeInfrastructure
    {
        public Dictionary<char, IMovement> MovementLookup { get; set; }
        public Room[,] Maze { get; set; }
        public int MazeSize { get; set; }
    }
}
