using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : InputAnimation, ITimeService
{
    [SerializeField] private List<MovementExpension> MovingExpension;
    [SerializeField] protected float Speed;

    private CharacterController _characterController;
    private Vector3 _direction;

    private void Update()
    {
        if (_isEnabled == true)
        {

            _direction = PlayerGravity.Instance.HandleGravity(_direction);

            if (IsPressed == true)
            {
                foreach (MovementExpension expension in MovingExpension)
                {
                    if (expension.IsPressed == true)
                    {
                        Move(expension.GetSpeed());
                        return;
                    }
                }

                Move(Speed);
            }
        }
        else Debug.Log("Time is stopped!");
    }

    public void Move(float speed)
    {
        _characterController.Move(transform.TransformDirection(_direction * speed) * Time.deltaTime);
    }

    protected override void InputAct(InputAction.CallbackContext callback)
    {
        if (_isEnabled == true)
        {
            Vector2 currentMovementInput = callback.ReadValue<Vector2>();
            IsPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

            _direction.x = currentMovementInput.x;
            _direction.z = currentMovementInput.y;
        }
        else
        {
            IsPressed = false;
            Debug.Log("Movement is disabled!");
        }
    }

    protected override void Start()
    {
        _nameAnim = "isWalking";
        _characterController = GetComponent<CharacterController>();
        base.Start();

        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    public void Pause()
    {
        _isEnabled = false;
    }

    public void Play()
    {
        _isEnabled = true;
    }

    public void Subscribe()
    {
        GameState.Instance.OnPause += Pause;
        GameState.Instance.OnRun += Play;
    }

    public void Unsubscribe()
    {
        GameState.Instance.OnPause -= Pause;
        GameState.Instance.OnRun -= Play;
    }
}
