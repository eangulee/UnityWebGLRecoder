using System;
using UnityEngine;
/// <summary>
/// 常规单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonPersistent<T> where T : new()
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
}

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        protected set
        {
            if (_instance)
                throw new Exception(typeof(T).Name + " must be singleton!");
            _instance = value;
        }
        get
        {
            return _instance;
        }
    }
}

public class SingletonMonoNewGO<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("_" + typeof(T).Name);
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }
    }
}
