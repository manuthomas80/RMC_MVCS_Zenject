using UnityEngine;
using Zenject;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    public abstract class FeatureViewBase : MonoBehaviour, IView
    {
        protected ConfiguratorContext Context;
        protected ConfiguratorService Service => Context.ServiceLocator.GetItem< ConfiguratorService >( );
        protected ConfiguratorModel Model => Context.ModelLocator.GetItem< ConfiguratorModel >( );
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [ Inject ]
        protected void Create( ConfiguratorContext context )
        {
            Context = context;
            if( ! Service.IsConfiguratorServiceLoaded )  Service.OnLoadCompleted.AddListener( OnServiceLoaded );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void OnServiceLoaded( ConfiguratorServiceData data )
        {
            Service.OnLoadCompleted.RemoveListener( OnServiceLoaded );
            Refresh( );
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Refresh( ){ }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( ) { }
    }
}