using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public abstract class EnemyAnimation
{
    public abstract void IdleAnimation(ref Animator anim);
    public abstract void WalkAnimation(ref Animator anim, ref NavMeshAgent agent);
    public abstract void AttackAnimation(ref Animator anim, ref BaseSpell attack, Transform target);
    public abstract void DieAnimation(ref Animator anim);
}
