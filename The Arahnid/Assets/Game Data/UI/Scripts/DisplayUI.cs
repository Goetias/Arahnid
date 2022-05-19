using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] private InputActionProperty ActionInventory;
    [SerializeField] private UIPanel OpenPanel;

    public delegate void SelfFollowing();
    public static event SelfFollowing OnOpen;
    public static event SelfFollowing OnClose;

    private bool _isPressed = false;
    private bool _isEnable = true;

    public void Display()
    {
        if (_isEnable == true)
        {
            _isPressed = !_isPressed;

            if (_isPressed == true)
                OpenPanel.Show();
            else OpenPanel.Hide();

            UIBackGround.Instance.Activation(!_isPressed);
            CursorState.Instance.SetState(_isPressed);
            TimeScale.Instance.SetState(!_isPressed);

            if (_isPressed == true)
                OnOpen?.Invoke();
            else OnClose?.Invoke();
        }
        else Debug.Log("The another menu is open");
    }

    private void OnEnable()
    {
        ActionInventory.action.started += T => Display();

        OnOpen += CloseOther;
        OnClose += OpenOther;
    }

    private void OnDisable()
    {
        ActionInventory.action.started -= T => Display();

        OnOpen -= CloseOther;
        OnClose -= OpenOther;
    }

    private void CloseOther()
    {
        if (_isPressed == false)
            this._isEnable = false;
    }

    private void OpenOther()
    {
        if (this._isEnable == false)
            this._isEnable = true;
    }
}
