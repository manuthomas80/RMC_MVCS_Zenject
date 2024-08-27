using UnityEngine;
using Zenject;
using ZenjectLearning.Core.IO;
using ZenjectLearning.Game.Feature;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    /// <summary>
    /// Root level systems which exists under Project context and agnostic to scenes ( persists across scenes )
    /// </summary>
    public class ConfiguratorInstaller : MonoInstaller< ConfiguratorInstaller >
    {   
        [ SerializeField ]
        private GameObject SceneManagementViewObj;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            // Configurator.
            Container.Bind< Configurator >( ).AsSingle( ).NonLazy( );
            Container.Bind< ConfiguratorContext >( ).AsSingle( );
            Container.Bind< ConfiguratorModel >( ).AsSingle( );
            Container.Bind< ConfiguratorService >( ).AsSingle( );
            // Persistent storage.
            Container.Bind< LocalDiskStorage >( ).AsSingle( );
            // Use this whereever a dummy service is needed ( not all MVCS require a service )
            Container.Bind< DummyService >( ).AsSingle( );
            // SceneManagement, which takes care of scene loading, unloading and associated UI
            Container.Bind< SceneManagementView >( ).FromComponentInNewPrefab( SceneManagementViewObj ).AsSingle( );
        }
    }
}
