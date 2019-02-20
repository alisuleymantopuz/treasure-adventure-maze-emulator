namespace tae.app
{
    /// <summary>
    /// Maze room/hole definition
    /// </summary>
    public class Room
    {
        public int RoomId { get; set; }
        public bool Treasure { get; set; }
        public bool Trap { get; set; }
        public bool Visited { get; set; }
        public bool Entrance { get; set; }

        public Room(int roomId)
        {
            RoomId = roomId;
        }

        /// <summary>
        /// See the room content
        /// </summary>
        /// <returns>Return if it´s entrance, trap, treasure or ID</returns>
        public override string ToString()
        {
            return Entrance ? "->" : Treasure ? "*" : Trap ? "#" : RoomId.ToString();
        }
    }
}