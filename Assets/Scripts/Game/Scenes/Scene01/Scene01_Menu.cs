using Zenject;
using ZenjectLearning.Game.Feature;
using ZenjectLearning.Game.Feature.HUD;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene01_Menu : SceneBase
    {
        [ Inject ]
        public void Create( ConfiguratorContext context, MenuView menuView, HudView hudView )
        {
            AddFeatures( context, menuView, hudView );
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddFeatures( ConfiguratorContext context, MenuView menuView, HudView hudView )
        {
            // Main menu
            Configurator.AddFeature( new MenuFeature( context, menuView ) );
            Configurator.AddFeature( new HudFeature( context, hudView ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void RemoveFeatures( )
        {
            Configurator.RemoveFeature< MenuFeature >( );
            Configurator.RemoveFeature< HudFeature >( );
        }
    }
}