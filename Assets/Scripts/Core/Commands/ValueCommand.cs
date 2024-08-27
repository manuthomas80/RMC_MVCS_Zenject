
namespace ZenjectLearning.Core.Commands
{
	/// <summary>
	/// This Command is a stand-alone object containing
	/// a value of data.
	/// </summary>
	public abstract class ValueCommand<TValue> : ICommand
	{
		public TValue Value { get; private set; }
		
		public ValueCommand(TValue value)
		{
			Value = value;
		}
	}
}