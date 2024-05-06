namespace Tetromino.Interface
{
    public interface ITimerStep
    {
        void UpdateLockTime();
        bool CheckStepTime();
        void UpdateStepTime();
        void SetLockTime(float second);
        bool CheckLockTime();
    }
}