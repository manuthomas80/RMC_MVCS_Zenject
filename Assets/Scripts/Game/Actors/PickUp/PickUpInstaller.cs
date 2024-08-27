using UnityEngine;
using Zenject;
using ZenjectLearning.Game.Utilities;
using ZenjectLearning.Core;

namespace ZenjectLearning.Game
{
    public class PickUpInstaller : Installer< PickUpInstaller >
    {
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            // Note : FromResolve : On using Container.Bind< IDestroyable >( ).To< PickUp >( ).FromResolve( ),
            // Zenject is instructed to resolve ICollectable by looking for an existing binding for PickUp which is cached.
            
            Container.Bind< PickUp >( ).AsCached( );
            Container.Bind< ICollectable >( ).To< PickUp >( ).FromResolve( );
            Container.Bind< Transform >( ).FromComponentOnRoot( );
            Container.Bind< MeshRenderer >( ).FromComponentOnRoot( );
            Container.Bind< CollectOnCollision >( ).FromComponentOnRoot( );
        }
    }
}