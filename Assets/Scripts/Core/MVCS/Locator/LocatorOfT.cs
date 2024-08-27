using System;
using System.Collections.Generic;
using ZenjectLearning.Core.Events;
using UnityEngine;

namespace MVC.Locator
{
    /// <summary>
    /// Locator class for managing items of type TBase.
    /// This class provides methods to add, retrieve, check for, and remove items in a type-safe manner.
    /// It ensures that items are stored and retrieved based on their most specific type.
    /// 
    /// Generally, you can use the public API methods directly (e.g., AddItem, GetItem, HasItem, RemoveItem).
    /// However, in cases where you need to work with a specific derived type, you will need to call RecastLocatorAs
    /// inline with the method you want. For example:
    /// 
    /// <code>
    /// var specificLocator = locator.RecastLocatorAs<DerivedType>();
    /// specificLocator.AddItem(derivedItem);
    /// </code>
    /// </summary>
    public class Locator< TBase > : Locator
    {
        public class LocatorItemUnityEvent : ZLEvent< TBase > { }
        public readonly LocatorItemUnityEvent OnItemAdded = new ( );
        public readonly LocatorItemUnityEvent OnItemRemoved = new ( );

        private readonly Dictionary< Type, Dictionary< string, TBase > > Items = new ( );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        /// <exception cref="Exception"></exception>
        public void AddItem( TBase item, string key = "" )
        {
            var type = GetLowestType( item.GetType( ) );
            if( ! Items.ContainsKey( type ) )
            {
                Items[ type ] = new Dictionary< string, TBase >( );
            }

            if( ! Items[ type ].ContainsKey( key ) )
            {
                Items[ type ][ key ] = item;
                OnItemAdded.Invoke( item );
            }
            else
            {
                if( string.IsNullOrEmpty( key ) )
                    throw new Exception($"{nameof(AddItem)} failed. Item of type '{type.Name}' already exists.");
                else
                    throw new Exception( $"{nameof(AddItem)} failed. Item of type '{type.Name}' with key '{key}' already exists.");
            }
        }

        /// <summary>
        /// Retrieves an item from the locator by its type and optional key.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem GetItem< TItem >( string key = "" ) where TItem : TBase
        {
            var type = GetLowestType( typeof( TItem ) );
            if( Items.ContainsKey( type ) && Items[ type ].ContainsKey( key ) )
            {
                return (TItem) Items[ type ][ key ];
            }

            return default;
        }

        /// <summary>
        /// Checks if an item of a specific type and key exists in the locator.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public bool HasItem< TItem >( string key = "" ) where TItem : TBase
        {
            return GetItem< TItem >( key ) != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="willDispose"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <exception cref="Exception"></exception>
        public void RemoveItem< TItem >( string key = "", bool willDispose = false ) where TItem : TBase
        {
            var type = GetLowestType( typeof( TItem ) );
            if( Items.ContainsKey( type ) && Items[ type ].ContainsKey( key ) )
            {
                var item = Items[ type ][ key ];
                Items[ type ].Remove( key );
                OnItemRemoved.Invoke( item );

                if( willDispose && item is IDisposable disposableItem )
                {
                    disposableItem.Dispose( );
                }
            }
            else
            {
                Debug.LogError( $"Item of type '{type.Name}' with key '{key}' not found." );
            }
        }

        /// <summary>
        /// Overload for automatically disposing
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        public void RemoveAndDisposeItem< TItem >( string key = "" ) where TItem : TBase, IDisposable
        {
            RemoveItem< TItem >( key, true );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        public void SafeRemoveAndDisposeItem< TItem >( string key = "" ) where TItem : TBase, IDisposable
        {
            if( HasItem< TItem >( ) ) RemoveItem< TItem >( key, true );
        }
        
        /// <summary>
        /// Creates a type-safe locator for items of type T.
        /// 
        /// Generally, you call the API methods directly. For example:
        /// <code>
        /// locator.AddItem(item);
        /// var retrievedItem = locator.GetItem&lt;TItem&gt;(key);
        /// </code>
        /// 
        /// However, in cases where you need to work with a specific derived type, you will need to call RecastLocatorAs
        /// inline with the method you want. For example:
        /// <code>
        /// var specificLocator = locator.RecastLocatorAs&lt;DerivedType&gt;();
        /// specificLocator.AddItem(derivedItem);
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Locator< T > RecastLocatorAs< T >( ) where T : class, TBase
        {
            var newLocator = new Locator< T >( );

            foreach( var item in GetAllItems( ) )
            {
                if( item is T castedItem )
                {
                    newLocator.AddItem( castedItem );
                }
                else
                {
                    //Keep logging
                    Debug.LogWarning($"Type mismatch detected: {item.GetType()} cannot be cast to {typeof(T)}");
                    return null;
                }
            }

            return newLocator;
        }

        /// <summary>
        /// Gets the count of items in the locator.
        /// </summary>
        /// <returns></returns>
        public int GetItemCount( ) => Items.Count;

        /// <summary>
        /// Gets all items in the locator.
        /// </summary>
        /// <returns></returns>
        public List< TBase > GetAllItems( )
        {
            var items = new List< TBase >( );
            foreach( var type in Items.Keys )
                foreach( var key in Items[ type ].Keys )
                    items.Add( Items[ type ][ key ] );
            
            return items;
        }
        
        /// <summary>
        /// Resets the locator, removing all items.
        /// </summary>
        public void Reset( ) => Items.Clear( );

        /// <summary>
        /// Disposes of the locator, clearing all items.
        /// </summary>
        public override void Dispose( ) => Reset( );
    }
}
