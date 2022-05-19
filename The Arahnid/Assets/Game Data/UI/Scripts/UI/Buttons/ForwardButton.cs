using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardButton : UIButton
{
    [SerializeField] private UIMenu TargetMenu;

    public override void Press()
    {
        base.Press();

        Forward();
    }

    private void Forward()
    {
        TargetMenu.Panel.Show();
        transform.parent.parent.GetComponent<UIMenu>().Panel.Hide();
    }
}
