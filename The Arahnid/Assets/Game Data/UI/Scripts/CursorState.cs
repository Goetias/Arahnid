using UnityEngine;

public class CursorState : MonoBehaviour
{
    public static CursorState Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        Lock();
    }

    public void Lock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Open()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SetState(bool isOpen)
    {
        Cursor.visible = isOpen;

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
