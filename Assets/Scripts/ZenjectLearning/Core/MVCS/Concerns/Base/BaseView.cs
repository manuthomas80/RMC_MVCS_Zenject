namespace ZenjectLearning.MVCS.Concerns
{
    public abstract class BaseView : IView
    {
        protected readonly IContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseView( IContext context )
        {
            Context = context;
            Context.ViewLocator.AddItem( this );
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( ){ }
    }
}