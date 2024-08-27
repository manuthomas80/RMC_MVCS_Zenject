using UnityEngine;
using Zenject;
using ZenjectLearning.Core;

namespace ZenjectLearning.Game.Utilities
{
    public class CollectOnCollision : MonoBehaviour
    {
        private ICollectable Collectable;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectable"></param>
        [ Inject ]
        public void Create( ICollectable collectable )
        {
            Collectable = collectable;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Collect( )
        {
            Collectable.Collect( );
        }
    }
}