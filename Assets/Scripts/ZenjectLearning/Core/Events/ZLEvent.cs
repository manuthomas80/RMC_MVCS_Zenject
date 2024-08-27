namespace ZenjectLearning.Core.Events
{
    /// <summary>
    /// Interface for observable events.
    /// </summary>
    public interface IZLEvent
    {
        void AddListener( ZLEventHandler callback, bool willRefreshImmediately = false );
        void RemoveListener( ZLEventHandler call );
        void Invoke( );
        void OnValueChangedRefresh( );
    }

    /// <summary>
    /// Interface for observable events with values.
    /// </summary>
    public interface IZLEvent< T >
    {
        void AddListener( ZLEventHandler< T > callback, bool willRefreshImmediately = false, T value = default( T ) );
        void RemoveListener( ZLEventHandler< T > callback );
        void Invoke( T value );
        void OnValueChangedRefresh( T value );
    }

    /// <summary>
    /// Interface for observable events with two values.
    /// </summary>
    public interface IEvent< T, U >
    {
        void AddListener( ZLEventHandler< T, U > callback, bool willRefreshImmediately = false, T oldValue = default( T ), U newValue = default( U ) );
        void RemoveListener( ZLEventHandler< T, U > callback );
        void Invoke( T oldValue, U newValue );
        void OnValueChangedRefresh( T oldValue, U newValue );
    }

    /// <summary>
    /// Delegate for observable events.
    /// </summary>
    public delegate void ZLEventHandler( );

    /// <summary>
    /// Delegate for observable events with values.
    /// </summary>
    public delegate void ZLEventHandler< T >( T value );

    /// <summary>
    /// Delegate for observable events with two values.
    /// </summary>
    public delegate void ZLEventHandler< T, U >( T oldValue, U newValue );

    /// <summary>
    /// Base class for observable events without generic parameters.
    /// </summary>
    public class ZLEvent : IZLEvent
    {
        // Common functionality for both generic and non-generic events
        private event ZLEventHandler EventHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="willRefreshImmediately"></param>
        public void AddListener( ZLEventHandler callback, bool willRefreshImmediately = false )
        {
            EventHandler += callback;
            if( willRefreshImmediately ) Invoke( );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="call"></param>
        public void RemoveListener( ZLEventHandler call ) => EventHandler -= call;

        /// <summary>
        /// 
        /// </summary>
        public void Invoke( ) => EventHandler?.Invoke( );

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnValueChangedRefresh( ) => Invoke( );
    }

    /// <summary>
    /// The custom event for observable values.
    /// </summary>
    public class ZLEvent< T > : IZLEvent< T >
    {
        private event ZLEventHandler< T > EventHandler;

        public void AddListener( ZLEventHandler< T > callback, bool willRefreshImmediately = false, T value = default( T ) )
        {
            EventHandler += callback;
            if ( willRefreshImmediately )
            {
                Invoke( value );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public void RemoveListener( ZLEventHandler< T > callback ) => EventHandler -= callback;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Invoke( T value ) => EventHandler?.Invoke( value );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void OnValueChangedRefresh( T value ) => Invoke( value );
    }

    /// <summary>
    /// The custom event for observable values with two parameters.
    /// </summary>
    public class ZLEvent< T, U > : IEvent< T, U >
    {
        private event ZLEventHandler< T, U > EventHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="willRefreshImmediately"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void AddListener( ZLEventHandler< T, U > callback, bool willRefreshImmediately = false, T oldValue = default( T ), U newValue = default( U ) )
        {
            EventHandler += callback;
            if ( willRefreshImmediately )
            {
                Invoke( oldValue, newValue );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public void RemoveListener( ZLEventHandler< T, U > callback ) => EventHandler -= callback;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void Invoke( T oldValue, U newValue ) => EventHandler?.Invoke( oldValue, newValue );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void OnValueChangedRefresh( T oldValue, U newValue ) => Invoke( oldValue, newValue );
    }
}