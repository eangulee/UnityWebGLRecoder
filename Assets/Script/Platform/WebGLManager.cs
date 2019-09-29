using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class WebGLManager : SingletonMonoNewGO<WebGLManager>
{
    /// <summary>
    /// C#-->WebGLRecoder.jslib-->WebGLRecoder.js
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
     [DllImport(@"__Internal")]
    public static extern int WebGLIsLogin();
    [DllImport(@"__Internal")]
    public static extern void WebGLLogin();
    [DllImport(@"__Internal")]
    public static extern string WebGLGetStudentName();
    [DllImport(@"__Internal")]
    public static extern string WebGLGetStudentNo();
    [DllImport(@"__Internal")]
    public static extern string WebGLGetServerHost();
    [DllImport(@"__Internal")]
    public static extern string WebGLGetFileServerHost();
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
    /// 停止录音
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

    public bool IsLogin()
    {
        Debug.Log("IsLogin");
#if UNITY_WEBGL && !UNITY_EDITOR
        return WebGLIsLogin() == 1;
#endif
        return false;
    }

    public void Login()
    {
        Debug.Log("login");
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLLogin();
#endif
    }

    public string GetStudentName()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return WebGLGetStudentName();
#endif
        return string.Empty;
    }

    public string GetStudentNo()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return WebGLGetStudentNo();
#endif
        return string.Empty;
    }

    public string GetServerHost()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return WebGLGetServerHost();
#endif
        return string.Empty;
    }

    public string GetFileServerHost()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
         return WebGLGetFileServerHost();
#endif
        return string.Empty;
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [MonoPInvokeCallback(typeof(Action))]
    public static void Callback()
    {
        Debug.Log("Callback called");
    }
#endif
}
