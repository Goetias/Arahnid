using System;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour, ITimeHandle
{
    public bool IsTimeRunning { get; protected set; }
    Game.Subscriptions play = null;
    Game.Subscriptions pause = null;

    event Action test;

    private void Awake()
    {
        IsTimeRunning = true;

        Game game = new Game(play, pause);
    }

    public void RunTime()
    {
        GameState.Instance.Run();
        IsTimeRunning = true;

        play?.Invoke();
    }

    public void StopTime()
    {
        GameState.Instance.Stop();
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
