using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBossController : EnemyController
{


    // Start is called before the first frame update
    void Start()
    {
        lookRadius = 100f;
        maxHealth = 500f;

        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 30f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _enemyAnimation = new SlimeAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
