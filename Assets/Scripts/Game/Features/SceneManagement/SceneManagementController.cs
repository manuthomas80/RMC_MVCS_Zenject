using UnityEngine;
using UnityEngine.SceneManagement;
using ZenjectLearning.Core.Commands;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature
{
    public class SceneManagementController : BaseController< SceneManagementModel, SceneManagementView, DummyService >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public SceneManagementController( ConfiguratorContext context, 
                                          SceneManagementModel model, 
                                          SceneManagementView view, 
                                          DummyService service ) : base( context, model, view, service )
        {
            Context.CommandManager.AddCommandListener< LoadSceneRequestCommand >( OnLoadSceneRequest );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose( )
        {
            base.Dispose( );
            Context.CommandManager.RemoveCommandListener< LoadSceneRequestCommand >( OnLoadSceneRequest );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        private void OnLoadSceneRequest( LoadSceneRequestCommand c )
        {
            if( SceneManager.GetActiveScene( ).name.Equals( c.SceneName ) ) return;
            
            View.FadeIn( ( ) =>
            {
                SceneManager.LoadSceneAsync( c.SceneName ).completed += OnSceneLoadComplete;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        private void OnSceneLoadComplete( AsyncOperation op )
        {
            op.completed -= OnSceneLoadComplete;
            
            View.FadeOut( ( )=>
            {
                Context.CommandManager.InvokeCommand
                ( 
                    new LoadSceneCompletedCommand( SceneManager.GetActiveScene( ).name ) 
                );    
            });
        }
    }
}