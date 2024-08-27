
using Zenject;

namespace ZenjectLearning.Game.Game
{
    public class GameView : FeatureViewBase
    {
        private Player Player;
        private Environment Environment;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="player"></param>
        /// <param name="env"></param>
        [ Inject ]
        public void Create( Player player, Environment env )
        {   
            Player = player;
            Environment = env;
            Refresh( );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void Refresh( )
        {
            if( ! Service.IsConfiguratorServiceLoaded ) return;
            Player.Data = Service.Data.CharacterData;
            Environment.Data = Service.Data.EnvironmentData;
        }
    }
}