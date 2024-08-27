using MVC.Locator;
using ZenjectLearning.Core.Commands;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.MVCS
{
    public class Context< TModel, TView, TController, TService > : IContextBase< TModel, TView, TController, TService >
                                                                   where TModel : class, IModel
                                                                   where TView : class, IView
                                                                   where TController : class, IController
                                                                   where TService : class, IService
    {
        public Locator< TModel > ModelLocator => _ModelLocator;
        public Locator< TView > ViewLocator =>_ViewLocator;
        public Locator< TController > ControllerLocator => _ControllerLocator;
        public Locator< TService > ServiceLocator => _ServiceLocator;
        public ICommandManager CommandManager { get { return _commandManager; } }

        private readonly Locator< TModel > _ModelLocator;
        private readonly Locator< TView > _ViewLocator;
        private readonly Locator< TController > _ControllerLocator;
        private readonly Locator< TService > _ServiceLocator;
        private readonly ICommandManager _commandManager;

        /// <summary>
        /// 
        /// </summary>
        public Context( )
        {
            _ModelLocator = new Locator< TModel >( );
            _ViewLocator = new Locator< TView >( );
            _ControllerLocator = new Locator< TController >( );
            _ServiceLocator = new Locator< TService >( );
            _commandManager = new CommandManager( this );
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose( )
        {
            _ModelLocator.Reset( );
            _ViewLocator.Reset( );
            _ControllerLocator.Reset( );
            _ServiceLocator.Reset( );
            _commandManager.Dispose( );
        }
    }
}