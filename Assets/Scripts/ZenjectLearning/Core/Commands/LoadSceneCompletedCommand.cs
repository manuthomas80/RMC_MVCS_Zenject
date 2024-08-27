
namespace ZenjectLearning.Core.Commands
{
    /// <summary>
    /// The Command is a stand-alone object containing
    /// all arguments needed to perform a request
    /// </summary>
    public class LoadSceneCompletedCommand : ICommand
    {
        public string SceneName { get; private set; }
        public LoadSceneCompletedCommand( string sceneName )
        {
            SceneName = sceneName;
        }
    }
}