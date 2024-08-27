using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace ZenjectLearning
{
    public class GameInstaller : MonoInstaller< GameInstaller >
    {
        public override void InstallBindings( )
        {
            Container.BindInstance( 5 );
            Container.Bind< Foo >( ).AsSingle( ).NonLazy( );
        }
    }
}