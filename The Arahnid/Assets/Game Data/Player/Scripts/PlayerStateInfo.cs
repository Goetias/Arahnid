using System;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour, ITimeHandle
{
    public bool IsTimeRunning { get; protected set; }
    private event Action play;
    private event Action pause;


    private void Awake()
    {
        IsTimeRunning = true;

        new GameState(out play, out pause);
    }

    public void RunTime()
    {
        IsTimeRunning = true;
        play?.Invoke();
    }

    public void StopTime()
    {
        IsTimeRunning = false;
        pause?.Invoke();
    }

    public void SwapTime()
    {
        IsTimeRunning = !IsTimeRunning;

        if (IsTimeRunning == true)
            RunTime();
        else
            StopTime();
    }
}
