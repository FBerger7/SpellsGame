using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : EnemyController
{
    private BaseSpell _sideAttack;

    private GolemAnimation _golemAnimation;

    private bool _phaseOne = true;

    private bool _phaseTwo = false;

    private bool _phaseThree = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 500f;

        _agent = GetComponent<NavMeshAgent>();
        lookRadius = 100f;
        _agent.stoppingDistance = 50f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        //_attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _sideAttack = gameObject.GetComponentInChildren<SpawnSlime>();
        _golemAnimation = new GolemAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _golemAnimation.AttackGAnimation(ref _anim, ref _attack, _target, isHostile);
                //_golemAnimation.AttackBAnimation(ref _anim, ref _attack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _golemAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _golemAnimation.IdleAnimation(ref _anim);
            }
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
