using System;

namespace ZenjectLearning.Game.Feature
{
    public interface IFeature : IDisposable
    {
        void Build( );
    }
}