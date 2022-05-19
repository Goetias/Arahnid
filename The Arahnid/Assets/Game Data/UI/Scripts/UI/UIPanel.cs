using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour, IActivationUI
{
    public UIMenu Parent { get; private set; }


    private void Start()
    {
        SetMenu();
    }

    private void SetMenu()
    {
        if (transform.parent != null)
        {
            if (transform.parent.GetComponent<UIMenu>() != null)
                Parent = transform.parent.GetComponent<UIMenu>();
            else Debug.LogError("The Parent hasn't a UIMenu component");
        }
        else Debug.LogError("The Parent is zero");
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
