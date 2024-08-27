using ZenjectLearning.MVCS;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    public class CustomizeEnvironmentController : BaseController< ConfiguratorModel, 
                                                                  CustomizeEnvironmentView, 
                                                                  ConfiguratorService >
    {
        public CustomizeEnvironmentController( ConfiguratorContext context, 
                                               ConfiguratorModel model, 
                                               CustomizeEnvironmentView view, 
                                               ConfiguratorService service) : base( context, model, view, service )
        {
            View.OnRandomizeEnvironmentColor.AddListener( OnRandomizeEnvironmentColorClick );
        }
        
        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            
            if( View != null )
            {
                View.OnRandomizeEnvironmentColor.RemoveListener( OnRandomizeEnvironmentColorClick );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRandomizeEnvironmentColorClick( )
        {
            Model.EnvData.Value = EnvironmentData.FromRandomValues( );
            Service.SaveEnvironmentData( Model.EnvData.Value );
        }
    }
}