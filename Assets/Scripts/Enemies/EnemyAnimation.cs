using UnityEngine;
using UnityEngine.AI;

public interface IEnemyAnimation
{
    void IdleAnimation(ref Animator anim);
    void WalkAnimation(ref Animator anim, ref NavMeshAgent agent);
    void AttackAnimation(ref Animator anim, ref BaseSpell attack, Transform target, bool isHostile);
    void DieAnimation(ref Animator anim);
}
