
namespace ZenjectLearning.Game.Feature
{
    public class CustomizeEnvironmentFeature : BaseFeature< ConfiguratorModel, 
                                                            CustomizeEnvironmentView, 
                                                            CustomizeEnvironmentController, 
                                                            ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public CustomizeEnvironmentFeature( ConfiguratorContext context, CustomizeEnvironmentView view ) : base( context, view )
        {
            
        }
    }
}