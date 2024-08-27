using System;
using MVC.Locator;
using ZenjectLearning.Core.Commands;

namespace ZenjectLearning.MVCS.Concerns
{
    public interface IContextBase< TModel, TView, TController, TService > : IContextBase
                     where TModel : class, IModel
                     where TView : class, IView
                     where TController : class, IController
                     where TService : class, IService
    {
        Locator< TModel > ModelLocator { get; }
        Locator< TView > ViewLocator { get; }
        Locator< TController > ControllerLocator { get; }
        Locator< TService > ServiceLocator { get; }
        
        ICommandManager CommandManager { get; }
    }
    
    public interface IContextBase{ }
}