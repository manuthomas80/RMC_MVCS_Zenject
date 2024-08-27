using ZenjectLearning.Core.Commands;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.HUD
{
    public class HudController : BaseController< ConfiguratorModel, HudView, ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public HudController( ConfiguratorContext context, 
                              ConfiguratorModel model, 
                              HudView view, 
                              ConfiguratorService service) : base( context, model, view, service )
        {
            View.OnBack.AddListener( OnBackClick );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            if( View != null ) View.OnBack.RemoveListener( OnBackClick );
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnBackClick( )
        {
            Context.CommandManager.InvokeCommand( new LoadSceneRequestCommand( SceneNames.Scene01_Menu ) );
        }
    }
}