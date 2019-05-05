using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBossController : EnemyController
{


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 500f;

        _agent = GetComponent<NavMeshAgent>();
        lookRadius = _agent.stoppingDistance = 100f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _enemyAnimation = new SlimeBossAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        _poisonTimer -= Time.deltaTime;
        RunUpdate();
    }
}
