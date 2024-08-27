using UnityEngine;
using ZenjectLearning.Game.Game;
using ZenjectLearning.Game.Utilities;

namespace ZenjectLearning.Game.Scenes
{
    public class Scene04_Installer : SceneCommonInstaller< Scene04_Installer >
    {
        [ SerializeField ]
        private GameView GameView;
        [ SerializeField ]
        private Player Player;
        [ SerializeField ]
        private GameObject PickUpPrefab;
        [ SerializeField ]
        private Environment Environment;
        [ SerializeField ]
        private float AngularSpeed = 100f;
        [ SerializeField ]
        private float LinearSpeed = 5f;
        [ SerializeField ]
        private TrackConfig CameraTrackConfig;
        [ SerializeField ]
        private GameDataView GameDataView;
        
        /// <summary>
        /// 
        /// </summary>
        public override void InstallBindings( )
        {
            base.InstallBindings( );
            Container.Bind< GameView >( ).FromInstance( GameView ).AsSingle( );
            Container.Bind< Environment >( ).FromInstance( Environment ).AsSingle( );
            BindPlayer( );
            //Pick up pool.
            Container.BindMemoryPool< PickUp, PickUp.Pool >( )
                     .WithInitialSize( 50 )
                     .FromSubContainerResolve( )
                     .ByNewPrefabInstaller< PickUpInstaller >( PickUpPrefab )
                     .UnderTransformGroup( "PickUps" );
            // Pickup manager.
            Container.BindInterfacesTo< PickUpManager >( ).AsSingle( );
            // Camera.
            Container.Bind< Camera >( ).FromComponentInHierarchy( ).AsSingle( );
            Container.BindInterfacesTo< CameraColorSetter >( ).AsSingle( );
            // Camera tracking.
            // Target.
            Container.BindInterfacesTo< TargetTracker >( ).AsSingle( );
            // Tracker Y position.
            Container.BindInstance( CameraTrackConfig ).WhenInjectedInto< TargetTracker >( );
            Container.Bind< Transform >( )
                     .WithId( ZenjectID.TargetTransform )
                     .FromInstance( Player.transform )
                     .WhenInjectedInto< TargetTracker >( );
            // Camera transform.
            Container.Bind< Transform >( )
                     .WithId( ZenjectID.OwnTransform )
                     .FromMethod( ctx => ctx.Container.Resolve< Camera >( ).transform )
                     .WhenInjectedInto< TargetTracker >( );
            // Game data.
            Container.BindInterfacesAndSelfTo< GameData >( ).AsSingle( );
            Container.BindInstance( GameDataView );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void BindPlayer( )
        {
            Container.Bind< Player >( ).FromInstance( Player ).AsSingle( );
            Container.BindInterfacesTo< PlayerController >( ).AsSingle( );
            Container.BindInstance( AngularSpeed ).WithId( ZenjectID.AngularSpeed ).WhenInjectedInto< PlayerController >( );
            Container.BindInstance( LinearSpeed ).WithId( ZenjectID.LinearSpeed ).WhenInjectedInto< PlayerController >( );
        }
    }
}