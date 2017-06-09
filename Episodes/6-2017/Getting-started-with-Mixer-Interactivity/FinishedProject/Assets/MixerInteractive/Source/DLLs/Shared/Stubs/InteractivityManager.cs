#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;
using System.Collections.Generic;

namespace Microsoft.Mixer
{
    public partial class InteractivityManager : IDisposable
    {
        // Events
        public delegate void OnErrorEventHandler(object sender, InteractiveEventArgs e);
        public event OnErrorEventHandler OnError;

        // Just one state changed event. OnInteractivityStateChanged. Get rid of the other events.
        public delegate void OnInteractivityStateChangedHandler(object sender, InteractivityStateChangedEventArgs e);
        public event OnInteractivityStateChangedHandler OnInteractivityStateChanged;

        public delegate void OnParticipantStateChangedHandler(object sender, InteractiveParticipantStateChangedEventArgs e);
        public event OnParticipantStateChangedHandler OnParticipantStateChanged;

        public delegate void OnInteractiveButtonEventHandler(object sender, InteractiveButtonEventArgs e);
        public event OnInteractiveButtonEventHandler OnInteractiveButtonEvent;

        public delegate void OnInteractiveJoystickControlEventHandler(object sender, InteractiveJoystickEventArgs e);
        public event OnInteractiveJoystickControlEventHandler OnInteractiveJoystickControlEvent;

        private static InteractivityManager _singletonInstance;

        /// <summary>
        /// Gets the singleton instance of InteractivityManager.
        /// </summary>
        public static InteractivityManager SingletonInstance
        {
            get
            {
                if (_singletonInstance == null)
                {
                    _singletonInstance = new InteractivityManager();
                }
                return _singletonInstance;
            }
        }

        public LoggingLevel LoggingLevel
        {
            get;
            set;
        }

        public InteractivityState InteractivityState
        {
            get;
            private set;
        }

        public IList<InteractiveGroup> Groups
        {
            get;
            private set;
        }

        public IList<InteractiveScene> Scenes
        {
            get;
            private set;
        }

        public IList<InteractiveParticipant> Participants
        {
            get;
            private set;
        }

        public IList<InteractiveButtonControl> Buttons
        {
            get;
            private set;
        }

        public IList<InteractiveJoystickControl> Joysticks
        {
            get;
            private set;
        }

        public string ShortCode
        {
            get;
            private set;
        }

        public InteractiveGroup GetGroup(string groupID)
        {
            return null;
        }

        public InteractiveScene GetScene(string sceneID)
        {
            return null;
        }

        public void Initialize(bool goInteractive = true)
        {
        }

        public void TriggerCooldown(string controlID, int cooldown)
        {
        }

        public void StartInteractive()
        {
        }

        public void StopInteractive()
        {
        }

        public void DoWork()
        {
        }

        public void Dispose()
        {
        }

        public void SendMockWebSocketMessage(string rawText)
        {
        }

        public InteractiveButtonControl GetButton(string controlID)
        {
            return new InteractiveButtonControl(controlID, false, string.Empty, string.Empty, string.Empty);
        }

        public InteractiveJoystickControl GetJoystick(string controlID)
        {
            return new InteractiveJoystickControl(controlID, true, "", "", "");
        }

        public string GetCurrentScene()
        {
            return "";
        }

        public void SetCurrentScene(string sceneID)
        {
        }

        // For MockData
        public static bool useMockData = false;
    }
}
#endif