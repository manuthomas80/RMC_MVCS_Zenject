namespace ZenjectLearning.Core
{
    public interface IConfigurable< TConfig >
    {
        void Configure( TConfig config );
    }
}