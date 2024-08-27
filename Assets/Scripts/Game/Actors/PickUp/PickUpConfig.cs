using System;
using UnityEngine;

namespace ZenjectLearning.Game
{
    [ Serializable ]
    public class PickUpConfig
    {
        public readonly int ID;
        public readonly Color Color;
        public readonly Vector3 Position;
        public readonly float StayDuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <param name="position"></param>
        /// <param name="stayDur"></param>
        public PickUpConfig( int id, Color color, Vector3 position, float stayDur )
        {
            ID = id;
            Color = color;
            Position = position;
            StayDuration = stayDur;
        }
    }
}