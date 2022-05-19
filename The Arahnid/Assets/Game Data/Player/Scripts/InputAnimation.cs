using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class InputAnimation : InputEvent
{
    protected string _nameAnim;
    private Animator _animator;
    private int _isHash;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _isHash = Animator.StringToHash(_nameAnim);
    }

    private void LateUpdate()
    {
        HandleAnimation();
    }

    public void HandleAnimation()
    {
        bool isMoving = _animator.GetBool(_isHash);

        if (IsPressed & !isMoving)
        {
            _animator.SetBool(_isHash, true);
        }
        else if (!IsPressed & isMoving)
        {
            _animator.SetBool(_isHash, false);
        }
    }
}
