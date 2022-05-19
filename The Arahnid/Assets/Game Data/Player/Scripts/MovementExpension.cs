using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MovementExpension : InputAnimation
{
    [SerializeField] protected float Speed;

    public virtual float GetSpeed()
    {
        return Speed;
    }

    protected override void InputAct(InputAction.CallbackContext callback)
    {
        if (IsEnabled == true)
        {
            IsPressed = callback.ReadValueAsButton();
        }
        else
        {
            IsPressed = false;
            Debug.Log("Action is disabled!");
        }
    }
}
