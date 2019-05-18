using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        lookRadius = _agent.stoppingDistance = 100f;

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform;

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _sideAttack = gameObject.GetComponentInChildren<SpawnSlime>();
        _golemAnimation = new GolemAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
