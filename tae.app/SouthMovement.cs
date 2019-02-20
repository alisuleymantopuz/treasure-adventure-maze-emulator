namespace tae.app
{
    /// <summary>
    /// South movement specification by contract
    /// </summary>
    public class SouthMovement : IMovement
    {
        public string OpenMessage => "South is open!";

        public string AlreadyVisitedMessage => "South is already visited before.";

        public int? PopulateId(int Id, int mazeSize)
        {
            int otherRoomId = Id + mazeSize;

            if (otherRoomId >= mazeSize * mazeSize)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}