using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Utilities;

namespace ZenjectLearning.Game.Scenes
{
    public class PickUpManager : ITickable
    {
        private readonly PickUp.Pool PickUpPool;
        private readonly PickUpSpawnArea SpawnArea;
        
        private DateTime LastPickUpSpawnTime;
        private readonly List< PickUp > PickUps = new ( );
        
        private const float PickUpStayDuration = 15f;
        private int NPickUps;
        
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
            if( ( currTime - LastPickUpSpawnTime ).TotalSeconds > 0.1f )
            {
                const int nItemsInBatch = 3;
                for( int i = 0; i < nItemsInBatch; i++ )
                {
                    var pickUp = PickUpPool.Spawn( new PickUpConfig( ++NPickUps,
                                                                            ColorTable.GetRandomColor( ), 
                                                                      SpawnArea.RandomSpawnPoint( ), 
                                                                            PickUpStayDuration ) );
                    pickUp.OnDeSpawnEvent.AddListener( OnPickUpDeSpawn );
                    PickUps.Add( pickUp );
                }
                
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