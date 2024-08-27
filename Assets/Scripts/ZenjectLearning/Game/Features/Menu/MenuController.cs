using ZenjectLearning.Core.Commands;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Menu
{
    public class MenuController : BaseController< ConfiguratorModel, 
                                                  MenuView, 
                                                  ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public MenuController( ConfiguratorContext context, 
                               ConfiguratorModel model, 
                               MenuView view, 
                               ConfiguratorService service) : base( context, model, view, service )
        {
            View.OnPlay.AddListener( OnPlayClick );
            View.OnCustomizeCharacter.AddListener( OnCustomizeCharacterClick );
            View.OnCustomizeEnvironment.AddListener( OnCustomizeEnvironmentClick );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            
            if( View != null )
            {
                View.OnPlay.RemoveListener( OnPlayClick );
                View.OnCustomizeCharacter.RemoveListener( OnCustomizeCharacterClick );
                View.OnCustomizeEnvironment.RemoveListener( OnCustomizeEnvironmentClick );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnPlayClick( )
        {
            Context.CommandManager.InvokeCommand( new LoadSceneRequestCommand( SceneNames.Scene04_Game ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnCustomizeCharacterClick( )
        {
            Context.CommandManager.InvokeCommand( new LoadSceneRequestCommand( SceneNames.Scene02_CustomizeCharacter ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnCustomizeEnvironmentClick( )
        {
            Context.CommandManager.InvokeCommand( new LoadSceneRequestCommand( SceneNames.Scene03_CustomizeEnvironment ) );
        }
    }
}