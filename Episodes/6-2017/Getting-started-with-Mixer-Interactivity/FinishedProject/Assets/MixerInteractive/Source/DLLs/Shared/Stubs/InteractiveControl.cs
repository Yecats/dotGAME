#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
namespace Microsoft.Mixer
{
    public class InteractiveControl
    {
        public string ControlID
        {
            get;
            private set;
        }

        public bool Disabled
        {
            get;
            private set;
        }

        public string HelpText
        {
            get;
            private set;
        }

        internal string ETag;
        internal string SceneID;

        public void SetDisabled(bool disabled)
        {
        }

        internal InteractiveControl(string controlID, bool disabled, string helpText, string eTag, string sceneID)
        {
        }
    }
}
#endif