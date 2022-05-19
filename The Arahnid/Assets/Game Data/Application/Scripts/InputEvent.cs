using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputEvent : MonoBehaviour
{
    public bool IsPressed { get; protected set; }

    [SerializeField] private InputActionProperty Action;
    [SerializeField] protected bool IsEnabled = true;

    protected virtual void InputAct(InputAction.CallbackContext callback)
    {
        if (IsEnabled == true)
            IsPressed = callback.ReadValueAsButton();
        else Debug.Log("Action is disabled");
    }

    protected virtual void OnEnable()
    {
        Action.action.performed += InputAct;
        Action.action.canceled += InputAct;
    }

    protected virtual void OnDisable()
    {
        Action.action.performed -= InputAct;
        Action.action.canceled -= InputAct;
    }
}
