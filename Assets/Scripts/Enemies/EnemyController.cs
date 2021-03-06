﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : CharacterStats
{
    public float lookRadius;

    protected IEnemyAnimation _enemyAnimation;
    protected BaseSpell _attack;
    protected Animator _anim;
    protected Transform _target;
    protected NavMeshAgent _agent;

    protected void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 armaturePosition;
        Transform armature = transform.Find("Armature");
        if (armature == null)
            armaturePosition = transform.GetChild(0).Find("Armature").position;
        else
            armaturePosition = armature.position;
        Vector3 center = new Vector3(armaturePosition.x, 0.0f, armaturePosition.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, lookRadius);
        Gizmos.color = Color.yellow;
        if (_agent != null)
            Gizmos.DrawWireSphere(center, _agent.stoppingDistance);
    }

    protected void RunUpdate()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _agent.isStopped = true;
                _enemyAnimation.AttackAnimation(ref _anim, ref _attack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _agent.isStopped = false;
                _enemyAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _agent.isStopped = true;
                _enemyAnimation.IdleAnimation(ref _anim);
            }
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
