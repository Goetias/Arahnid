using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationItem : InteractionItem
{
    [SerializeField] private string AnimationName;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null) throw new System.ArgumentNullException(nameof(_animator));
    }

    public override void ActiveInteract()
    {
        PlayAnimation();
    }

    public override void HoverInteract()
    {
        
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger(AnimationName);
    }
}
