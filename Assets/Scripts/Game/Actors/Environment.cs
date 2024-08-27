using System.Collections.Generic;
using UnityEngine;
using ZenjectLearning.Game.Scenes;
using static ZenjectLearning.Game.CustomColorUtility;

namespace ZenjectLearning.Game
{
    public class Environment : MonoBehaviour
    {
        public EnvironmentData Data
        {
            get => _data;
            set
            {
                _data = value;
                UpdateEnvColorsAsync( );
            }
        }
        
        private EnvironmentData _data;

        [ SerializeField ]
        private Renderer Floor;
        [ SerializeField ]
        private Renderer Background;
        [ SerializeField ]
        private List< Renderer > Decorations;
        [ SerializeField ]
        private PickUpSpawnArea _PickUpSpawnArea;
        public  PickUpSpawnArea  PickUpSpawnArea => _PickUpSpawnArea;
        
        /// <summary>
        /// 
        /// </summary>
        public Environment( )
        {
            //UpdateEnvColorsAsync( );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private async void UpdateEnvColorsAsync( )
        {
            var darker1 = TintOrShadeColor( _data.FloorColor, -50 );
            var darker2 = TintOrShadeColor( _data.BackgroundColor, -50 );
            var darker3 = TintOrShadeColor( _data.DecorationColor, -50 );
                
            if( Floor != null ) await SetColorAsync( Floor.material, darker1, DefaultDuration );
            if( Background != null ) await SetColorAsync( Background.material, darker2, DefaultDuration );
            
            foreach( Renderer decoration in Decorations )
            {
                if( decoration != null ) await SetColorAsync( decoration.material, darker3, DefaultDuration );
            }
        }
    }
}
