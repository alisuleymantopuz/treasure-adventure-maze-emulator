namespace tae.app
{
    /// <summary>
    /// Maze initializing pattern
    /// </summary>
    public interface IMazeInitializer
    {
        void DefineEntrance();
        void PutTreasure(params int[] rooms);
        void PutTrap(params int[] rooms);
    }
}
