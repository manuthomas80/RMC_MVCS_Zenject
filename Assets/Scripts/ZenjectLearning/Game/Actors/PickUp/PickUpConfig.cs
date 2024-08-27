using System;
using UnityEngine;

namespace ZenjectLearning.Game
{
    [ Serializable ]
    public class PickUpConfig
    {
        public readonly Color Color;
        public readonly Vector3 Position;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="position"></param>
        public PickUpConfig( Color color, Vector3 position )
        {
            Color = color;
            Position = position;
        }
    }
}