using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    public class CustomizeCharacterController : BaseController< ConfiguratorModel, 
                                                                CustomizeCharacterView, 
                                                                ConfiguratorService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public CustomizeCharacterController( ConfiguratorContext context, 
                                             ConfiguratorModel model,
                                             CustomizeCharacterView view, 
                                             ConfiguratorService service ) : base( context, model, view, service )
        {
            View.OnRandomizeCharacterColor.AddListener( OnRandomizeCharacterColorClick );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            
            if( View != null )
            {
                View.OnRandomizeCharacterColor.RemoveListener( OnRandomizeCharacterColorClick );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRandomizeCharacterColorClick( )
        {
            Model.CharData.Value = CharacterData.FromRandomValues( );
            Service.SaveCharacterData( Model.CharData.Value );
        }
    }
}