using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Core.Commands
{
	/// <summary>
	/// Complex type of <see cref="ICommand"/>.
	///
	/// This type can be used with the <see cref="CommandManager"/> related to
	/// operations of Invoke(), AddCommandListener(), Execute(), Undo()
	/// 
	/// </summary>
	public interface IExecutableCommand : ICommand
	{
		bool CanUndo { get; }
		bool Execute( IContextBase context );
		bool Undo( IContextBase context );
	}
}
