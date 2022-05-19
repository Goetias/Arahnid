using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionItem : MonoBehaviour
{
    [SerializeField] private string NameInteractionKey;

    public abstract void HoverInteract();
    public abstract void ActiveInteract();

    public string GetNameKey() => NameInteractionKey;
    
}
