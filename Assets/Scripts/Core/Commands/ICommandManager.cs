using System;

namespace ZenjectLearning.Core.Commands
{
    public interface ICommandManager : IDisposable
    {
        void AddCommandListener< TCommand >( CommandManager.InvokeCommandDelegate< TCommand > del ) 
                                                where TCommand : ICommand;
        void RemoveCommandListener< TCommand >( CommandManager.InvokeCommandDelegate< TCommand > del ) 
                                                where TCommand : ICommand;
        
        int GetCommandListenerCount( );
        void InvokeCommand( ICommand command );
    }
}
