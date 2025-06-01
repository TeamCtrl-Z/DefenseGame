using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FairyAnimationBirdge : MonoBehaviour
{
    private Animator animator;
    private AttackHandler attack;
    private Action attackAnim;

    private void Awake()
    {
        attack = GetComponent<AttackHandler>();
        animator = GetComponent<Animator>();

        attackAnim = () => animator.SetTrigger(AnimatorHash.Fairy.AttackTrigger);
    }
}
