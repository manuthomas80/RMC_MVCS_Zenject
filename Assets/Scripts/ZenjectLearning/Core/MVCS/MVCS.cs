using MVC.Locator;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.MVCS
{
    public class MVCS< TModel, TView, TController, TService > : IMVCS< TModel, TView, TController, TService >
                                                                where TModel : class, IModel
                                                                where TView : class, IView
                                                                where TController : class, IController
                                                                where TService : class, IService
    {
        private IContextBase< TModel, TView, TController, TService > _Context { get; }
        public  IContextBase< TModel, TView, TController, TService >  Context => _Context;
        
        public Locator< TModel > ModelLocator           => _Context?.ModelLocator;
        public Locator< TView > ViewLocator             => _Context?.ViewLocator;
        public Locator< TController > ControllerLocator => _Context?.ControllerLocator;
        public Locator< TService > ServiceLocator       => _Context?.ServiceLocator;

        /// <summary>
        /// 
        /// </summary>
        protected MVCS( ) { }
        
        /// <summary>
        /// 
        /// </summary>
        public MVCS( IContextBase< TModel, TView, TController, TService > context )
        {
            _Context = context;
        }
    }
}