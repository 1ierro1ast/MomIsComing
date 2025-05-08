using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace MomIsComing.Scripts.EasyDebugger.Runtime
{
    [Serializable]
    public static class Debugger
    {
        private static StringBuilder _builder = new();
        private static DebuggerConfig _config;
        
        public static DebuggerConfig DebuggerConfig
        {
            get
            {
                _config ??= Resources.Load<DebuggerConfig>(nameof(DebuggerConfig));
                return _config;
            }
        }

        [Conditional("UNITY_EDITOR")]
        public static void Message(string body, Object context = null, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            var style = DebuggerConfig.TextColors
                .FirstOrDefault(textColor => body.Contains(textColor.Text));
            var file = Path.GetFileNameWithoutExtension(path);

            _builder.Clear();
            
            if (DebuggerConfig.FrameStamp) _builder.Append($"<color=white>{Time.frameCount}.</color> ");

            _builder.Append(
                context != null ? 
                    $"<b>{file}.{member} ({context.name}):</b> " : 
                    $"<b>{file}.{member}:</b> ");

            if (style != null) 
                _builder
                    .Append($"<color=#{ColorUtility.ToHtmlStringRGBA(style.Color)}>")
                    .Append(body)
                    .Append("</color>");
            else 
                _builder.Append(body);

            Debug.Log(_builder.ToString(), context);
        }

        public static void Log(object message)
        {
            if (!DebuggerConfig.EnableDebugMessage) return;
#if UNITY_EDITOR
            Debug.Log(message);
#else
            if (DebuggerConfig.ShowMessagesInBuild)
            {
                Debug.Log(message);
            }
#endif
        }

        public static void LogWarning(object message)
        {
            if (!DebuggerConfig.EnableDebugMessage) return;
#if UNITY_EDITOR
            Debug.LogWarning(message);
#else
            if (DebuggerConfig.ShowMessagesInBuild)
            {
                Debug.LogWarning(message);
            }
#endif
        }
    }
    
    
}