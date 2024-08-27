using UnityEngine;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene03_Installer : SceneCommonInstaller< Scene03_Installer >
    {
        [ SerializeField ]
        private CustomizeEnvironmentView CustomizeEnvView;
        [ SerializeField ]
        private Scene03_CustomizeEnvironment CustomizeEnv;
        [ SerializeField ]
        private Environment Environment;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            base.InstallBindings( );
            Container.Bind< CustomizeEnvironmentView >( ).FromInstance( CustomizeEnvView ).AsSingle( );
            Container.Bind< Scene03_CustomizeEnvironment >( ).FromInstance( CustomizeEnv ).AsSingle( );
            Container.Bind< Environment >( ).FromInstance( Environment ).AsSingle( );
        }
    }
}