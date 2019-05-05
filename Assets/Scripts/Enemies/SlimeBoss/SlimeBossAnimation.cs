using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBossAnimation : IEnemyAnimation
{
    public void IdleAnimation(ref Animator anim)
    {
        anim.CrossFade("Idle", 0.1f);
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalk", false);
        anim.SetBool("isAttack", false);
    }

    public void AttackAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        // Potem
    }

    public void DieAnimation(ref Animator anim)
    {
        // Potem
    }

    public void WalkAnimation(ref Animator anim, ref NavMeshAgent agent)
    {
        // Nigdy
    }
}
