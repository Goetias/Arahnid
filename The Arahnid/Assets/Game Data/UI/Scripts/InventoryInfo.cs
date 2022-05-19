using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInfo : MonoBehaviour
{
    [SerializeField] private ItemsBlock KeyBlock;
    [SerializeField] private ItemsBlock HandBlock;
    [SerializeField] private ItemsBlock SimpleBlock;

    private void Awake()
    {
        KeyBlock = new();
        HandBlock = new();
        SimpleBlock = new();
    }

    public void RemoveItem(int number)
    {
        KeyBlock.Remove(number);
        Debug.Log("Remove number: " + number);
    }

    public void AddTypeItem(Item item)
    {
        switch ((int)item.type)
        {
            case 0: KeyBlock.Add(item); break;
            case 1: SimpleBlock.Add(item); break;
            case 2: HandBlock.Add(item); break;
            default: throw new System.ArgumentOutOfRangeException(nameof(AddTypeItem));
        }
    }
}
