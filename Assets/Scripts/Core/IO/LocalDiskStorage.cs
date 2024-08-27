using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using ZenjectLearning.Core.Attributes;

#pragma warning disable CS0414
namespace ZenjectLearning.Core.IO
{
    public sealed class LocalDiskStorage
    {
        public const string Title = "LocalDiskStorage";

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDiskStorage"/> class.
        /// Avoids using constructor for initialization logic.
        /// </summary>
        public LocalDiskStorage()
        {
            // Avoid using constructor for initialization
        }

        /// <summary>
        /// Saves an object to disk with an option to overwrite.
        /// </summary>
        /// <typeparam name="T">The type of the object to save.</typeparam>
        /// <param name="obj">The object to be saved.</param>
        /// <returns>True if the save was successful, false otherwise.</returns>
        public bool Save< T >( T obj )
        {
            return Save< T >( obj, true );
        }

        /// <summary>
        /// Saves an object to disk with an option to overwrite.
        /// </summary>
        /// <typeparam name="T">The type of the object to save.</typeparam>
        /// <param name="obj">The object to be saved.</param>
        /// <param name="willOverwrite">Whether to overwrite the file if it already exists.</param>
        /// <returns>True if the save was successful, false otherwise.</returns>
        public bool Save< T >( T obj, bool willOverwrite )
        {
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe< T >();
            CreateDirectorySafe( customFilePathAttribute.Filepath );
            string json = JsonUtility.ToJson( obj, true );
            bool isSuccess = false;

            if( !willOverwrite && File.Exists( customFilePathAttribute.Filepath ) )
            {
                Debug.LogWarning( $"LocalDiskStorage.Save() failed. File already exists and willOverwrite = {willOverwrite}." );
            }
            else
            {
                File.WriteAllText( customFilePathAttribute.Filepath, json );
                isSuccess = !string.IsNullOrEmpty( json );

#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif // UNITY_EDITOR
            }

            return isSuccess;
        }

        /// <summary>
        /// Deletes the file associated with the specified object type from disk.
        /// </summary>
        /// <typeparam name="T">The type of the object whose file is to be deleted.</typeparam>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        public bool Delete< T >()
        {
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe< T >();
            bool isSuccess = false;
            string[] paths = new[]
            {
                customFilePathAttribute.Filepath,
                customFilePathAttribute.Filepath + ".meta"
            };

            for( int i = 0; i < paths.Length; i++ )
            {
                if( File.Exists( paths[ i ] ) )
                {
                    File.Delete( paths[ i ] );
                    isSuccess = true;
                }
                else
                {
                    Debug.LogWarning( $"LocalDiskStorage.Delete() failed. File must already exist. Path={paths[ i ]}" );
                }
            }

            if( isSuccess )
            {
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif // UNITY_EDITOR
            }

            return isSuccess;
        }

        /// <summary>
        /// Checks if a file for the specified object type exists on disk.
        /// </summary>
        /// <typeparam name="T">The type of the object to check for.</typeparam>
        /// <returns>True if the file exists, false otherwise.</returns>
        public bool Has< T >()
        {
            return LoadWithoutValidation< T >() != null;
        }

        /// <summary>
        /// Loads an object of the specified type from disk.
        /// </summary>
        /// <typeparam name="T">The type of the object to load.</typeparam>
        /// <returns>The loaded object, or throws an exception if not found.</returns>
        public T Load< T >()
        {
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe< T >();

            if( string.IsNullOrEmpty( customFilePathAttribute.Filepath ) )
            {
                throw new Exception( $"LocalDiskStorage.Load() failed. [CustomFilePathAttribute (Filepath = {customFilePathAttribute.Filepath})] is invalid for {typeof( T ).Name}." );
            }

            if( !File.Exists( customFilePathAttribute.Filepath ) )
            {
                throw new Exception( $"LocalDiskStorage.Load() failed. Call LocalDiskStorage.Has< T >() beforehand." );
            }

            return LoadWithoutValidation< T >();
        }

        /// <summary>
        /// Loads an object of the specified type from disk without validation.
        /// </summary>
        /// <typeparam name="T">The type of the object to load.</typeparam>
        /// <returns>The loaded object, or null if not found.</returns>
        private T LoadWithoutValidation< T >()
        {
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe< T >();
            if( !File.Exists( customFilePathAttribute.Filepath ) )
            {
                return default( T );
            }
            string json = File.ReadAllText( customFilePathAttribute.Filepath );
            return JsonUtility.FromJson< T >( json );
        }

        /// <summary>
        /// Retrieves the <see cref="CustomFilePathAttribute"/> for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to get the custom file path attribute for.</typeparam>
        /// <returns>The custom file path attribute associated with the object type.</returns>
        private CustomFilePathAttribute GetCustomFilePathAttributeSafe< T >()
        {
            CustomFilePathAttribute customFilePathAttribute = CustomFilePathAttribute.GetCustomFilePathAttribute< T >();
            if( customFilePathAttribute == null )
            {
                throw new Exception( $"LocalDiskStorage method failed. Add [CustomFilePathAttribute] to {typeof( T ).Name}." );
            }

            return customFilePathAttribute;
        }

        /// <summary>
        /// Creates the directory specified by the given file path if it does not already exist.
        /// </summary>
        /// <param name="filepath">The file path for which to create the directory.</param>
        private void CreateDirectorySafe( string filepath )
        {
            string directoryPath = Path.GetDirectoryName( filepath );
            if( !Directory.Exists( directoryPath ) )
            {
                Directory.CreateDirectory( directoryPath );
            }
        }
    }
}
