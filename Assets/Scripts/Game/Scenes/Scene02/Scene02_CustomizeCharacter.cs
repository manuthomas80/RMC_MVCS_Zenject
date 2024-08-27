using Zenject;
using ZenjectLearning.Game.Feature;
using ZenjectLearning.Game.Feature.HUD;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene02_CustomizeCharacter : SceneBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        /// <param name="hudView"></param>
        [ Inject ]
        public void Create( ConfiguratorContext context, CustomizeCharacterView view, HudView hudView )
        {
            AddFeatures( context, view, hudView );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        /// <param name="hudView"></param>
        private void AddFeatures( ConfiguratorContext context, CustomizeCharacterView view, HudView hudView )
        {
            Configurator.AddFeature( new CustomizeCharacterFeature( context, view ) );
            Configurator.AddFeature( new HudFeature( context, hudView ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void RemoveFeatures( )
        {
            Configurator.RemoveFeature< CustomizeCharacterFeature >( );
            Configurator.RemoveFeature< HudFeature >( );
        }
    }
}