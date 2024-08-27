using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Feature;
using ZenjectLearning.Game.Feature.HUD;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene03_CustomizeEnvironment : SceneBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        /// <param name="hudView"></param>
        [ Inject ]
        public void Create( ConfiguratorContext context, CustomizeEnvironmentView view, HudView hudView )
        {
            AddFeatures( context, view, hudView );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        /// <param name="hudView"></param>
        private void AddFeatures( ConfiguratorContext context, CustomizeEnvironmentView view, HudView hudView )
        {
            Configurator.AddFeature( new CustomizeEnvironmentFeature( context, view ) );
            Configurator.AddFeature( new HudFeature( context, hudView ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void RemoveFeatures( )
        {
            Configurator.RemoveFeature< CustomizeEnvironmentFeature >( );
            Configurator.RemoveFeature< HudFeature >( );
        }
    }
}