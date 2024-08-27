using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using ZenjectLearning.Core;
using ZenjectLearning.Core.Pool;
using ZenjectLearning.Game.Commands;

namespace ZenjectLearning.Game
{
    public class PickUp : ITransform, 
                          ICollectable, 
                          IConfigurable< PickUpConfig >
    {
        public class DeSpawnEvent : UnityEvent< PickUp >{ }
        public  readonly DeSpawnEvent OnDeSpawnEvent = new( );
        
        public  Transform Transform { get; }
        
        private readonly Pool _Pool;
        private readonly MeshRenderer Renderer;
        private readonly Rigidbody RB;
        private readonly Vector3 DefaultScale;
        private readonly ConfiguratorContext Context;
        
        private DateTime SpawnTime;
        private float StayDuration;
        private State _State = State.InActive;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="renderer"></param>
        /// <param name="pool"></param>
        /// <param name="context"></param>
        public PickUp( Transform t, MeshRenderer renderer, Pool pool, ConfiguratorContext context )
        {
            Transform = t;
            RB = Transform.GetComponent< Rigidbody >( );
            DefaultScale = t.localScale;
            Renderer = renderer;
            Context = context;
           _Pool = pool;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Collect( )
        {
            if( _State != State.Active ) return;
            
            Context.CommandManager.InvokeCommand( new PickUpCollectCommand( ) );
            Destroy( );   
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Destroy( )
        {
            if( _State != State.Active ) return;
            
           _Pool.Despawn( this );
            OnDeSpawnEvent.Invoke( this );
           _State = State.InActive;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update( DateTime currTime )
        {
            if( _State != State.Active ) return;
            if( ( currTime - SpawnTime ).TotalSeconds > StayDuration )
            {
                PunchDisappear( );
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void PunchDisappear( )
        {
           _State = State.Disappear;
            Transform.DOScale( 1.5f, 0.15f )
                     .SetEase( Ease.InSine )
                     .OnComplete( ( ) =>
                     {
                         Transform.DOScale( 0f, 0.25f )
                                  .SetEase( Ease.OutSine )
                                  .OnComplete( Destroy );
                     });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public void Configure( PickUpConfig config )
        {
            Transform.gameObject.name = $"PickUp_{config.ID}";
            //Debug.Log( $"Spawned pickup : {ID}" );
            
            Transform.position = config.Position;
            Transform.rotation = Quaternion.identity;
            Transform.localScale = DefaultScale;
            
            Renderer.material.color = config.Color;
            
            RB.velocity = Vector3.zero;
            RB.angularVelocity = Vector3.zero;
            
            StayDuration = config.StayDuration;
            SpawnTime = DateTime.Now;
           _State = State.Active;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public class Pool : ConfigurableTransformItemPool< PickUpConfig, PickUp >
        {
            
        }
        
        private enum State
        {
            Active, Disappear, InActive
        }
    }
}