using Tetromino.Interface;
using UnityEngine;

namespace Tetromino
{
    public class TimerStep : ITimerStep
    {
        private static float _stepDelay;
        private static float _lockDelay;
        private static float _stepTime;
        private static float _lockTime;

        public TimerStep(float stepDelay, float lockDelay)
        {
            _stepDelay = stepDelay;
            _lockDelay = lockDelay;
        }

        public void UpdateLockTime() =>
            _lockTime += Time.deltaTime;

        public bool CheckStepTime() =>
            Time.time >= _stepTime;

        public void UpdateStepTime() =>
            _stepTime = Time.time + _stepDelay;

        public void SetLockTime(float second) =>
            _lockTime = second;

        public bool CheckLockTime() =>
            _lockTime >= _lockDelay;
    }
}