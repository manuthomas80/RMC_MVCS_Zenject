using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ZenjectLearning.Game
{
    public class CustomizeCharacterView : FeatureViewBase
    {
        public readonly UnityEvent OnRandomizeCharacterColor = new ( );
        
        [ SerializeField ]
        public TextMeshProUGUI StatusLabel;
        [ SerializeField ]
        public Button RandomizeCharacterColorButton;
        
        private Player Player;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        [ Inject ]
        public void Create( Player player )
        {   
            Player = player;
            Model.CharData.OnValueChanged.AddListener( CharacterData_OnValueChanged );
            Refresh( );
            
            StatusLabel.text = $"Customize\ncharacter\ncolors";
        }
        
        /// <summary>
        ///
        /// </summary>
        private void OnDestroy( )
        {
            Model.CharData.OnValueChanged.RemoveListener( CharacterData_OnValueChanged );
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Refresh( )
        {
            if( ! Service.IsConfiguratorServiceLoaded ) return;
            Player.Data = Service.Data.CharacterData;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable( )
        {
            RandomizeCharacterColorButton.onClick.AddListener( RandomizeCharacterColorButton_OnClicked );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnDisable( )
        {
            RandomizeCharacterColorButton.onClick.RemoveListener( RandomizeCharacterColorButton_OnClicked );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldvalue"></param>
        /// <param name="newvalue"></param>
        private void CharacterData_OnValueChanged( CharacterData oldvalue, CharacterData newvalue )
        {
            Player.Data = newvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RandomizeCharacterColorButton_OnClicked( )
        {
            OnRandomizeCharacterColor?.Invoke( );
        }
    }
}