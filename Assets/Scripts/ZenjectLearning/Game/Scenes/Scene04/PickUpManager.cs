using System;
using System.Collections.Generic;
using Zenject;
using ZenjectLearning.Game.Utilities;

namespace ZenjectLearning.Game.Scenes
{
    public class PickUpManager : ITickable
    {
        private readonly PickUp.Pool PickUpPool;
        private readonly PickUpSpawnArea SpawnArea;
        
        private DateTime LastPickUpSpawnTime;
        private List< PickUp > PickUps = new ( );
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pickUpPool"></param>
        /// <param name="env"></param>
        public PickUpManager( PickUp.Pool pickUpPool, Environment env )
        {
            PickUpPool = pickUpPool;
            SpawnArea = env.PickUpSpawnArea;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Tick( )
        {
            var currTime = DateTime.Now;
            if( ( currTime - LastPickUpSpawnTime ).TotalSeconds > 0.2f )
            {
                var pickUp = PickUpPool.Spawn( new PickUpConfig( ColorTable.GetRandomColor( ), SpawnArea.RandomSpawnPoint( ) ) );
                pickUp.OnDeSpawnEvent.AddListener( OnPickUpDeSpawn );
                PickUps.Add( pickUp );
                LastPickUpSpawnTime = currTime;
            }
            
            for( var i = PickUps.Count - 1; i >= 0; i-- ) PickUps[ i ].Update( currTime );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pickUp"></param>
        private void OnPickUpDeSpawn( PickUp pickUp )
        {
            pickUp.OnDeSpawnEvent.RemoveListener( OnPickUpDeSpawn );
            PickUps.Remove( pickUp );
        }
    }
}