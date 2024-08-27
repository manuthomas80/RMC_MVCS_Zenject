using ZenjectLearning.Core.Observables;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game
{
    public class ConfiguratorModel : BaseModel
    {
        public Observable< CharacterData > CharData { get; private set; } = new( );
        public Observable< EnvironmentData > EnvData { get; private set; } = new( );
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ConfiguratorModel( ConfiguratorContext context ) : base( context )
        {
            CharData.Value = CharacterData.FromDefaultValues( );
            EnvData.Value = EnvironmentData.FromDefaultValues( );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cData"></param>
        /// <param name="eData"></param>
        public void LoadModelData( CharacterData cData, EnvironmentData eData )
        {
            CharData.Value = cData;
            EnvData.Value = eData;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CharacterDataIsDefault( ) => CharData.Value.Equals( CharacterData.FromDefaultValues( ) );

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool EnvironmentDataIsDefault( ) => EnvData.Value.Equals( EnvironmentData.FromDefaultValues( ) );
    }
}