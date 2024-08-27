namespace ZenjectLearning.MVCS.Concerns
{
    public abstract class BaseController< TModel, TView, TService > : IController
                          where TModel : class, IModel
                          where TView : class, IView
                          where TService : class, IService
    {
        protected readonly IContext Context;
        protected TModel Model { get; private set; }
        protected TView View { get; private set; }
        protected TService Service { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="service"></param>
        public BaseController( IContext context, TModel model, TView view, TService service )
        {
            Model = model;
            View = view;
            Service = service;
            
            Context = context;
            Context.ControllerLocator.AddItem( this );
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( ){ }
    }
}