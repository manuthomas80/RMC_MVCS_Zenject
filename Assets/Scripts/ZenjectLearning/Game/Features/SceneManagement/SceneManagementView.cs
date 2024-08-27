using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using ZenjectLearning.MVCS.Concerns;

namespace ZenjectLearning.Game.Feature
{
    public class SceneManagementView : MonoBehaviour, IView
    {
        public readonly UnityEvent OnBack = new ( );
        
        private ConfiguratorContext Context;
        
        [ SerializeField ]
        private float TransitionDuration = 0.25f;
        [ SerializeField ]
        private GameObject Mask;
        [ SerializeField ]
        private Image MaskImage;

        /// <summary>
        /// 
        /// </summary>
        private void Awake( ) => SetMask( false );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [ Inject ]
        public void Create( ConfiguratorContext context )
        {
            Context = context;
            SetMask( false );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fadeInCompleteAction"></param>
        /// <param name="fadeOutCompleteAction"></param>
        public void FadeInOut( Action fadeInCompleteAction, Action fadeOutCompleteAction )
        {
            FadeIn( ( )=>
            {
                fadeInCompleteAction?.Invoke( );
                FadeOut( fadeOutCompleteAction );
            } );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onComplete"></param>
        public void FadeIn( Action onComplete )
        {
            SetMask( true );
            MaskImage.DOFade( 1f, TransitionDuration / 2f ).From( 0f ).OnComplete( ( ) => onComplete?.Invoke( ) );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onComplete"></param>
        public void FadeOut( Action onComplete )
        {
            MaskImage.DOFade( 0f, TransitionDuration / 2f )
                     .From( MaskImage.color.a )
                     .OnComplete( ( ) =>
                     {
                         SetMask( false );
                         onComplete?.Invoke( );
                     });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOn"></param>
        private void SetMask( bool isOn ) => Mask.SetActive( isOn );
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose( ) { }
    }
}