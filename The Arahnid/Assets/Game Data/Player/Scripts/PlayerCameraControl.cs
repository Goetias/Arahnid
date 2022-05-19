using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] private Transform PlayerHead;
    [SerializeField] private InputActionProperty Action;
    [SerializeField] private float MouseSensivity;
    [SerializeField] private float SpeedBodyTurn;

    private Vector3 _headRotation;
    private Vector3 _bodyRotation;


    private Vector3 DetectMouse(UnityEngine.InputSystem.InputAction.CallbackContext callback)
    {
        Vector2 mouseDelta = callback.ReadValue<Vector2>();

        Vector3 mouseConvertDelta;
        mouseConvertDelta.x = -1 * mouseDelta.y;
        mouseConvertDelta.y = mouseDelta.x;
        mouseConvertDelta.z = 0;

        return mouseConvertDelta;
    }

    private void TurnCamera(UnityEngine.InputSystem.InputAction.CallbackContext callback)
    {
        Vector3 currentRotation = DetectMouse(callback) * MouseSensivity * Time.deltaTime;

        _headRotation += currentRotation;
        _bodyRotation += currentRotation;

        _headRotation = new Vector3(Mathf.Clamp(_headRotation.x, -45, 25), 0, 0);
        _bodyRotation = new Vector3(0, _bodyRotation.y, 0);

        PlayerHead.localRotation = Quaternion.Slerp(PlayerHead.localRotation, Quaternion.Euler(_headRotation), 1);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_bodyRotation), SpeedBodyTurn * Time.deltaTime);
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
}
