using System;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public class RandomUtils
    {
        private readonly Random _rand = new Random();

        public bool RandomChance01(float chance)
        {
            return _rand.NextDouble() <= chance;
        }
        
        public bool RandomChance0100(float chance)
        {
            return _rand.NextDouble() * 100.0f <= chance;
        }

        public int RandomBetween(int min, int max)
        {
            return _rand.Next(min, max + 1);
        }
        
        public float RandomBetween(float min, float max)
        {
            var sample = _rand.NextDouble();
            var scaled = sample * (max - min) + min;
            return (float)scaled;
        }
    }
}
