using UnityEngine;
using Zenject;

namespace ZenjectLearning.Game.Scenes
{
    public class SceneCommonInstaller< T > : MonoInstaller< T > where T : MonoInstaller< T >
    {
        [ SerializeField ]
        private HudView HudView;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            Container.Bind< HudView >( ).FromInstance( HudView ).AsSingle( );
        }
    }
}