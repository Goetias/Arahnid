using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventorySlot : MonoBehaviour
{
    private Image _image;
    private Item _item;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public bool IsEmpty() => _image.sprite;

    public void FillUp(Item item)
    {
        _image.sprite = item.Image;
        _image.color = Color.white;

        _item = item;
    }

    public Item Clear()
    {
        _image.sprite = null;
        _image.color = Color.clear;

        return _item;
    }
}
