namespace tae.app
{
    /// <summary>
    /// North movement specification by contract
    /// </summary>
    public class NorthMovement : IMovement
    {
        public string OpenMessage => "North is open!";

        public string AlreadyVisitedMessage => "North is already visited before.";

        public int? PopulateId(int Id, int mazeSize)
        {
            int otherRoomId = Id - mazeSize;

            if (otherRoomId < 0)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}