using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public virtual void Press()
    {
        UICanvas.Instance.Play();
    }
}
