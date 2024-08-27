
namespace ZenjectLearning.Core.Commands
{
	/// <summary>
	/// This Command is a stand-alone object containing
	/// the before and after value during a data change
	/// </summary>
	public abstract class ValueChangedCommand< TValue > : ICommand
	{
		public TValue PreviousValue { get; private set; }
		public TValue CurrentValue { get; private set; }
		
		public ValueChangedCommand( TValue previousValue, TValue currentValue )
		{
			PreviousValue = previousValue;
			CurrentValue = currentValue;
		}

	}
}