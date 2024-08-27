using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.MVCS
{
    public class GenericMVCS : MVCS< IModel, IView, IController, IService >
    {
        public GenericMVCS( IContext context ) : base( context )
        {
            
        }
    }
}