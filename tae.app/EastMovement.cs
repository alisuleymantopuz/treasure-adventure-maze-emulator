namespace tae.app
{
    /// <summary>
    /// East movement specification by contract
    /// </summary>
    public class EastMovement : IMovement
    {
        public string OpenMessage => "East is open!";

        public string AlreadyVisitedMessage => "East is already visited before.";

        public int? PopulateId(int Id, int mazeSize)
        {
            var otherRoomId = (Id + 1);

            if (otherRoomId % mazeSize == 0)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}