using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : EnemyController
{
    private BaseSpell _spawnSlimeAttackL;

    private BaseSpell _spawnSlimeAttackR;

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

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
        //_spawnSlimeAttack = gameObject.GetComponentInChildren<SpawnSlime>();
        _spawnSlimeAttackL = gameObject.transform.Find("SpawnSlimeL").GetComponent<SpawnSlime>();
        _spawnSlimeAttackR = gameObject.transform.Find("SpawnSlimeR").GetComponent<SpawnSlime>();
        _golemAnimation = new GolemAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (!_anim.GetBool("isDie"))
        {
            if (_phaseOne) PhaseOne(distance);
            else if (_phaseTwo) PhaseTwo(distance);
            else if (_phaseThree) PhaseThree(distance);

        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    private void PhaseOne(float distance)
    {
        if (CurrentHealth < 0.6f * maxHealth)
        {
            Debug.Log("Phase Two started.");
            _phaseOne = false;
            _phaseTwo = true;
            return;
        }

        if (distance <= _agent.stoppingDistance)
        {
            FaceTarget();
            _golemAnimation.AttackBAnimation(ref _anim, ref _attack, _target, isHostile);
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

    private void PhaseTwo(float distance)
    {
        if (CurrentHealth < 0.3f * maxHealth)
        {
            Debug.Log("Phase Three started.");
            _phaseTwo = false;
            _phaseThree = true;
            _spawnSlimeAttackL.attackSpeed = 1.0f;
            _spawnSlimeAttackL.attackSpeed = 1.0f;
            return;
        }
        FaceTarget();
        _golemAnimation.SpawnSlimeAnimation(ref _anim, ref _spawnSlimeAttackL, ref _spawnSlimeAttackR, _target, isHostile);
    }

    private void PhaseThree(float distance)
    {
        _spawnSlimeAttackL.PerformAttack(_target.position, isHostile);
        _spawnSlimeAttackR.PerformAttack(_target.position, isHostile);
        //_golemAnimation.SpawnSlimeAnimation(ref _anim, ref _spawnSlimeAttackL, ref _spawnSlimeAttackR, _target, isHostile);
        if (distance <= _agent.stoppingDistance)
        {
            FaceTarget();
            _golemAnimation.AttackBAnimation(ref _anim, ref _attack, _target, isHostile);
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

    public override void Die()
    {
        _golemAnimation.DieAnimation(ref _anim);
        Debug.Log(transform.name + " died");
    }
}
