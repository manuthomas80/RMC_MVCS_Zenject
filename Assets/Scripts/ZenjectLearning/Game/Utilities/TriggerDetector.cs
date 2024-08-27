using System;
using UnityEngine;
using UnityEngine.Events;

namespace ZenjectLearning
{
    public class TriggerDetector : MonoBehaviour
    {
        public Event OnTriggerEnterEvent { get; private set; } = new ( );
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter( Collider other )
        {
            OnTriggerEnterEvent.Invoke( other.gameObject );
        }

        /// <summary>
        /// 
        /// </summary>
        public class Event : UnityEvent< GameObject >
        {
            
        }
    }
}