using System;
using UnityEngine;

public class PlayerAnimations : Player
{
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void PlayWalking(float movement)
    {
        playerAnimator.SetFloat("Move", MathF.Abs(movement));
    }
}
