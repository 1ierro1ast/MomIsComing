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

        //[Conditional("UNITY_EDITOR")]
        public static void Message(string body, Object context = null, [CallerMemberName] string member = "",
            [CallerFilePath] string path = "")
        {
            
            if (!DebuggerConfig.EnableDebugMessage)
                return;

#if !UNITY_EDITOR
            if (!DebuggerConfig.ShowMessagesInBuild)
                return;
#endif
            var file = Path.GetFileNameWithoutExtension(path);
            string methodPath = $"{file}.{member}";

            _builder.Clear();

            if (DebuggerConfig.FrameStamp || DebuggerConfig.TimeStamp || DebuggerConfig.DeviceCurrentTimeStamp)
            {
                _builder.Append($"<color={DebuggerConfig.DurationInfoColor}>[ </color> ");
            }

            if (DebuggerConfig.FrameStamp)
            {
                _builder.Append($"<color={DebuggerConfig.DurationInfoColor}>Frame: {Time.frameCount}. </color> ");
            }

            if (DebuggerConfig.TimeStamp)
            {
                _builder.Append($"<color={DebuggerConfig.DurationInfoColor}>App Time: {Time.realtimeSinceStartup}. </color> ");
            }
            if (DebuggerConfig.DeviceCurrentTimeStamp)
            {
                _builder.Append($"<color={DebuggerConfig.DurationInfoColor}>Device Time: {DateTime.Now}. </color> ");
            }

            if (DebuggerConfig.FrameStamp || DebuggerConfig.TimeStamp || DebuggerConfig.DeviceCurrentTimeStamp)
            { 
                _builder.Append($"<color={DebuggerConfig.DurationInfoColor}>]</color> ");
            }
            
            _builder.Append(
                context != null ? $"<b>{file}.{member} ({context.name}):</b> " : $"<b>{file}.{member}:</b> ");

            var contextColorMatches = DebuggerConfig.ContextFilters
                .Where(ctx => methodPath.StartsWith(ctx.ContextPath, StringComparison.OrdinalIgnoreCase));

            var styleByContext = contextColorMatches
                .OrderByDescending(ctx => ctx.ContextPath.Length)
                .FirstOrDefault();

            if (styleByContext != null && !styleByContext.Show)
            {
                return;
            }

            Color? finalColor = styleByContext != null 
                ? styleByContext.Color 
                : _config.BaseMessageColor;

            _builder
                .Append($"<color=#{ColorUtility.ToHtmlStringRGBA(finalColor.Value)}>")
                .Append(body)
                .Append("</color>");

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