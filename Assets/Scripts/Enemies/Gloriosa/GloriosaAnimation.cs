using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class GloriosaAnimation : EnemyAnimation
{
    public override void IdleAnimation(ref Animator anim)
    {
        if (!anim.GetBool("isIdle"))
        {
            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isDie", false);
        }
    }

    public override void AttackAnimation(ref Animator anim, ref BaseSpell attack, Transform target)
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
            attack.PerformAttack(target.position);
    }

    public override void DieAnimation(ref Animator anim)
    {
        anim.CrossFade("Die", 0.1f);
        anim.SetBool("isDie", true);
        anim.SetBool("isAttack", false);
        anim.SetBool("isIdle", false);

    }

    public override void WalkAnimation(ref Animator anim, ref NavMeshAgent agent)
    {
        throw new System.NotImplementedException();
    }
}
