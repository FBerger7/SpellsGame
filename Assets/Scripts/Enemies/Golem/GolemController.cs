using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : EnemyController
{
    public int maximumSlimeNumber;
    public float dashDamage;

    private BaseSpell _spawnSlimeAttackL;
    private BaseSpell _spawnSlimeAttackR;
    private GolemAnimation _golemAnimation;
    private bool _phaseOne = true;
    private bool _phaseTwo = false;
    private bool _phaseThree = false;
    private int dashFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.characterName = "Golem";
        maxHealth = 500f;

        _agent = GetComponent<NavMeshAgent>();
        lookRadius = 200f;
        _agent.stoppingDistance = 100f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
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
            SlimeController[] spawnedSlimes = Resources.FindObjectsOfTypeAll(typeof(SlimeController)) as SlimeController[];
            foreach (SlimeController slime in spawnedSlimes)
            {
                if (slime.name == "SpawnedSlime")
                    slime.Die();
            }
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
            _golemAnimation.AttackBAnimation(ref _anim, ref _attack, _target, isHostile, ref _agent);
        }
        else if (distance <= lookRadius)
        {
            _agent.SetDestination(_target.position);
            _golemAnimation.WalkAnimation(ref _anim, ref _agent);
        }
        else if (!_anim.GetBool("isIdle"))
        {
            _golemAnimation.IdleAnimation(ref _anim, ref _agent);
        }
    }

    private void PhaseTwo(float distance)
    {
        _agent.isStopped = true;
        if (CurrentHealth < 0.3f * maxHealth)
        {
            Debug.Log("Phase Three started.");
            _phaseTwo = false;
            _phaseThree = true;
            _spawnSlimeAttackL.attackSpeed = 1.0f;
            _spawnSlimeAttackL.attackSpeed = 1.0f;
            return;
        }
        //FaceTarget();
        if (_getSlimeCount() < maximumSlimeNumber)
        {
            FaceTarget();
            _golemAnimation.SpawnSlimeAnimation(ref _agent, ref _anim, ref _spawnSlimeAttackL, ref _spawnSlimeAttackR, _target, isHostile);
        }
        else //if (distance <= _agent.stoppingDistance)
        {
            //FaceTarget();

            _agent.SetDestination(_target.position);
            if (dashFlag == 0)
            {
                _golemAnimation.DashAnimation(ref _agent, ref _anim, ref _attack, _target, isHostile);
            }
           else
            {
                _golemAnimation.IdleAnimation(ref _anim, ref _agent);
                dashFlag++;
            }
        }
        
    }

    private void PhaseThree(float distance)
    {
        _spawnSlimeAttackL.PerformAttack(_target.position, isHostile);
        _spawnSlimeAttackR.PerformAttack(_target.position, isHostile);
        if (distance <= _agent.stoppingDistance)
        {
            FaceTarget();
            _golemAnimation.AttackBAnimation(ref _anim, ref _attack, _target, isHostile, ref _agent);
        }
        else if (distance <= lookRadius)
        {
            _agent.SetDestination(_target.position);
            _golemAnimation.WalkAnimation(ref _anim, ref _agent);
        }
        else if (!_anim.GetBool("isIdle"))
        {
            _golemAnimation.IdleAnimation(ref _anim, ref _agent);
        }
    }

    private int _getSlimeCount()
    {
        SlimeController[] spawnedSlimes = Resources.FindObjectsOfTypeAll(typeof(SlimeController)) as SlimeController[];
        int count = 0;
        foreach (SlimeController slime in spawnedSlimes)
        {
            if (slime.name == "SpawnedSlime")
                count++;
        }
        return count;
    }

    public override void Die()
    {
        _golemAnimation.DieAnimation(ref _anim, ref _agent);
        Debug.Log(transform.name + " died");
    }

    private void OnCollisionEnter(Collision other)
    {

        CharacterStats parent = other.gameObject.GetComponentInParent<CharacterStats>();
        if (parent != null && this.isHostile != parent.isHostile)
        {
            dashFlag = -200;
            _agent.isStopped = true;
            _golemAnimation.IdleAnimation(ref _anim, ref _agent);
            parent.TakeDamage(dashDamage);
        }
        
    }
}
