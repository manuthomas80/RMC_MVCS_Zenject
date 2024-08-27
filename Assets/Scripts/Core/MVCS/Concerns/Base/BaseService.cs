namespace ZenjectLearning.MVCS.Concerns
{
    public abstract class BaseService : IService
    {
        protected readonly IContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseService( IContext context )
        {
            Context = context;
            Context.ServiceLocator.AddItem( this );
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( ){ }
    }
}