using UnityEngine;
using Zenject;

namespace ZenjectLearning.Game
{
    public class CameraColorSetter : IInitializable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="context"></param>
        public CameraColorSetter( Camera cam, ConfiguratorContext context )
        {
            cam.backgroundColor = context.ServiceLocator
                                         .GetItem< ConfiguratorService >( )
                                         .Data
                                         .EnvironmentData
                                         .BackgroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize( ){ }
    }
}