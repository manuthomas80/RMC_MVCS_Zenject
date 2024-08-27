using ZenjectLearning.Core.Events;

namespace ZenjectLearning.Core.Observables
{
    /// <summary>
    /// Wrapper where any changes to value of type
    /// <see cref="TValue" /> can be observable via events.
    /// </summary>
    public class Observable< TValue >
    {
        public readonly IEvent< TValue, TValue > OnValueChanged;

        /// <summary>
        /// Keep this property name as "Value".
        /// </summary>
        public TValue Value
        {
            set
            {
                CurrentValue = OnValueChanging( CurrentValue, value );
                OnValueChanged.Invoke( PreviousValue, CurrentValue );
            }
            get
            {
                return CurrentValue;
            }
        }

        private TValue CurrentValue;
        private TValue PreviousValue;

        /// <summary>
        /// 
        /// </summary>
        public Observable( )
        {
            OnValueChanged = new ZLEvent< TValue, TValue >( );
        }

        /// <summary>
        /// Refresh the observers by recalling Invoke( )
        /// with the latest values.
        /// </summary>
        public void OnValueChangedRefresh( )
        {
            OnValueChanged.OnValueChangedRefresh( PreviousValue, CurrentValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected virtual TValue OnValueChanging( TValue previousValue, TValue newValue )
        {
            // Optional: Override method to gate/police the value changes
            PreviousValue = previousValue;
            return newValue;
        }
    }
}
