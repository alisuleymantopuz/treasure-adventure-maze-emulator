namespace tae.app
{
    /// <summary>
    /// Movement contract.
    /// </summary>
    public interface IMovement
    {
        int? PopulateId(int Id, int mazeSize);

        string OpenMessage { get; }

        string AlreadyVisitedMessage { get; }
    }
}