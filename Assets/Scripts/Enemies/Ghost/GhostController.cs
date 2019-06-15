using UnityEngine;
using UnityEngine.AI;

public class GhostController : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        this.characterName = "Ghost";
        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponent<Animator>();
        _target = PlayerManager.instance.player.transform; //RangeAttribute of Ghost

        _attack = gameObject.GetComponentInChildren<BasicAttack>();
        _enemyAnimation = new GhostAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        RunUpdate();
    }

    public override void Die()
    {
        _enemyAnimation.DieAnimation(ref _anim);
        Debug.Log(transform.name + " died");
        // Destroy(gameObject);
    }
}

