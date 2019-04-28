using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class SlimeController : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimation = new SlimeAnimation();
        lookRadius = 50f;
        maxHealth = 100f;

        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 30f;

        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform; //RangeAttribute of slime

        attack = gameObject.GetComponentInChildren<SlimeBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        _poisonTimer -= Time.deltaTime;
        runUpdate();
    }

    public override void Die()
    {
        enemyAnimation.DieAnimation(ref anim);
        Debug.Log(transform.name + " died");
    }
}

