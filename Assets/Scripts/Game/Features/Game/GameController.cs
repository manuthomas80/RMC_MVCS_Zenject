using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Game
{
    public class GameController : BaseController< ConfiguratorModel, 
                                                  GameView, 
                                                  ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public GameController( ConfiguratorContext context, 
                               ConfiguratorModel model, 
                               GameView view, 
                               ConfiguratorService service) : base( context, model, view, service )
        {
            if( ! Service.IsConfiguratorServiceLoaded )
                Service.OnLoadCompleted.AddListener( ServiceOnLoadComplete );
            else
                LoadModelData( Service.Data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void ServiceOnLoadComplete( ConfiguratorServiceData data )
        {
            Service.OnLoadCompleted.RemoveListener( ServiceOnLoadComplete );
            LoadModelData( data );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void LoadModelData( ConfiguratorServiceData data )
        {
            Model.LoadModelData( data.CharacterData, data.EnvironmentData );
        }
    }
}