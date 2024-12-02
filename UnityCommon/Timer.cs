using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public class Timer
    {
        private readonly float _time;
        private float _timeLeft;

        public Timer(float time)
        {
            _time = time;
            _timeLeft = time;
        }

        public bool Tick()
        {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft > 0.0f) return false;
            
            _timeLeft = _time - _timeLeft;
            return true;
        }

        public float GetElapsedTime()
        {
            return _time - _timeLeft;
        }
    }
}
