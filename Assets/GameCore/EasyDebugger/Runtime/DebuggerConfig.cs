using System;
using UnityEngine;

namespace MomIsComing.Scripts.EasyDebugger.Runtime
{
    [CreateAssetMenu(menuName = "Create DebuggerConfig", fileName = "DebuggerConfig", order = 0)]
    public class DebuggerConfig : ScriptableObject
    {
        [SerializeField] private bool _enableDebugMessage = true;
        [SerializeField] private bool _showMessagesInBuild = false;
        [SerializeField] private bool _frameStamp;
        [SerializeField] private bool _timeStamp;
        [SerializeField] private bool _deviceCurrentTimeStamp;
        [SerializeField] private Color _durationInfoColor;
        [Space] 
        [SerializeField] private Color _baseMessageColor;

        public Color BaseMessageColor => _baseMessageColor;

        [SerializeField] private ContextFilter[] _contextFilters;
        
        public bool EnableDebugMessage => _enableDebugMessage;
        public bool ShowMessagesInBuild => _showMessagesInBuild;

        public bool FrameStamp => _frameStamp;

        public bool TimeStamp => _timeStamp;

        public bool DeviceCurrentTimeStamp => _deviceCurrentTimeStamp;

        public Color DurationInfoColor => _durationInfoColor;

        public ContextFilter[] ContextFilters => _contextFilters;
    }
    
    [Serializable]
    public class ContextFilter
    {
        public string ContextPath;
        public Color Color;
        public bool Show = true;
    }
}