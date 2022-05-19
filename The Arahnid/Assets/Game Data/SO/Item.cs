using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "SO/Items/NewItem", order = 10)]
public class Item : ScriptableObject
{
    public enum TypeItem { Key = 0, Simple = 1, InHand = 2 }
    public TypeItem type;

    [SerializeField] private string _name;
    [SerializeField] Sprite _image;

    public string Name => _name;
    public Sprite Image => _image;

}
