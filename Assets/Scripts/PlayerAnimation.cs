using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    public void IdleAnimation(ref Animator anim)
    {
        if (!anim.GetBool("isIdle"))
        {
            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isInBasicAttack", false);
            anim.SetBool("isDead", false);
            anim.SetBool("isInPary", false);
            anim.SetBool("isInParyTransition", false);
        }
    }

    public void DieAnimation(ref Animator anim)
    {
        anim.CrossFade("Death", 0.1f);
        anim.SetBool("isDead", true);
        anim.SetBool("isInBasicAttack", false);
        anim.SetBool("isIdle", false);
    }

    public void AttackAnimation(ref Animator anim)
    {
        if (!anim.GetBool("isInBasicAttack"))
        {
            anim.CrossFade("BasicAttack", 0.1f);
            anim.SetBool("isInBasicAttack", true);
            anim.SetBool("isIdle", false);

        }
    }

    public void ParyAttackTransition(ref Animator anim)
    {
        if (!anim.GetBool("isInParyTransition"))
        {
            anim.CrossFade("GoToParyAttack", 0.1f);
            anim.SetBool("isInParyTransition", true);
            anim.SetBool("isIdle", false);

        }
    }

    public void ParyAttack(ref Animator anim)
    {
        if (!anim.GetBool("isInPary"))
        {
            anim.CrossFade("ParyAttackContinous", 0.1f);
            anim.SetBool("isInParyTransition", false);
            anim.SetBool("isInPary", true);

        }
    }

}
