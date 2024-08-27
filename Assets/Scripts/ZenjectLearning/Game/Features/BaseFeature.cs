using System;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature
{
    public abstract class BaseFeature< TModel, TView, TController, TService > : IBaseFeature
                                                                                where TModel : class, IModel
                                                                                where TView : class, IView
                                                                                where TController : class, IController
                                                                                where TService : class, IService
    {
        protected readonly IContext Context;
        protected TView View;
        protected TController Controller;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        protected BaseFeature( IContext context, TView view )
        {
            Context = context;
            View = view;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Build( ) => Controller = CreateController( );

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual TController CreateController( )
        {
            var configuratorContext = Context as ConfiguratorContext;
            var model = Context.ModelLocator.GetItem< TModel >( );
            var service = Context.ServiceLocator.GetItem< TService >( );

            return (TController) Activator.CreateInstance( typeof( TController ), configuratorContext, model, View, service );
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose( )
        {
            Controller = null;
            View = null;
            Context.ControllerLocator.SafeRemoveAndDisposeItem< TController >( );
            Context.ViewLocator.SafeRemoveAndDisposeItem< TView >( );
        }
    }
}