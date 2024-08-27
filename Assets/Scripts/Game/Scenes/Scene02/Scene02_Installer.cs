using UnityEngine;
using Zenject;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene02_Installer : SceneCommonInstaller< Scene02_Installer >
    {
        [ SerializeField ]
        private CustomizeCharacterView CustomizeCharacterView;
        [ SerializeField ]
        private Scene02_CustomizeCharacter CustomizeCharacter;
        [ SerializeField ]
        private Player Player;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            base.InstallBindings( );
            Container.Bind< CustomizeCharacterView >( ).FromInstance( CustomizeCharacterView ).AsSingle( );
            Container.Bind< Scene02_CustomizeCharacter >( ).FromInstance( CustomizeCharacter ).AsSingle( );
            Container.Bind< Player >( ).FromInstance( Player ).AsSingle( );
        }
    }
}