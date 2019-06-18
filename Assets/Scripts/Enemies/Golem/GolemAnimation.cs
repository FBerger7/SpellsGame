using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class GolemAnimation
{
    public void IdleAnimation(ref Animator anim, ref NavMeshAgent agent)
    {
        agent.isStopped = true;
        if (!anim.GetBool("isIdle"))
        {
            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnS", false);
        }
    }

    public void WalkAnimation(ref Animator anim, ref NavMeshAgent agent)
    {
        agent.isStopped = false;
        if (!anim.GetBool("isWalk"))
        {
            anim.CrossFade("Walk", 0.1f);
            anim.SetBool("isWalk", true);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnS", false);
            agent.speed = 20;
            agent.acceleration = 20;
            agent.stoppingDistance = 100;
        }
    }


    public void AttackGAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile, ref NavMeshAgent agent)
    {
        agent.isStopped = true;
        if (!anim.GetBool("isAttackG"))
        {
            anim.CrossFade("AttackGround", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", true);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnS", false);
        }

        //Attack the target
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackG") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.33f)
        attack.PerformAttack(target.position, isHostile);

    }
    public void AttackBAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile, ref NavMeshAgent agent)
    {
        agent.isStopped = true;
        if (!anim.GetBool("isAttackB"))
        {
            anim.CrossFade("AttackBomb", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", true);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnS", false);
        }

        //Attack the target
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackBomb") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        attack.PerformAttack(target.position, isHostile);

    }
    public void SpawnSlimeAnimation(ref NavMeshAgent agent, ref Animator anim, ref BaseSpell spawnSlimeL, ref BaseSpell spawnSlimeR, Transform target, bool isHostile)
    {
        agent.isStopped = true;
        if (!anim.GetBool("isSpawnS"))
        {
            anim.CrossFade("SpawnSlime", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnS", true);
            agent.acceleration = 20;
            agent.speed = 20;
            agent.stoppingDistance = 100;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("SpawnSlime") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.71f)
        {
            spawnSlimeL.PerformAttack(target.position, isHostile);
            spawnSlimeR.PerformAttack(target.position, isHostile);
        }
    }

    public void DashAnimation(ref NavMeshAgent agent, ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        agent.isStopped = false;
        if (!anim.GetBool("isDash"))
        {
            anim.CrossFade("Dash", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", true);
            anim.SetBool("isSpawnS", false);
            agent.acceleration = 100;
            agent.speed = 100;
            agent.stoppingDistance = 0;
        }
    }

    public void DieAnimation(ref Animator anim,ref NavMeshAgent agent)
    {
        agent.isStopped = true;
        anim.CrossFade("Die", 0.1f);
        anim.SetBool("isWalk", false);
        anim.SetBool("isDie", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttackG", false);
        anim.SetBool("isAttackB", false);
        anim.SetBool("isDash", false);
        anim.SetBool("isSpawnS", false);
    }
}
