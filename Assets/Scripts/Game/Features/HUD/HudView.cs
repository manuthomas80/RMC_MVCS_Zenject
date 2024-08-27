using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using ZenjectLearning.Game.Feature;

namespace ZenjectLearning.Game
{
    public class HudView : FeatureViewBase
    {
        public readonly UnityEvent OnBack = new( );
        
        [ SerializeField ]
        private TextMeshProUGUI StatusLabel;
        [ SerializeField ]
        private Button BackButton;
        
        /// <summary>
        /// 
        /// </summary>
        [ Inject ]
        public void Create( )
        {
            Refresh( );
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable( )
        {
            BackButton.onClick.AddListener( OnBackButtonClick );
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDisable( )
        {
            BackButton.onClick.RemoveListener( OnBackButtonClick );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnBackButtonClick( ) => OnBack.Invoke( );

        /// <summary>
        /// 
        /// </summary>
        protected override void Refresh( )
        {
            var sceneManagementModel = Context.ModelLocator.GetItem< SceneManagementModel >( );
            var activeScene = sceneManagementModel.ActiveScene;
            
            StatusLabel.text = activeScene.name;
            BackButton.interactable = ! activeScene.name.Equals( SceneNames.Scene01_Menu );
        }
    }
}