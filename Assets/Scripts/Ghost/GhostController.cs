using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class GhostController : Enemy
{
    private GhostAnimation _GhostAnimation = new GhostAnimation();

    private BasicAttack _basicAttack;

    // Start is called before the first frame update
    void Start()
    {
        lookRadius = 100f;
        maxHealth = 100f;


        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 50f;

        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform; //RangeAttribute of Ghost

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
                _GhostAnimation.AttackAnimation(ref anim, ref _basicAttack, target);

            }
            else if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                _GhostAnimation.WalkAnimation(ref anim, ref agent);  
                
            }
            else 
            {
                _GhostAnimation.IdleAnimation(ref anim);

            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
        _GhostAnimation.DieAnimation(ref anim);
        Debug.Log(transform.name + " died");


        // Destroy(gameObject);

    }
}

