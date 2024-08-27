using System.Collections.Generic;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Core.Commands
{
    /// <summary>
    /// This <see cref="IExecutableCommand" /> operates on
    /// a list of <see cref="IExecutableCommand" /> sub-instances
    /// like a macro.
    /// </summary>
    public class BaseCompoundExecutableCommand : IExecutableCommand
    {
        public virtual bool CanUndo { get { return true; } }
        protected List< IExecutableCommand > Commands { get; private set; } = new( );

        /// <summary>
        /// Executes all commands in the list.
        /// </summary>
        /// <param name="context">The context for command execution.</param>
        /// <returns>True if all commands execute successfully; otherwise, false.</returns>
        public virtual bool Execute( IContextBase context )
        {
            bool didAllExecute = Commands.Count > 0;
            foreach( IExecutableCommand command in Commands )
            {
                if( ! command.Execute( context ) )
                {
                    didAllExecute = false;
                }
            }
            return didAllExecute;
        }

        /// <summary>
        /// Undoes all commands in the list.
        /// </summary>
        /// <param name="context">The context for command undoing.</param>
        /// <returns>True if all commands undo successfully; otherwise, false.</returns>
        public virtual bool Undo( IContextBase context )
        {
            bool didAllUndo = Commands.Count > 0;
            foreach( IExecutableCommand command in Commands )
            {
                if( ! command.Undo( context ) )
                {
                    didAllUndo = false;
                }
            }
            return didAllUndo;
        }
    }
}