using MVC.Locator;

namespace ZenjectLearning.Game.Feature
{
    internal interface IFeatureBuilder< TFeature >
    {
        Locator< TFeature > FeatureLocator { get; }
    }
}