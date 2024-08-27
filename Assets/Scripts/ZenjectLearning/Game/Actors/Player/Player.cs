using System;
using UnityEngine;
using ZenjectLearning.Game.Utilities;
using static ZenjectLearning.Game.CustomColorUtility;

namespace ZenjectLearning.Game
{
    public class Player : MonoBehaviour
    {
        public CharacterData Data
        {
            get => _data;
            set
            {
               _data = value;
                UpdateCharacterColorsAsync( );
            }
        }
        
        private CharacterData _data;
        
        [ SerializeField ]
        private Renderer Head;
        [ SerializeField ]
        private Renderer Chest;
        [ SerializeField ]
        private Renderer Legs;

        /// <summary>
        /// 
        /// </summary>
        private void Start( )
        {
            Array.ForEach( GetComponentsInChildren< TriggerDetector >( ), x =>
            {
                x.OnTriggerEnterEvent.AddListener( obj =>
                {
                    if( obj.GetComponent< CollectOnCollision >( ) is var collectable )
                    {
                        collectable.Collect( );
                    }
                } );
            } );
        }

        /// <summary>
        /// 
        /// </summary>
        private async void UpdateCharacterColorsAsync( )
        {
            if( Head != null ) await SetColorAsync( Head.material, _data.HeadColor, DefaultDuration );
            if( Chest != null ) await SetColorAsync( Chest.material, _data.ChestColor, DefaultDuration );
            if( Legs != null ) await SetColorAsync( Legs.material, _data.LegsColor, DefaultDuration );
        }
    }
}
