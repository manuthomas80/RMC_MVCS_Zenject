using ZenjectLearning.Game.Menu;

namespace ZenjectLearning.Game.Feature
{
    public class MenuFeature : BaseFeature< ConfiguratorModel, 
                                            MenuView, 
                                            MenuController, 
                                            ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public MenuFeature( ConfiguratorContext context, MenuView view ) : base( context, view )
        {
            
        }
    }
}