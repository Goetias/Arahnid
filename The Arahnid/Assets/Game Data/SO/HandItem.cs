using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHandItem", menuName = "SO/Items/NewHandItem", order = 11)]
public class HandItem : Item
{
    [SerializeField] private GameObject Prefab;

    public GameObject _prefab => Prefab;
}
