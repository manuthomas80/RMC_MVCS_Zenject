using UnityEngine;
using ZenjectLearning.Core.Attributes;

namespace ZenjectLearning.Game
{
    /// <summary>
    /// Represents a file entry for local disk storage
    /// </summary>
    [ CustomFilePath( "ConfiguratorServiceData", CustomFilePathLocation.StreamingAssetsPath ) ]
    public class ConfiguratorServiceData
    {
        [ SerializeField ] 
        public EnvironmentData EnvironmentData = EnvironmentData.FromDefaultValues( );
        
        [ SerializeField ] 
        public CharacterData CharacterData = CharacterData.FromDefaultValues( );
    }
}
