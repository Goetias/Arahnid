using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSubscription : MonoBehaviour
{
    public static TimeSubscription Instance { get; private set; }

    public delegate void Subscription();
    public event Subscription OnPause;
    public event Subscription OnRun;


    private void Awake()
    {
        Instance = this;
    }

    public void Run()
    {
        OnRun.Invoke();
    }

    public void Stop()
    {
        OnPause.Invoke();
    }
}
