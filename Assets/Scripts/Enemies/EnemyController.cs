using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : CharacterStats
{
    public float lookRadius;
    public bool canMove;

    protected EnemyAnimation enemyAnimation;
    protected BaseSpell attack;
    protected Animator anim;
    protected Transform target;
    protected NavMeshAgent agent;

    protected void  FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(1.0f, 0.0f, 2f), lookRadius);
        Gizmos.color = Color.yellow;
        if(agent !=null)
         Gizmos.DrawWireSphere(transform.position + new Vector3(1.0f, 0.0f, 2f), agent.stoppingDistance);

    }

    protected void runUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (!anim.GetBool("isDie"))
        {
            if (canMove)
                WalkingEnemyConditions(distance);
            else
                StandingEnemyConditions(distance);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    private void WalkingEnemyConditions(float distance)
    {
        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            enemyAnimation.AttackAnimation(ref anim, ref attack, target);
        }
        else if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            enemyAnimation.WalkAnimation(ref anim, ref agent);
        }
        else if (!anim.GetBool("isIdle"))
        {
            enemyAnimation.IdleAnimation(ref anim);
        }
    }

    private void StandingEnemyConditions(float distance)
    {
        if (distance <= agent.stoppingDistance)
        {
            //Face the target
            FaceTarget();
            enemyAnimation.AttackAnimation(ref anim, ref attack, target);

        }
        else
        {
            enemyAnimation.IdleAnimation(ref anim);

        }
    }
}
