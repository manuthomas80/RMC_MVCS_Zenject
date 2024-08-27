using ZenjectLearning.Game.Feature;
using ZenjectLearning.MVCS;

namespace ZenjectLearning.Game
{
    public class Configurator : GenericMVCS
    {
        private readonly ConfiguratorModel Model;
        private readonly ConfiguratorService Service;
        
        private FeatureBuilder FeatureBuilder { get; set; }

        /// <summary>
        /// Initializes the Configurator with the given context, model, and service.
        /// </summary>
        /// <param name="context">The configurator context.</param>
        /// <param name="model">The configurator model.</param>
        /// <param name="service">The configurator service.</param>
        /// <param name="view"></param>
        public Configurator( ConfiguratorContext context, 
                             ConfiguratorModel model, 
                             ConfiguratorService service,
                             SceneManagementView view ) : base( context )
        {
            Model = model;
            Service = service;
            FeatureBuilder = new FeatureBuilder( );
            // Add scene management feature.
            AddFeature( new SceneManagementFeature( context, view ) );
        }
        
        /// <summary>
        /// Checks if the specified feature exists by key.
        /// </summary>
        /// <param name="key">The feature key (optional).</param>
        /// <typeparam name="TFeature">The type of feature.</typeparam>
        /// <returns>True if the feature exists; otherwise, false.</returns>
        public bool HasFeature< TFeature >( string key = "" ) where TFeature : IBaseFeature
        {
            return FeatureBuilder.HasFeature< TFeature >( key );
        }

        /// <summary>
        /// Adds a feature to the configurator.
        /// </summary>
        /// <param name="feature">The feature to add.</param>
        /// <param name="key">The feature key (optional).</param>
        /// <typeparam name="TFeature">The type of feature.</typeparam>
        public void AddFeature< TFeature >( TFeature feature, string key = "" ) where TFeature : IBaseFeature
        {
            FeatureBuilder.AddFeature< TFeature >( feature, key );
        }

        /// <summary>
        /// Removes a feature by key with the option to dispose it.
        /// </summary>
        /// <param name="key">The feature key (optional).</param>
        /// <param name="willDispose">Whether to dispose the feature after removal.</param>
        /// <typeparam name="TFeature">The type of feature.</typeparam>
        public void RemoveFeature< TFeature >( string key = "", bool willDispose = false ) where TFeature : IBaseFeature
        {
            FeatureBuilder.RemoveFeature< TFeature >( key, willDispose );
        }
        
        /// <summary>
        /// Removes and disposes of the specified feature.
        /// </summary>
        /// <typeparam name="TFeature">The type of feature.</typeparam>
        public void RemoveAndDisposeFeature< TFeature >( ) where TFeature : IBaseFeature
        {
            RemoveFeature< TFeature >( "", true );
        }
    }
}
