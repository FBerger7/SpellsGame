using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBossController : EnemyController
{
    private BaseSpell _sideAttack;

    private bool _phaseOne = true;

    private bool _phaseTwo = false;

    private bool _phaseThree = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 500f;

        _agent = GetComponent<NavMeshAgent>();
        lookRadius = _agent.stoppingDistance = 100f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        //_attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _attack = gameObject.GetComponentInChildren<SpawnSlime>();
        _sideAttack = gameObject.GetComponentInChildren<SpawnSlime>();
        _enemyAnimation = new SlimeBossAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        _poisonTimer -= Time.deltaTime;

        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _enemyAnimation.AttackAnimation(ref _anim, ref _attack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _enemyAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _enemyAnimation.IdleAnimation(ref _anim);
            }
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    private void PhaseOne()
    {
        if (CurrentHealth < 0.6f * maxHealth)
        {
            _phaseOne = false;
            _phaseTwo = true;
            return;
        }

        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _enemyAnimation.AttackAnimation(ref _anim, ref _attack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _enemyAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _enemyAnimation.IdleAnimation(ref _anim);
            }
        }
    }

    private void PhaseTwo()
    {
        if (CurrentHealth < 0.3f * maxHealth)
        {
            _phaseTwo = false;
            _phaseThree = true;
            return;
        }

        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _enemyAnimation.AttackAnimation(ref _anim, ref _sideAttack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _enemyAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _enemyAnimation.IdleAnimation(ref _anim);
            }
        }
    }

    private void PhaseThree()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
                _enemyAnimation.AttackAnimation(ref _anim, ref _attack, _target, isHostile);
                _enemyAnimation.AttackAnimation(ref _anim, ref _sideAttack, _target, isHostile);
            }
            else if (distance <= lookRadius)
            {
                _agent.SetDestination(_target.position);
                _enemyAnimation.WalkAnimation(ref _anim, ref _agent);
            }
            else if (!_anim.GetBool("isIdle"))
            {
                _enemyAnimation.IdleAnimation(ref _anim);
            }
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
