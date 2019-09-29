using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class WebGLManager : SingletonMonoNewGO<WebGLManager>
{
    /// <summary>
    /// C#-->WebGLRecoder.jslib-->WebGLRecoder.js(index.html <script src="js/WebGLRecoder.js"></script>)
    /// </summary>
    /// <param name="fileName"></param>
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport(@"__Internal")]
    public static extern void WebGLScreenShot(string fileName);
    [DllImport(@"__Internal")]
    public static extern void WebGLStartRecording();
    [DllImport(@"__Internal")]
    public static extern void WebGLStopRecording(Action callback);
    [DllImport(@"__Internal")]
    public static extern void WebGLRecordDownload(string fileName); 
#endif
    public void ScreenShot(string fileName)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLScreenShot(fileName);
#endif
    }

    public void StartRecording()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLStartRecording();
#endif
    }

    /// <summary>
    /// 停止录屏
    /// </summary>
    /// <param name="callback">该回调一定是静态方法</param>
    public void StopRecording(Action callback)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLStopRecording(callback);
#endif
    }

    public void RecordDownload(string fileName)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLRecordDownload(fileName);
#endif
    }
}
