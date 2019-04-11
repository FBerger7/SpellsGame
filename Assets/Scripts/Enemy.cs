using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public int healthPoints;
    public float lookRadius;
    public float rangeRadius;

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
        Gizmos.DrawWireSphere(transform.position + new Vector3(1.0f, 0.0f, 2f), rangeRadius);

    }

}
