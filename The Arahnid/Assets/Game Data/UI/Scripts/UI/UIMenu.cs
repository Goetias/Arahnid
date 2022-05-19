using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour, IActivationUI
{
    public UIPanel Panel { get; private set; }


    private void Start()
    {
        SetPanel();
    }

    private void SetPanel()
    {
        if (transform.GetChild(0) != null)
        {
            if (transform.GetChild(0).GetComponent<UIPanel>() != null)
                Panel = transform.GetChild(0).GetComponent<UIPanel>();
            else Debug.LogError("The First child hasn't a UIPanel component");
        }
        else Debug.LogError("The First child is zero");
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
