using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class GloriosaAnimation
{
    public void IdleAnimation(ref Animator anim)
    {
        if (!anim.GetBool("isIdle"))
        {
            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isDie", false);
        }
    }


    public void AttackAnimation(ref Animator anim, ref BasicAttack basicAttack, Transform target)
    {
        if (!anim.GetBool("isAttack"))
        {
            anim.CrossFade("Attack", 0.1f);
            anim.SetBool("isDie", false);
            anim.SetBool("isAttack", true);
            anim.SetBool("isIdle", false);
        }

        //Attack the target
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.33f)
            basicAttack.PerformAttack(target.position);


    }

    public void DieAnimation(ref Animator anim)
    {
        anim.CrossFade("Die", 0.1f);
        anim.SetBool("isDie", true);
        anim.SetBool("isAttack", false);
        anim.SetBool("isIdle", false);

    }


}
