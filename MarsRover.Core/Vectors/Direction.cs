using System.ComponentModel;

namespace MarsRover.Core.Vectors
{
    public enum Direction
    {
        North,
        South,
        West,
        East
    }

    public static class DirectionExtensions
    {
        public static Direction ToDirection(this string direction)
        {
            switch (direction)
            {
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                case "E":
                    return Direction.East;
            }

            throw new InvalidEnumArgumentException("Invalid Direction");
        }

        public static char ToSymbol(this Direction direction)
        {
            return direction.ToString()[0];
        }
    }
}