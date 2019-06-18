using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class SlimeController : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        this.characterName = "Slime";
        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform; //RangeAttribute of slime

        _attack = gameObject.GetComponentInChildren<SlimeBomb>();
        _enemyAnimation = new SlimeAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        _poisonTimer -= Time.deltaTime;
        RunUpdate();
    }

    public override void Die()
    {
        _enemyAnimation.DieAnimation(ref _anim);
        Debug.Log(transform.name + " died");
    }
}

