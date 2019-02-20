using System;

namespace tae.app
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            int? temporaryRoomId = null;
            int attemptCount = 0;
            int health = 3;

            MazeIntegration mazeIntegration = new MazeIntegration();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Treasure adventure emulator.");
            Console.WriteLine("Control Keys:");
            Console.WriteLine("North : N, South : S, East  : E, West  : W, Exit  : Esc");
            Console.WriteLine("Maze Initializing...");
            mazeIntegration.BuildMaze(3);
            Console.WriteLine("Maze Initialized...");

            int roomId = mazeIntegration.GetEntranceRoom();
            Console.WriteLine("Welcome to the Entrance!");

            while (health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mazeIntegration.GetDescription(roomId));
                Console.WriteLine("Total Moves: " + attemptCount);
                key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.Escape)
                    break;

                attemptCount++;

                switch (key.KeyChar)
                {
                    case 'N':
                        temporaryRoomId = mazeIntegration.GetRoom(roomId, 'N');
                        if (temporaryRoomId != null)
                            roomId = Convert.ToInt32(temporaryRoomId);
                        break;
                    case 'S':
                        temporaryRoomId = mazeIntegration.GetRoom(roomId, 'S');
                        if (temporaryRoomId != null)
                            roomId = Convert.ToInt32(temporaryRoomId);
                        break;
                    case 'E':
                        temporaryRoomId = mazeIntegration.GetRoom(roomId, 'E');
                        if (temporaryRoomId != null)
                            roomId = Convert.ToInt32(temporaryRoomId);
                        break;
                    case 'W':
                        temporaryRoomId = mazeIntegration.GetRoom(roomId, 'W');
                        if (temporaryRoomId != null)
                            roomId = Convert.ToInt32(temporaryRoomId);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Key!");
                        break;
                }

                if (temporaryRoomId != null)
                {
                    if (mazeIntegration.HasTreasure(roomId))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Treasure Found, Congrats!");
                        Console.WriteLine("Total Moves: " + attemptCount);
                        Console.ReadKey();
                        break;
                    }

                    if (mazeIntegration.CausesInjury(roomId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Trap Room!");
                        health--;
                    }
                }
                else
                {
                    Console.WriteLine("Wall!");
                }
            }

            if (health == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Health is finished! Game Over!!");
                Console.ReadKey();
            }
        }
    }
}