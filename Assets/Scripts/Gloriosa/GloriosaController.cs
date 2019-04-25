using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class GloriosaController : Enemy
{
    private GloriosaAnimation _GloriosaAnimation = new GloriosaAnimation();

    private BasicAttack _basicAttack;

    // Start is called before the first frame update
    void Start()
    {

        maxHealth = 200f;


        agent = GetComponent<NavMeshAgent>();
        lookRadius = agent.stoppingDistance = 50f;

        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform; //RangeAttribute of Gloriosa

        _basicAttack = gameObject.GetComponentInChildren<BasicAttack>();

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (!anim.GetBool("isDie"))
        {

            if (distance <= agent.stoppingDistance)
            {
                //Face the target
                FaceTarget();
                _GloriosaAnimation.AttackAnimation(ref anim, ref _basicAttack, target);

            }
            else
            {
                _GloriosaAnimation.IdleAnimation(ref anim);

            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
        _GloriosaAnimation.DieAnimation(ref anim);
        Debug.Log(transform.name + " died");


        // Destroy(gameObject);

    }
}

