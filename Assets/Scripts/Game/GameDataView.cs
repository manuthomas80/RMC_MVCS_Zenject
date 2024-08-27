using TMPro;
using UnityEngine;
using Zenject;

namespace ZenjectLearning.Game
{
    public class GameDataView : MonoBehaviour
    {
        [ SerializeField ]
        private TextMeshProUGUI PickUpsCountText;
        private GameData Data;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        [ Inject ]
        public void Create( GameData data )
        {
            Data = data;
            Data.PickUpsCollected.OnValueChanged.AddListener( OnPickUpsCountChange );
            RefreshPickUpCount( );
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDestroy( )
        {
            Data?.PickUpsCollected.OnValueChanged.RemoveListener( OnPickUpsCountChange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldvalue"></param>
        /// <param name="newvalue"></param>
        private void OnPickUpsCountChange( int oldvalue, int newvalue ) => RefreshPickUpCount( );
        
        /// <summary>
        /// 
        /// </summary>
        private void RefreshPickUpCount( )
        {
            PickUpsCountText.text = $"Pick ups collected : {Data.PickUpsCollected.Value}";
        }
    }
}