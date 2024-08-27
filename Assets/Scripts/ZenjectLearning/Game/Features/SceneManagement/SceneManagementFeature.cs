using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature
{
    public class SceneManagementFeature : BaseFeature< SceneManagementModel,
                                                       SceneManagementView,
                                                       SceneManagementController,
                                                       DummyService >
    {
        private SceneManagementModel Model;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public SceneManagementFeature( ConfiguratorContext context, SceneManagementView view ) : base( context, view )
        {
            Model = new SceneManagementModel( Context as ConfiguratorContext );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            
            Model = null;
            Context.ModelLocator.SafeRemoveAndDisposeItem< SceneManagementModel >( );
        }
    }
}