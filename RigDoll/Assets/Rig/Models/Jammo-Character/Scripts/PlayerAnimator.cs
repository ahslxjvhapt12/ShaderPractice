using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator AnimatorCompo { get; private set; }

    [Range(0,1)] public float startAnimTime = 0.3f;
    [Range(0, 1)] public float stopAnimTime = 0.15f;
    public float allowPlayerAnimation = 0.1f;

    private readonly int _xHash = Animator.StringToHash("X");
    private readonly int _yHash = Animator.StringToHash("Y");
    private readonly int _blendHash = Animator.StringToHash("blend");
    private readonly int _shootingHash = Animator.StringToHash("shooting");

    private void Awake()
    {
        AnimatorCompo = GetComponent<Animator>();
    }

    public void SetXY(Vector2 dir)
    {
        AnimatorCompo.SetFloat(_xHash, dir.x);
        AnimatorCompo.SetFloat(_yHash, dir.y);
    }

    public void SetShooting()
    {

    }


    public void SetBlendValue()
    {

    }
}
