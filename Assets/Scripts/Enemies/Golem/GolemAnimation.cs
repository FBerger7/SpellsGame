using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class GolemAnimation 
{
    public void IdleAnimation(ref Animator anim)
    {
        if (!anim.GetBool("isIdle"))
        {
            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnSlime", false);
        }
    }

    public void WalkAnimation(ref Animator anim, ref NavMeshAgent agent)
    {
        if (!anim.GetBool("isWalk"))
        {
            anim.CrossFade("Walk", 0.1f);
            anim.SetBool("isWalk", true);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnSlime", false);
            
        }
    }
    

    public void AttackGAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        if (!anim.GetBool("isAttackG"))
        {
            anim.CrossFade("AttackG", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", true);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnSlime", false);
    }

    }
    public void AttackBAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        if (!anim.GetBool("isAttackB"))
        {
            anim.CrossFade("AttackB", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", true);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnSlime", false);
    }

    }
    public void SpawnSlimeAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        if (!anim.GetBool("isSpawnSlime"))
        {
            anim.CrossFade("SpawnSlime", 0.1f);
            anim.SetBool("isWalk",false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", false);
            anim.SetBool("isSpawnSlime", true);
    }

    }

    public void DashAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile)
    {
        if (!anim.GetBool("isDash"))
        {
            anim.CrossFade("Dash", 0.1f);
            anim.SetBool("isWalk", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttackG", false);
            anim.SetBool("isAttackB", false);
            anim.SetBool("isDash", true);
            anim.SetBool("isSpawnSlime", false);
    }

    }

    public void DieAnimation(ref Animator anim)
    {
        anim.CrossFade("Die", 0.1f);
        anim.SetBool("isWalk", false);
        anim.SetBool("isDie", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttackG", false);
        anim.SetBool("isAttackB", false);
        anim.SetBool("isDash", false);
        anim.SetBool("isSpawnSlime", false);
    }
}
