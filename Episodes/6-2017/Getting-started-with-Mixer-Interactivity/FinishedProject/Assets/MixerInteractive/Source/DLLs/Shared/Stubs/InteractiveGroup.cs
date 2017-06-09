#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;
using System.Collections.Generic;

namespace Microsoft.Mixer
{
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveGroup
    {
        public string GroupID
        {
            get;
            private set;
        }

        public List<InteractiveParticipant> Participants
        {
            get
            {
                return new List<InteractiveParticipant>();
            }
        }

        public string SceneID
        {
            get;
            private set;
        }

        public void SetScene(string sceneID)
        {
        }

        internal string etag;

        public InteractiveGroup(string groupID)
        {
        }

        public InteractiveGroup(string groupID, string sceneID)
        {
        }

        internal InteractiveGroup(string newEtag, string sceneID, string groupID)
        {
        }
    }
}
#endif