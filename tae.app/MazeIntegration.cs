using System.Collections.Generic;
using System.Text;

namespace tae.app
{
    public class MazeIntegration : IMazeIntegration, IMazeInitializer
    {
        /// <summary>
        /// Would be injected by constructor.
        /// </summary>
        private IMazeInfrastructure MazeInfrastructure;

        public MazeIntegration()
        {
            MazeInfrastructure = new MazeInfrastructure();

            MazeInfrastructure.MovementLookup = new Dictionary<char, IMovement>
            {
                { 'N', new NorthMovement() },
                { 'S', new SouthMovement() },
                { 'E', new EastMovement() },
                { 'W', new WestMovement() }
            };

            MazeInfrastructure.MazeSize = 0;
        }

        public void BuildMaze(int size)
        {
            MazeInfrastructure.MazeSize = size;

            MazeInfrastructure.Maze = new Room[size, size];

            int roomIdCounter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var room = new Room(roomIdCounter);

                    MazeInfrastructure.Maze[i, j] = room;

                    roomIdCounter++;
                }
            }

            //According to requirement
            //Definition of entrance.
            DefineEntrance();

            //According to requirement. 
            //Would be configuration value or random.
            PutTrap(1, 3);

            //According to requirement. 
            //Would be a configuration value or random.
            PutTreasure(5);
        }

        public int GetEntranceRoom()
        {
            var entranceRoom = GetRoom(8);

            entranceRoom.Visited = true;

            return 8;
        }

        public int? GetRoom(int roomId, char direction)
        {
            var movement = MazeInfrastructure.MovementLookup[direction];

            int? otherRoomId = movement.PopulateId(roomId, MazeInfrastructure.MazeSize);

            if (otherRoomId.HasValue == false)
                return null;

            var otherRoom = GetRoom(otherRoomId.Value);

            otherRoom.Visited = true;

            return otherRoomId;
        }

        public string GetDescription(int roomId)
        {
            var room = GetRoom(roomId);

            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Current room is {roomId}.");

            foreach (var movement in MazeInfrastructure.MovementLookup)
            {
                var otherRoomId = movement.Value.PopulateId(roomId, MazeInfrastructure.MazeSize);
                if (otherRoomId.HasValue)
                {
                    var otherRoom = GetRoom(otherRoomId.Value);
                    descriptionBuilder.AppendLine(movement.Value.OpenMessage);
                    if (otherRoom.Visited)
                    {
                        descriptionBuilder.AppendLine(movement.Value.AlreadyVisitedMessage);
                    }
                }
            }

            return descriptionBuilder.ToString();
        }

        public Room GetRoom(int roomId)
        {
            int rowLength = MazeInfrastructure.Maze.GetLength(0);

            int colLength = MazeInfrastructure.Maze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (MazeInfrastructure.Maze[i, j].RoomId == roomId)
                    {
                        return MazeInfrastructure.Maze[i, j];
                    }
                }
            }

            return null;
        }

        public bool HasTreasure(int roomId)
        {
            return GetRoom(roomId).Treasure;
        }

        public bool CausesInjury(int roomId)
        {
            return GetRoom(roomId).Trap;
        }

        public void DefineEntrance()
        {
            var lastRoomCounterValue = (MazeInfrastructure.MazeSize * MazeInfrastructure.MazeSize) - 1;

            var room = GetRoom(lastRoomCounterValue);

            room.Entrance = true;
        }

        public void PutTreasure(params int[] rooms)
        {
            foreach (var id in rooms)
            {
                var room = GetRoom(id);

                room.Treasure = true;
            }
        }

        public void PutTrap(params int[] rooms)
        {
            foreach (var id in rooms)
            {
                var room = GetRoom(id);

                room.Trap = true;
            }
        }
    }
}