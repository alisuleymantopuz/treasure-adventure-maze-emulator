namespace tae.app
{
    /// <summary>
    /// West movement specification by contract
    /// </summary>
    public class WestMovement : IMovement
    {
        public string OpenMessage => "West is open!";

        public string AlreadyVisitedMessage => "West is already visited before.";

        public int? PopulateId(int Id, int mazeSize)
        {
            var otherRoomId = Id - 1;

            if (otherRoomId % mazeSize == mazeSize - 1 || otherRoomId < 0)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}