using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsBlock : MonoBehaviour
{
    [SerializeField] private List<Image> Images;

    public void Add(Item item)
    {
        foreach (Image image in Images)
        {
            if (image.sprite == null)
            {
                Debug.Log("Add");
                image.sprite = item.Image;
                break;
            }
        }
    }

    public void Remove(int number)
    {
        Images[number].sprite = null;
    }
}
