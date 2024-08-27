using MVC.Locator;
using UnityEngine;

namespace ZenjectLearning.Game.Feature
{
    public class BaseFeatureBuilder< TFeature > : IFeatureBuilder< TFeature > where TFeature : IFeature
    {
        public Locator< TFeature > FeatureLocator { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseFeatureBuilder( )
        {
            FeatureLocator = new Locator< TFeature >( );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasFeature< T >( string key = "" ) where T : TFeature
        {
            return FeatureLocator.HasItem< T >( key );    
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        public void AddFeature< T >( T feature, string key = "" ) where T : TFeature
        {
            FeatureLocator.AddItem( feature, key );
            feature.Build( );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveFeature< T >( string key = "", bool willDispose = false ) where T : TFeature
        {
            if( HasFeature< T >( key ) )
            {
                var feature = FeatureLocator.GetItem< T >( key );
                feature?.Dispose( );
                FeatureLocator.RemoveItem< T >( key, willDispose );
            }
            else
            {
                Debug.LogError( $"Feature : {typeof( T )} already exists !" );
                return;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        public void RemoveAndDisposeFeature< T >( string key = "" ) where T : TFeature
        {
            RemoveFeature< T >( key, true );
        }
    }
}