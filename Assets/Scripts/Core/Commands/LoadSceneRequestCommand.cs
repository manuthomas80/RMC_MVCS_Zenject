namespace ZenjectLearning.Core.Commands
{
    /// <summary>
    /// The Command is a stand-alone object containing
    /// all arguments needed to perform a request
    /// </summary>
    public class LoadSceneRequestCommand : ICommand
    {
        public string SceneName { get; private set; }
        public LoadSceneRequestCommand( string sceneName )
        {
            SceneName = sceneName;
        }
    }
}