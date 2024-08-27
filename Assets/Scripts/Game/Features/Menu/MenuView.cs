using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ZenjectLearning.Game
{
    public class MenuView : FeatureViewBase
    {
        public readonly UnityEvent OnPlay = new ( );
        public readonly UnityEvent OnCustomizeCharacter = new ( );
        public readonly UnityEvent OnCustomizeEnvironment = new ( );
        
        [ SerializeField ]
        public TextMeshProUGUI StatusLabel;
        [ SerializeField ]
        public Button PlayGameButton;
        [ SerializeField ]
        public Button CustomizeCharacterButton;
        [ SerializeField ]
        public Button CustomizeEnvironmentButton;
        
        private Player Player;
        private Environment Environment;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="player"></param>
        /// <param name="env"></param>
        [ Inject ]
        public void Create( Player player, Environment env )
        {   
            Player = player;
            Environment = env;
            Refresh( );
            
            StatusLabel.text = $"Play or\nCustomize";
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void Refresh( )
        {
            if( ! Service.IsConfiguratorServiceLoaded ) return;
            Player.Data = Service.Data.CharacterData;
            Environment.Data = Service.Data.EnvironmentData;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable( )
        {
            PlayGameButton.onClick.AddListener( PlayButton_OnClicked );
            CustomizeCharacterButton.onClick.AddListener( CustomizeButton_OnClicked );
            CustomizeEnvironmentButton.onClick.AddListener( CustomizeEnvironmentButton_OnClicked ); 
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDisable( )
        {
            PlayGameButton.onClick.RemoveListener( PlayButton_OnClicked );
            CustomizeCharacterButton.onClick.RemoveListener( CustomizeButton_OnClicked );
            CustomizeEnvironmentButton.onClick.RemoveListener( CustomizeEnvironmentButton_OnClicked );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void PlayButton_OnClicked( ) => OnPlay.Invoke( );

        /// <summary>
        /// 
        /// </summary>
        private void CustomizeButton_OnClicked( ) => OnCustomizeCharacter.Invoke( );

        /// <summary>
        /// 
        /// </summary>
        private void CustomizeEnvironmentButton_OnClicked( ) => OnCustomizeEnvironment.Invoke( );
    }
}