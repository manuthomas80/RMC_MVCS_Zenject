using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ZenjectLearning.Game
{
    public class CustomizeEnvironmentView : FeatureViewBase
    {
        public readonly UnityEvent OnRandomizeEnvironmentColor = new ( );
        
        [ SerializeField ]
        public TextMeshProUGUI StatusLabel;
        [ SerializeField ]
        public Button RandomizeEnvironmentButton;
        
        private Environment Environment;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="env"></param>
        [ Inject ]
        public void Create( Environment env )
        {   
            Environment = env;
            Model.EnvData.OnValueChanged.AddListener( EnvironmentData_OnValueChanged );
            Refresh( );
            
            StatusLabel.text = $"Customize\nenvironment\ncolors";
        }
        
        /// <summary>
        ///
        /// </summary>
        private void OnDestroy( )
        {
            Model.EnvData.OnValueChanged.RemoveListener( EnvironmentData_OnValueChanged );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnEnable( )
        {
            RandomizeEnvironmentButton.onClick.AddListener( RandomizeEnvironmentColorButton_OnClicked );
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnDisable( )
        {
            RandomizeEnvironmentButton.onClick.RemoveListener( RandomizeEnvironmentColorButton_OnClicked );
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void Refresh( )
        {
            if( ! Service.IsConfiguratorServiceLoaded ) return;
            Environment.Data = Service.Data.EnvironmentData;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RandomizeEnvironmentColorButton_OnClicked( )
        {
            OnRandomizeEnvironmentColor?.Invoke( );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldvalue"></param>
        /// <param name="newvalue"></param>
        private void EnvironmentData_OnValueChanged( EnvironmentData oldvalue, EnvironmentData newvalue )
        {
            Environment.Data = newvalue;
        }
    }
}