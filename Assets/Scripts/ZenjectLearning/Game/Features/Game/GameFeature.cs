using ZenjectLearning.Game.Game;

namespace ZenjectLearning.Game.Feature
{
    public class GameFeature : BaseFeature< ConfiguratorModel, 
                                            GameView, 
                                            GameController, 
                                            ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public GameFeature( ConfiguratorContext context, GameView view ) : base( context, view )
        {
            
        }
    }
}