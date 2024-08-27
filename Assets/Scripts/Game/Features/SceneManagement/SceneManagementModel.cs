using UnityEngine.SceneManagement;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature
{
    public class SceneManagementModel : BaseModel
    {
        public Scene ActiveScene => SceneManager.GetActiveScene( );
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public SceneManagementModel( ConfiguratorContext context ) : base( context )
        {
            
        }
    }
}