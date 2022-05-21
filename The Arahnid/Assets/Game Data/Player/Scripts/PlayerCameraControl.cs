using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour, ITimeService
{
    [SerializeField] private Transform PlayerHead;
    [SerializeField] private InputActionProperty Action;
    [SerializeField] private float MouseSensivity;
    [SerializeField] private float SpeedBodyTurn;

    private Vector3 _headRotation;
    private Vector3 _bodyRotation;
    private bool _isEnabled = true;

    private Vector3 DetectMouse(InputAction.CallbackContext callback)
    {
        Vector2 mouseDelta = callback.ReadValue<Vector2>();

        Vector3 mouseConvertDelta;
        mouseConvertDelta.x = -1 * mouseDelta.y;
        mouseConvertDelta.y = mouseDelta.x;
        mouseConvertDelta.z = 0;

        return mouseConvertDelta;
    }

    private void TurnCamera(InputAction.CallbackContext callback)
    {
        if (_isEnabled == true)
        {
            Vector3 currentRotation = DetectMouse(callback) * MouseSensivity * Time.deltaTime;

            _headRotation += currentRotation;
            _bodyRotation += currentRotation;

            _headRotation = new Vector3(Mathf.Clamp(_headRotation.x, -45, 25), 0, 0);
            _bodyRotation = new Vector3(0, _bodyRotation.y, 0);

            PlayerHead.localRotation = Quaternion.Slerp(PlayerHead.localRotation, Quaternion.Euler(_headRotation), 1);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_bodyRotation), SpeedBodyTurn * Time.deltaTime);
        }
        else Debug.Log("Time is stopped!");
    }

    private void Start()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void OnEnable()
    {
        Action.action.performed += TurnCamera;
        Action.action.canceled += TurnCamera;
    }

    private void OnDisable()
    {
        Action.action.performed -= TurnCamera;
        Action.action.canceled -= TurnCamera;
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
