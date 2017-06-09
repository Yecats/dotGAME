using System.Collections.Generic;

internal class MixerInteractiveHelper
{

    internal bool runInBackgroundIfInteractive = true;
    internal string defaultSceneID;
    internal Dictionary<string, string> groupSceneMapping = new Dictionary<string, string>();

    private static MixerInteractiveHelper _singletonInstance;
    internal static MixerInteractiveHelper SingletonInstance
    {
        get
        {
            if (_singletonInstance == null)
            {
                _singletonInstance = new MixerInteractiveHelper();
            }
            return _singletonInstance;
        }
    }
}
