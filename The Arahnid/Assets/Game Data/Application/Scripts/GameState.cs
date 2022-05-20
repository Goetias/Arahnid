using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public delegate void Subscriptions();
    public event Subscriptions OnPause;
    public event Subscriptions OnRun;


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


public class Game
{
    public static Game Instance { get; private set; }

    public delegate void Subscriptions();
    public event Subscriptions OnPause;
    public event Subscriptions OnRun;

    public Game(Subscriptions playEvent, Subscriptions pauseEvent)
    {
        playEvent += Play;
        pauseEvent += Pause;

        Instance = this;
    }

    private void Play()
    {
        OnRun?.Invoke();
    }

    private void Pause()
    {
        OnRun?.Invoke();
    }
}