using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Utilities;

namespace ZenjectLearning.Game
{
    public class PlayerController : ITickable
    {
        [ Inject( Id = ZenjectID.AngularSpeed ) ]
        private float AngularSpeed;
        [ Inject( Id = ZenjectID.LinearSpeed ) ]
        private float LinearSpeed;
        
        private readonly Transform T;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public PlayerController( Player player )
        {
            T = player.transform;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Tick( ) => HandleMovement( );

        /// <summary>
        /// Handles player movement based on input.
        /// </summary>
        private void HandleMovement( )
        {
            var rotation = Input.GetAxis( "Horizontal" ) * AngularSpeed * Time.deltaTime;
            var movement = Input.GetAxis( "Vertical" ) * LinearSpeed * Time.deltaTime;
            
            T.Rotate( 0, rotation, 0 );
            T.Translate( 0, 0, movement );
        }
    }
}