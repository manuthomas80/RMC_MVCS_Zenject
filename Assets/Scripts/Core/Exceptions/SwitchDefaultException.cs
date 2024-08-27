using System;

namespace ZenjectLearning.Core.Exceptions
{
    /// <summary>
    /// Thrown when unintended Switch Defaults is reached.
    ///
    /// This is more elegant than alternatives.
    ///
    /// Replaces Code. From...
    /// 
    ///     default:
    ///         #pragma warning disable 0162 //Unreachable code detected
    ///         throw new Exception("blah" + obj);
    ///         break;
    ///         #pragma warning restore 0162 //Unreachable code detected
    ///
    /// To...
    /// 
    ///     default:
    ///         SwitchDefaultException.Throw(authenticationKitState);
    ///         break;   
    /// </summary>
    public class SwitchDefaultException : Exception
    {
        public SwitchDefaultException( object value ) :
            base( $"Switch Default Exception for Case: '{value.ToString( )}'" )
        {
            
        }

        public static void Throw( object value )
        {
            throw new SwitchDefaultException( value );
        }
    }
}
