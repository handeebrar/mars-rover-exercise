namespace MarsRover.Models
{
    public class Rover
    {
        public Rover(int xCoordinate , int yCoordinate , string direction)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = direction;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public string Direction { get; set; }
    }
}
