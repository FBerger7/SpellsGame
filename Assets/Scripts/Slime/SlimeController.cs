using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



    public class SlimeController : Enemy
    {
        private SlimeAnimation _slimeAnimation = new SlimeAnimation();

        public BaseSpell _basicAttack;  

        // Start is called before the first frame update
        void Start()
        {
            lookRadius = 50f;
            maxHealth = 100f;

            
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 30f;

            anim = GetComponent<Animator>();
            target = PlayerManager.instance.player.transform; //RangeAttribute of slime

            _basicAttack= gameObject.GetComponentInChildren<SlimeBomb>();
       
    }

    // Update is called once per frame
    void Update()
    {
        _poisonTimer -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);

        if (!anim.GetBool("isDie"))
        {

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                _slimeAnimation.AttackAnimation(ref anim ,ref _basicAttack, target);


            }
            else if (distance <= lookRadius)
            {

                agent.SetDestination(target.position);

                _slimeAnimation.WalkAnimation(ref anim, ref agent);

            }
            else if (!anim.GetBool("isIdle"))
            {
                _slimeAnimation.IdleAnimation(ref anim);

            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
        _slimeAnimation.DieAnimation(ref anim);
        Debug.Log(transform.name + " died");

    }
}

