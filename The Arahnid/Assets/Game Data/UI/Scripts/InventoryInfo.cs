using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInfo : MonoBehaviour
{
    [SerializeField] private List<ItemsBlock> Blocks;

    private List<Item> _keyItems;
    private List<Item> _handItems;
    private List<Item> _simpleItems;

    private void Awake()
    {
        _keyItems = new();
        _handItems = new();
        _simpleItems = new();
    }

    public void RemoveItem(int number)
    {
        _keyItems.RemoveAt(number);
        Debug.Log(_keyItems.Count);
    }

    public void AddTypeItem(Item item)
    {
        switch ((int)item.type)
        {
            case 0: _keyItems.Add(item); Blocks[0].Add(item); break;
            case 1: _simpleItems.Add(item); Blocks[1].Add(item); break;
            case 2: _handItems.Add(item); Blocks[2].Add(item); break;
            default: throw new System.ArgumentOutOfRangeException(nameof(AddTypeItem));
        }
    }
}
