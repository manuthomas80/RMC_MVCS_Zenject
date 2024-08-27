using System;
using UnityEngine;
using ZenjectLearning.Core.Exceptions;

namespace ZenjectLearning.Core.Attributes
{
    /// <summary>
    /// Determines root of relative pathing 
    /// </summary>
    public enum CustomFilePathLocation
    {
        PersistentDataPath,
        StreamingAssetsPath
    }
    
    /// <summary>
    /// Used to add relative paths to objects. 
    /// </summary>
    [ AttributeUsage( AttributeTargets.Class ) ]
    public class CustomFilePathAttribute : Attribute
    {
        public string Filepath { get { return filepath; } }
        public CustomFilePathLocation Location { get { return m_Location; } }

        private string filepath
        {
            get
            {
                if( m_FilePath == null && m_RelativePath != null )
                {
                    m_FilePath = CombineFilePath( m_RelativePath, m_Location );
                    m_RelativePath = (string) null;
                }

                return m_FilePath;
            }
        }
        
        private string m_FilePath;
        private string m_RelativePath;
        private CustomFilePathLocation m_Location;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="location"></param>
        /// <exception cref="ArgumentException"></exception>
        public CustomFilePathAttribute( string relativePath, CustomFilePathLocation location )
        {
            m_RelativePath = !string.IsNullOrEmpty( relativePath )
                ? relativePath
                : throw new ArgumentException( "Invalid relative path (it is empty)" );
            m_Location = location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        /// <exception cref="SwitchDefaultException"></exception>
        private static string CombineFilePath( string relativePath, CustomFilePathLocation location )
        {
            if( relativePath[ 0 ] == '/' )
                relativePath = relativePath.Substring( 1 );
            switch( location )
            {
                case CustomFilePathLocation.PersistentDataPath:
                    return Application.persistentDataPath + "/" + relativePath;
                case CustomFilePathLocation.StreamingAssetsPath:
                    return Application.streamingAssetsPath + "/" + relativePath;
                default:
                    throw new SwitchDefaultException( location );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static CustomFilePathAttribute GetCustomFilePathAttribute< T >( )
        {
            foreach( var customAttribute in typeof( T ).GetCustomAttributes( true ) )
            {
                var customFilePathAttribute = customAttribute as CustomFilePathAttribute;
                if( customFilePathAttribute != null )
                    return customFilePathAttribute;
            }

            return null;
        }
    }
}
