#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
namespace Microsoft.Mixer
{
    public enum LoggingLevel
    {
        None,

        Minimal,

        Verbose
    }
}
#endif