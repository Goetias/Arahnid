using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : UIButton
{
    public override void Press()
    {
        base.Press();
        Back();
    }

    private void Back()
    {
        transform.parent.parent.parent.GetComponent<UIMenu>().Panel.Show();
        transform.parent.parent.GetComponent<UIMenu>().Panel.Hide();
    }
}
