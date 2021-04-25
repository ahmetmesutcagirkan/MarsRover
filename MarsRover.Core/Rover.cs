using MarsRover.Core.Interface;
using MarsRover.Core.Vectors;
using System;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        public Rover(Plateau plateau)
        {
            this.plateau = plateau;
            this.location = new Location();
        }

        public Plateau plateau { get; set; }
        public Location location { get; set; }
        public Direction direction { get; set; }
        public char[] commands { get; set; }

        #region Commands

        public void MoveForward()
        {
            switch (direction)
            {
                case Direction.South:
                    location.Y--;
                    break;
                case Direction.West:
                    location.X--;
                    break;
                case Direction.East:
                    location.X++;
                    break;
                case Direction.North:
                    location.Y++;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (direction)
            {
                case Direction.South:
                    direction = Direction.East;
                    break;
                case Direction.North:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.South;
                    break;
                case Direction.East:
                    direction = Direction.North;
                    break;
                default:
                    throw new InvalidOperationException("Invalid TurnLeft operation.");
            }
        }

        public void TurnRight()
        {
            switch (direction)
            {
                case Direction.South:
                    direction = Direction.West;
                    break;
                case Direction.North:
                    direction = Direction.East;
                    break;
                case Direction.West:
                    direction = Direction.North;
                    break;
                case Direction.East:
                    direction = Direction.South;
                    break;
                default:
                    throw new InvalidOperationException("Invalid TurnRight operation.");
            }
        }

        public string Run()
        {
            foreach (var command in this.commands)
            {
                switch (command)
                {
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    case 'M':
                        this.MoveForward();
                        break;
                    default:
                        throw new InvalidOperationException(string.Format("{0} commands is invalid", command));
                }
            }
            return string.Format("{0} {1} {2}", location.X, location.Y, direction.ToSymbol());
        }

        #endregion
    }
}
