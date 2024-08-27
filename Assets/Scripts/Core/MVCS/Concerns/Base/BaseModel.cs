namespace ZenjectLearning.MVCS.Concerns
{
    public abstract class BaseModel : IModel
    {
        protected readonly IContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseModel( IContext context )
        {
            Context = context;
            Context.ModelLocator.AddItem( this );
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( ){ }
    }
}