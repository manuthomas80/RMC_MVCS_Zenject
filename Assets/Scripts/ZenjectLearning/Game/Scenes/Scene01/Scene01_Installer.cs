using UnityEngine;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene01_Installer : SceneCommonInstaller< Scene01_Installer >
    {
        [ SerializeField ]
        private MenuView MenuView;
        [ SerializeField ]
        private Scene01_Menu Menu;
        [ SerializeField ]
        private Player Player;
        [ SerializeField ]
        private Environment Environment;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            base.InstallBindings( );
            Container.Bind< MenuView >( ).FromInstance( MenuView ).AsSingle( );
            Container.Bind< Scene01_Menu >( ).FromInstance( Menu ).AsSingle( );
            Container.Bind< Player >( ).FromInstance( Player ).AsSingle( );
            Container.Bind< Environment >( ).FromInstance( Environment ).AsSingle( );
        }
    }
}