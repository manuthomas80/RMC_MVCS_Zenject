using Zenject;
using ZenjectLearning.Game.Feature.HUD;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene04_Game : SceneBase
    {
        [ Inject ]
        public void Create( ConfiguratorContext context, HudView hudView )
        {
            AddFeatures( context, hudView );
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddFeatures( ConfiguratorContext context, HudView hudView )
        {
            // Main menu
            Configurator.AddFeature( new HudFeature( context, hudView ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void RemoveFeatures( )
        {
            Configurator.RemoveFeature< HudFeature >( );
        }
    }
}