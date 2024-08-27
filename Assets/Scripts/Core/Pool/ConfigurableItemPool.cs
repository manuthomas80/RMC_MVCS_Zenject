using Zenject;

namespace ZenjectLearning.Core.Pool
{
    public class ConfigurableItemPool< TConfig, TItem > : MemoryPool< TConfig, TItem >
                                                          where TItem : IConfigurable< TConfig >
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="item"></param>
        protected override void Reinitialize( TConfig config, TItem item )
        {
            item.Configure( config );
        }
    }
}