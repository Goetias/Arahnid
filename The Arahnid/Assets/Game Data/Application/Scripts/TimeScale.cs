using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public static TimeScale Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        Play();
    }

    public void Stop()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void SetState(bool isTimeScale)
    {
        if (isTimeScale == true)
            Time.timeScale = 1;
        else Time.timeScale = 0;
    }
}
