using System;
using System.Collections.Generic;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Core.Commands
{
    /// <summary>
    /// The CommandManager allows to observe and invoke
    /// <see cref="ICommand" /> instances.
    ///
    /// Summary
    ///		* Call AddCommandListener() to observe a command.
    ///		* Call Invoke(). This executes nothing, but notifies any listeners.
    ///		* Call Execute(). This executes and notifies any listeners.
    ///		* Call Undo(). This undoes something and notifies any listeners.
    ///
    /// Related Types
    ///		* ICommand           relates to Invoke(), AddCommandListener()
    ///		* IExecutableCommand relates Invoke(), AddCommandListener(), Execute(), Undo()
    /// 
    /// </summary>
    public class CommandManager : ICommandManager, IDisposable
    {
        private IContextBase _context;
        
        // Invoke
        public delegate void InvokeCommandDelegate< TCommand >( TCommand e ) where TCommand : ICommand;
        private delegate void InvokeCommandDelegate( ICommand e );
        private Dictionary< Type, InvokeCommandDelegate > InvokeCommandDelegates = new ( );
        private Dictionary< Delegate, InvokeCommandDelegate > InvokeCommandDelegatesLookup = new ( );

        // Undo
        public delegate void UndoCommandDelegate< TExecutableCommand >( TExecutableCommand e ) where TExecutableCommand : IExecutableCommand;
        private delegate void UndoCommandDelegate( IExecutableCommand e );
        private Dictionary< Type, UndoCommandDelegate > UndoCommandDelegates = new ( );
        private Dictionary< Delegate, UndoCommandDelegate > UndoCommandDelegatesLookup = new ( );

        public CommandManager( IContextBase context )
        {
            _context = context;
        }
        
        /// <summary>
        /// Invokes the specified command.
        /// </summary>
        public void InvokeCommand( ICommand command )
        {
            if( InvokeCommandDelegates.TryGetValue( command.GetType( ), out InvokeCommandDelegate del ) )
            {
                del.Invoke( command );
            }
        }

        public int GetCommandListenerCount( )
        {
            return InvokeCommandDelegates.Count;
        }

        /// <summary>
        /// Executes the specified executable command.
        /// </summary>
        public bool ExecuteCommand( IExecutableCommand executableCommand )
        {
            bool didExecute = executableCommand.Execute( _context );
            InvokeCommand( executableCommand );
            return didExecute;
        }

        /// <summary>
        /// Undoes the specified executable command.
        /// </summary>
        public bool UndoCommand( IExecutableCommand executableCommand )
        {
            bool didUndo = false;

            if( executableCommand.CanUndo )
            {
                didUndo = executableCommand.Undo( _context );

                if( UndoCommandDelegates.TryGetValue( executableCommand.GetType( ), out UndoCommandDelegate undoCommandDelegate ) )
                {
                    undoCommandDelegate.Invoke( executableCommand );
                }
            }

            return didUndo;
        }

        /// <summary>
        /// Adds a command listener for the specified command type.
        /// </summary>
        public void AddCommandListener< TCommand >( InvokeCommandDelegate< TCommand > invokeDelegate ) where TCommand : ICommand
        {
            AddCommandListenerImpl( invokeDelegate );
        }

        /// <summary>
        /// Adds command and undo listeners for the specified executable command type.
        /// </summary>
        public void AddCommandListener< TExecutableCommand >(
            InvokeCommandDelegate< TExecutableCommand > invokeDelegate,
            UndoCommandDelegate< TExecutableCommand > undoDelegate ) where TExecutableCommand : IExecutableCommand
        {
            AddCommandListenerImpl( invokeDelegate );
            AddUndoCommandListenerImpl( undoDelegate );
        }

        private void AddCommandListenerImpl< TCommand >( InvokeCommandDelegate< TCommand > del ) where TCommand : ICommand
        {
            if( InvokeCommandDelegatesLookup.ContainsKey( del ) )
            {
                return;
            }

            InvokeCommandDelegate internalDelegate = ( e ) => del( ( TCommand ) e );
            InvokeCommandDelegatesLookup[ del ] = internalDelegate;

            if( InvokeCommandDelegates.TryGetValue( typeof( TCommand ), out InvokeCommandDelegate tempDel ) )
            {
                InvokeCommandDelegates[ typeof( TCommand ) ] = tempDel += internalDelegate;
            }
            else
            {
                InvokeCommandDelegates[ typeof( TCommand ) ] = internalDelegate;
            }
        }
        
        private void AddUndoCommandListenerImpl< TExecutableCommand >( UndoCommandDelegate< TExecutableCommand > undoCommandDelegate ) where TExecutableCommand : IExecutableCommand
        {
            if( InvokeCommandDelegatesLookup.ContainsKey( undoCommandDelegate ) )
            {
                return;
            }

            UndoCommandDelegate undoCommandDelegateResult = ( e ) => undoCommandDelegate( ( TExecutableCommand ) e );
            UndoCommandDelegatesLookup[ undoCommandDelegate ] = undoCommandDelegateResult;

            if( UndoCommandDelegates.TryGetValue( typeof( TExecutableCommand ), out UndoCommandDelegate tempDel ) )
            {
                UndoCommandDelegates[ typeof( TExecutableCommand ) ] = tempDel += undoCommandDelegateResult;
            }
            else
            {
                UndoCommandDelegates[ typeof( TExecutableCommand ) ] = undoCommandDelegateResult;
            }
        }

        /// <summary>
        /// Removes a command listener for the specified command type.
        /// </summary>
        public void RemoveCommandListener< TCommand >( InvokeCommandDelegate< TCommand > del ) where TCommand : ICommand
        {
            if( InvokeCommandDelegatesLookup.TryGetValue( del, out InvokeCommandDelegate internalDelegate ) )
            {
                if( InvokeCommandDelegates.TryGetValue( typeof( TCommand ), out InvokeCommandDelegate tempDel ) )
                {
                    tempDel -= internalDelegate;
                    if( tempDel == null )
                    {
                        InvokeCommandDelegates.Remove( typeof( TCommand ) );
                    }
                    else
                    {
                        InvokeCommandDelegates[ typeof( TCommand ) ] = tempDel;
                    }
                }

                InvokeCommandDelegatesLookup.Remove( del );
            }
        }

        /// <summary>
        /// Disposes the CommandManager and cleans up resources.
        /// </summary>
        public void Dispose( )
        {
            InvokeCommandDelegates.Clear( );
            InvokeCommandDelegatesLookup.Clear( );
            UndoCommandDelegates.Clear( );
            UndoCommandDelegatesLookup.Clear( );
        }
    }
}
