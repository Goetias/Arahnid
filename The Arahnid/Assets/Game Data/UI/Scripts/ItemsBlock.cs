using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBlock : MonoBehaviour
{
    [SerializeField] private InventorySlot[] Slots;

    public void Add(Item item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.IsEmpty() == true)
            {
                Debug.Log("Add");
                slot.FillUp(item);
                break;
            }
        }
    }

    public void Remove(int number)
    {
        Slots[number].Clear();
    }
}
