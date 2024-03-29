using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : InteractionItem, IRecordInventory
{
    [SerializeField] private Item Item;

    public override void ActiveInteract()
    {
        Delete();
    }

    public override void HoverInteract()
    {
        
    }

    public void Delete()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Record(InventoryInfo inventory)
    {
        inventory.AddTypeItem(Item);
    }
}
