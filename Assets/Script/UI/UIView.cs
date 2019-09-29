using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public static string fileName = "demo";
    // Start is called before the first frame update
    void Start()
    {

    }

    //开始录制视频
    public void StartRecoding()
    {
        WebGLManager.instance.StartRecording();
    }

    //停止录制视频
    public void StopRecording()
    {
        WebGLManager.instance.StopRecording(Callback);
    }

    //拍照截图
    public void PhotoGraph()
    {
        System.DateTime now = new System.DateTime();
        now = System.DateTime.Now;
        string filename = string.Format("{0}_{1}{2}{3}{4}.png", fileName, now.Day, now.Hour, now.Minute, now.Second);
        WebGLManager.instance.ScreenShot(filename);
    }

    [MonoPInvokeCallback(typeof(Action))]
    public static void Callback()
    {
        Debug.Log("StopRecording");
        System.DateTime now = new System.DateTime();
        now = System.DateTime.Now;
        string filename = string.Format("{0}_{1}{2}{3}{4}.webm", fileName, now.Day, now.Hour, now.Minute, now.Second);
        WebGLManager.instance.RecordDownload(filename);
    }
}
