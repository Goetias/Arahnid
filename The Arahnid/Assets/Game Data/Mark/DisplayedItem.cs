using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedItem : InteractionItem
{
    [SerializeField] private UIPanel Panel;

    public override void ActiveInteract()
    {
        Panel.Show();
    }

    public override void HoverInteract()
    {
        
    }
}
