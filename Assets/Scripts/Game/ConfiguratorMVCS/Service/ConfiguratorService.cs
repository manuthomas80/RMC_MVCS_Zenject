using UnityEngine;
using UnityEngine.Events;
using ZenjectLearning.Core.IO;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfiguratorService : BaseService
    {
        public class ConfiguratorServiceUnityEvent : UnityEvent< ConfiguratorServiceData > { }
        public readonly ConfiguratorServiceUnityEvent OnLoadCompleted = new( );
        
        public bool IsConfiguratorServiceLoaded => Data != null;

        public ConfiguratorServiceData Data { get; private set; }
        private readonly LocalDiskStorage LocalDiskStorage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="localDiskStorage"></param>
        public ConfiguratorService( ConfiguratorContext context, LocalDiskStorage localDiskStorage ) : base( context )
        {
            LocalDiskStorage = localDiskStorage;
            
            if( ! LocalDiskStorage.Has< ConfiguratorServiceData >( ) )
            {
                LocalDiskStorage.Save( new ConfiguratorServiceData( ) );
            }
            
            Load( );
        }

        /// <summary>
        /// 
        /// </summary>
        private void Load( )
        {
            Data = LocalDiskStorage.Load< ConfiguratorServiceData >( );
            if( Data == null )
            {
                Debug.LogError( "Error: LoadCharacterData failed." );
                return;
            }
            OnLoadCompleted.Invoke( Data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environmentData"></param>
        public void SaveEnvironmentData( EnvironmentData environmentData )
        {
            Data = LocalDiskStorage.Load< ConfiguratorServiceData >( );
            if( Data == null )
            {
                Debug.LogError( "Error: SaveEnvironmentData failed." );
                return;
            }

            Data = LocalDiskStorage.Load< ConfiguratorServiceData >( );
            Data.EnvironmentData = environmentData;
            LocalDiskStorage.Save( Data );

            OnLoadCompleted.Invoke( Data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterData"></param>
        public void SaveCharacterData( CharacterData characterData )
        {
            Data = LocalDiskStorage.Load< ConfiguratorServiceData >( );
            if( Data == null )
            {
                Debug.LogError( "Error: SaveCharacterData failed." );
                return;
            }

            Data = LocalDiskStorage.Load< ConfiguratorServiceData >( );
            Data.CharacterData = characterData;
            LocalDiskStorage.Save( Data );

            OnLoadCompleted.Invoke( Data );
        }
    }
}
