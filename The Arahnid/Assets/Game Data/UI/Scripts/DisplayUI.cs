using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayUI : MonoBehaviour, ITimeService
{
    [SerializeField] private PlayerStateInfo PlayerInfo;
    [SerializeField] private InputActionProperty ActionInventory;
    [SerializeField] private UIPanel OpenPanel;

    private bool _isPressed = false;
    private bool _isEnable = true;

    public void Display()
    {
        if (_isEnable == true)
        {
            Press();
        }
        else Debug.Log("Time is stopped!");
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
        ActionInventory.action.started += T => Display();
    }

    private void OnDisable()
    {
        ActionInventory.action.started -= T => Display();
        Unsubscribe();
    }

    public void Pause()
    {
        if (_isPressed == false)
            _isEnable = false;
    }

    public void Play()
    {
        _isEnable = true;
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
