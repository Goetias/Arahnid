using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayUI : MonoBehaviour, ITimeService
{
    [SerializeField] private PlayerStateInfo PlayerInfo;
    [SerializeField] private InputActionProperty ActionInventory;
    [SerializeField] private UIPanel OpenPanel;

    private bool _isPressed = false;
    private bool _isEnable = true;

    private void Start()
    {
        Subscribe();
    }

    public void Display()
    {
        if (_isEnable == true)
        {
            Press();
        }
        else Debug.Log("Time stop!");
    }

    private void Press()
    {
        _isPressed = !_isPressed;

        if (_isPressed == true)
            OpenPanel.Show();
        else OpenPanel.Hide();

        UIBackGround.Instance.Activation(!_isPressed);
        CursorState.Instance.SetState(_isPressed);

        PlayerInfo.SwapTime();
    }

    public void Stop()
    {
        if (_isPressed == false)
            _isEnable = false;
    }

    public void Run()
    {
        _isEnable = true;
    }

    public void Subscribe()
    {
        TimeSubscription.Instance.OnPause += Stop;
        TimeSubscription.Instance.OnRun += Run;
    }

    private void OnEnable()
    {
        ActionInventory.action.started += T => Display();
    }

    private void OnDisable()
    {
        ActionInventory.action.started -= T => Display();
    }
}
