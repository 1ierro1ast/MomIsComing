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
        [SerializeField] private TextColor[] _textColors;
        
        public bool EnableDebugMessage => _enableDebugMessage;
        public bool ShowMessagesInBuild => _showMessagesInBuild;

        public bool FrameStamp => _frameStamp;

        public TextColor[] TextColors => _textColors;
    }
    
    [Serializable]
    public class TextColor
    {
        public string Text;
        public Color Color;
    }
}