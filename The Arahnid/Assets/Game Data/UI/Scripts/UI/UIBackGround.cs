using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIMenu))]
public class UIBackGround : MonoBehaviour
{
    public static UIBackGround Instance { get; private set; }
    private UIMenu Menu;

    private void Awake()
    {
        Instance = this;
        Menu = GetComponent<UIMenu>();
    }

    public void Activation(bool isShow)
    {
        if (isShow == true)
            Menu.Panel.Show();
        else
            Menu.Panel.Hide();
    }
}
