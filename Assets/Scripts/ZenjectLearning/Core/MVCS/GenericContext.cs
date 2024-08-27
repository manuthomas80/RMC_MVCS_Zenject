using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.MVCS
{
    public class GenericContext : Context< IModel, IView, IController, IService >, IContext
    {
        
    }
}