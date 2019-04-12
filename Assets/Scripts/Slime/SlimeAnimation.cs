using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
  public class SlimeAnimation
    {
        public void IdleAnimation(ref Animator anim)
        {
                anim.CrossFade("Idle", 0.1f);
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalk", false);
                anim.SetBool("isAttack", false);
        }
        public void WalkAnimation(ref Animator anim, ref NavMeshAgent agent)
        {
            if (!anim.GetBool("isWalk"))
            {
                // anim.CrossFade("WalkCycle", 0.1f);
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalk", true);
                anim.SetBool("isAttack", false);
                agent.isStopped = true;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkCycle")
                    && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.53f       //value which determine charge phase in animation
                    && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.80f)
            {
                agent.isStopped = false;
            }
            else
            {
                agent.isStopped = true;
            }
        }

        public void AttackAnimation(ref Animator anim)
        {

            anim.CrossFade("Attack", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isAttack", true);


        }

        public void DieAnimation(ref Animator anim)
        {
            anim.CrossFade("Die", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isIdle", false);

    }


    }
