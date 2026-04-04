using System;
using UnityEngine;

public class PlayerAnimations
{
    private Animator playerAnimator;

    public PlayerAnimations(Animator animator)
    {
        playerAnimator = animator;
    }

    public void PlayWalking(float movement)
    {
        playerAnimator.SetFloat("Move", MathF.Abs(movement));
    }
}
