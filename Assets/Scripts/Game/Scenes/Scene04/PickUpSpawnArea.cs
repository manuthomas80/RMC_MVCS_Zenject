using UnityEngine;

namespace ZenjectLearning.Game.Scenes
{
    public class PickUpSpawnArea : MonoBehaviour
    {
        [ SerializeField ]
        private Renderer Renderer;
        private float OriginY => Renderer.transform.position.y;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 RandomSpawnPoint( )
        {
            var bounds = Renderer.bounds;
            var randomX = Random.Range( bounds.min.x, bounds.max.x );
            var randomY = Random.Range( bounds.min.z, bounds.max.z ) ;
            return new Vector3( randomX, OriginY, randomY );
        }
    }
}