using System;
using ZenjectLearning.Core.Observables;
using ZenjectLearning.Game.Commands;

namespace ZenjectLearning.Game
{
    public class GameData : IDisposable
    {
        public Observable< int > PickUpsCollected { get; } = new ( );
        
        private readonly ConfiguratorContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GameData( ConfiguratorContext context )
        {
            Context = context;
            Context.CommandManager.AddCommandListener< PickUpCollectCommand >( OnPickUpsColected );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose( )
        {
            Context.CommandManager.RemoveCommandListener< PickUpCollectCommand >( OnPickUpsColected );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void OnPickUpsColected( PickUpCollectCommand e )
        {
            PickUpsCollected.Value++;
        }
    }
}
