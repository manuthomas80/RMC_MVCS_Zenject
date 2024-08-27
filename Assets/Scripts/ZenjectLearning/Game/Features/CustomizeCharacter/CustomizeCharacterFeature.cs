
namespace ZenjectLearning.Game.Feature
{
    public class CustomizeCharacterFeature : BaseFeature< ConfiguratorModel, 
                                                          CustomizeCharacterView, 
                                                          CustomizeCharacterController, 
                                                          ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public CustomizeCharacterFeature( ConfiguratorContext context, CustomizeCharacterView view ) : base( context, view )
        {
            
        }
    }
}