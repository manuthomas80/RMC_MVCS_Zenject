﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC.Locator
{

    /// <summary>
    /// Locator base class providing utility methods for type hierarchy and disposal.
    /// </summary>
    public class Locator : IDisposable
    {
        /// <summary>
        /// Gets the most specific type of a given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetLowestType( Type type )
        {
            return GetTypeHierarchy( type ).LastOrDefault( );
        }

        /// <summary>
        /// Gets the type hierarchy of a given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type[ ] GetTypeHierarchy( Type type )
        {
            var hierarchy = new List< Type >( );

            while( type != null )
            {
                hierarchy.Insert( 0, type );  // Insert at the beginning to maintain order
                type = type.BaseType;
            }

            return hierarchy.ToArray( );
        }

        /// <summary>
        /// Disposes of the locator.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Dispose( )
        {
            throw new NotImplementedException( );
        }
    }
}
