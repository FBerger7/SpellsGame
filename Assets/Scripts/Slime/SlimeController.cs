using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



    public class SlimeController : Enemy
    {
        private SlimeAnimation _slimeAnimation = new SlimeAnimation();
        // Start is called before the first frame update
        void Start()
        {
            healthPoints = 10;
            lookRadius = 50f;
            rangeRadius = 30f;

            anim = GetComponent<Animator>();
            target = PlayerManager.instance.player.transform;
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {

            float distance = Vector3.Distance(target.position, transform.position);



            if (distance <= agent.stoppingDistance)
            {
                if (!anim.GetBool("isAttack"))
                {
                     _slimeAnimation.AttackAnimation(ref anim);
                }
                //Face the target
                FaceTarget();
                //Attack the target
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
    }

