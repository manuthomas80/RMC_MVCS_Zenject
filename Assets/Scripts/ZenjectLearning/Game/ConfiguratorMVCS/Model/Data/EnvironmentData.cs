using UnityEngine;

namespace ZenjectLearning.Game
{
    /// <summary>
    /// Defines the customizable characteristics for the <see cref="Environment" />
    /// </summary>
    [System.Serializable]
    public class EnvironmentData : System.IEquatable< EnvironmentData >
    {
        public Color FloorColor = Color.white;
        public Color BackgroundColor = Color.white;
        public Color DecorationColor = Color.white;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EnvironmentData FromRandomValues( )
        {
            var colors = CustomColorUtility.GetRandomColorsWithoutRepeat( 3 );
            return new EnvironmentData
            {
                FloorColor = colors[ 0 ],
                BackgroundColor = colors[ 1 ],
                DecorationColor = colors[ 2 ]
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EnvironmentData FromDefaultValues( )
        {
            var colors = CustomColorUtility.GetDefaultColorList( );
            return new EnvironmentData
            {
                FloorColor = colors[ 0 ],
                BackgroundColor = colors[ 1 ],
                DecorationColor = colors[ 2 ]
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals( EnvironmentData other )
        {
            if( other == null ) return false;
            return FloorColor.Equals( other.FloorColor ) &&
                   BackgroundColor.Equals( other.BackgroundColor );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals( object obj )
        {
            if( obj == null ) return false;
            if( ReferenceEquals( this, obj ) ) return true;
            if( obj.GetType( ) != this.GetType( ) ) return false;
            return Equals( obj as EnvironmentData );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode( )
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + FloorColor.GetHashCode( );
                hash = hash * 23 + BackgroundColor.GetHashCode( );
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==( EnvironmentData left, EnvironmentData right )
        {
            if( ReferenceEquals( left, null ) ) return ReferenceEquals( right, null );
            return left.Equals( right );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=( EnvironmentData left, EnvironmentData right )
        {
            return !( left == right );
        }
    }
}