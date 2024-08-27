using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Feature;

namespace ZenjectLearning.Game.Scenes
{
    public abstract class SceneBase : MonoBehaviour
    {
        protected Configurator Configurator;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="context"></param>
        /// <param name="view"></param>
        [ Inject ]
        public void Create( Configurator configurator, ConfiguratorContext context )
        {
             Configurator = configurator;
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnDestroy( ) => RemoveFeatures( );

        /// <summary>
        /// 
        /// </summary>
        protected virtual void RemoveFeatures( ){ }
    }
}