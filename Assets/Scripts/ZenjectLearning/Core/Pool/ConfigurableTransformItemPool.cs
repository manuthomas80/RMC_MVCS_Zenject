using UnityEngine;

namespace ZenjectLearning.Core.Pool
{
    public class ConfigurableTransformItemPool< TConfig, TItem > : ConfigurableItemPool< TConfig, TItem >
                                                                   where TItem : ITransform, IConfigurable< TConfig >
    {
        private Transform OriginalParent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void OnCreated( TItem item )
        {
            Hide( item.Transform );
            if ( OriginalParent == null ) OriginalParent = item.Transform.parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void OnSpawned( TItem item )
        {
            Show( item.Transform );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void OnDespawned( TItem item )
        {
            var t = item.Transform;
            
            t.SetParent( OriginalParent, false );
            Hide( t );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        private static void Hide( Component t ) => t.gameObject.SetActive( false );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        private static void Show( Component t ) => t.gameObject.SetActive( true );
    }
}