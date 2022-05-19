using UnityEngine;

public class PlayerStateInfo : MonoBehaviour, ITimeHandle
{
    public bool IsTimeRunning { get; protected set; }

    private void Awake()
    {
        IsTimeRunning = true;
    }

    public void RunTime()
    {
        TimeSubscription.Instance.Run();
    }

    public void StopTime()
    {
        TimeSubscription.Instance.Stop();
    }

    public void SwapTime()
    {
        IsTimeRunning = !IsTimeRunning;

        if (IsTimeRunning == true)
            RunTime();
        else StopTime();
    }


}
