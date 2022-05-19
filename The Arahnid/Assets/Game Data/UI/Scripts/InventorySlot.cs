using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventorySlot : MonoBehaviour
{
    private Item _item;

    public bool IsEmpty() => _item == null;

    public void FillUp(Item item)
    {
        GetComponent<Image>().sprite = item.Image;
        GetComponent<Image>().color = Color.white;

        _item = item;
    }

    public Item Clear()
    {
        GetComponent<Image>().sprite = null;
        GetComponent<Image>().color = Color.clear;

        return _item;
    }
}
