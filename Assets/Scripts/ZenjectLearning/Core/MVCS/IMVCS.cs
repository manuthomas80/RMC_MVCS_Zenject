using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.MVCS
{
    public interface IMVCS< TModel, TView, TController, TService >
                     where TModel : class, IModel
                     where TView : class, IView
                     where TController : class, IController
                     where TService : class, IService
    {
        IContextBase< TModel, TView, TController, TService > Context { get; }
    }
}