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
        if (!anim.GetBool("isAttack"))
        {
            anim.CrossFade("Attack", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isAttack", true);
            anim.SetBool("isIdle", false);
        }

        //Attack the target
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.42f)
            attack.PerformAttack(target.position, isHostile);
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
