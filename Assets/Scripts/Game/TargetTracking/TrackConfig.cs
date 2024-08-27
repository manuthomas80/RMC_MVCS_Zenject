using System;
using UnityEngine;

namespace ZenjectLearning.Game
{
    [ Serializable ]
    public class TrackConfig
    {
        [ SerializeField ]
        private float _Y;
        public  float  Y => _Y;
        [ SerializeField ]
        private float _Distance;
        public  float  Distance => _Distance;
        [ SerializeField ]
        private float _FollowLerpFactor;
        public  float  FollowLerpFactor => _FollowLerpFactor;
    }
}