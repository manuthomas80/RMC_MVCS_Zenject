using UnityEngine;

namespace ZenjectLearning.Game
{
    public class DontDestroyOnSceneUnload : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            DontDestroyOnLoad( gameObject );
        }
    }
}