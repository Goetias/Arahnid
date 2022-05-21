using System;

public class GameState
{
    public static GameState Instance { get; private set; }

    public event Action OnPause;
    public event Action OnRun;
   
    public GameState(out Action playEvent, out Action pauseEvent)
    {
        playEvent = Play;
        pauseEvent = Pause;

        Instance = this;
    }

    private void Play()
    {
        OnRun?.Invoke();
    }

    private void Pause()
    {
        OnPause?.Invoke();
    }
}