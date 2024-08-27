using ZenjectLearning.Game.HUD;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature.HUD
{
    public class HudFeature : BaseFeature< ConfiguratorModel, 
                                           HudView, 
                                           HudController, 
                                           ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public HudFeature( ConfiguratorContext context, HudView view ) : base( context, view )
        {
            
        }
    }
}