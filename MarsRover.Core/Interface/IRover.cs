namespace MarsRover.Core.Interface
{
    public interface IRover
    {
        void TurnLeft();
        void TurnRight();
        void MoveForward();
        string Run();
    }
}
