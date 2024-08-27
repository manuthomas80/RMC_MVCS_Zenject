using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Utilities;

namespace ZenjectLearning.Game
{
    public class TargetTracker  : ITickable
    {
        [ Inject( Id = ZenjectID.TargetTransform ) ]
        private Transform Target;
        [ Inject( Id = ZenjectID.OwnTransform ) ]
        private Transform OwnT;
        [ Inject ]
        private TrackConfig Config;
        
        /// <summary>
        /// 
        /// </summary>
        public void Tick( )
        {
            var nextPos = Target.position - Target.forward * Config.Distance + new Vector3( 0f, Config.Y, 0f );
            OwnT.position = Vector3.Slerp(OwnT.position, nextPos, Time.deltaTime * Config.FollowLerpFactor );
            OwnT.LookAt( Target );
        }
    }
}