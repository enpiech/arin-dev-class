using UnityEngine;

/// <summary>
///     Singleton base class
/// </summary>
public class Singleton<T> where T : class, new()
{
    public static T Instance { get; } = new();
}

/// <summary>
///     Singleton for mono behavior object
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T singleton;

    public static bool IsAlive => singleton != null;

    public static T Instance
    {
        get
        {
            if (singleton == null)
            {
                singleton = (T)FindObjectOfType(typeof(T));
                if (singleton == null)
                {
                    var obj = new GameObject();
                    obj.name = "[@" + typeof(T).Name + "]";
                    singleton = obj.AddComponent<T>();
                }
            }

            return singleton;
        }
    }

    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }
}

/// <summary>
///     Singleton for mono behavior object
/// </summary>
/// <typeparam name="T"></typeparam>
public class ManualSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)(MonoBehaviour)this;
        }
    }

    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }

    protected void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}