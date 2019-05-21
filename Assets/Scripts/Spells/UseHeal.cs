using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHeal : InstantSpell
{
    public GameObject heal;
    public OffensiveSpellsModel model;
    public float healValue;
    private PlayerMovement _playerMovment;

    private bool isActive = false;
    private CharacterStats _characterStats;
    public float duration;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {

        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            GameObject newheal = Instantiate(heal, PlayerManager.instance.player.transform.position, Quaternion.Euler(-90,0,0)) ;
            _characterStats=GetComponentInParent(typeof(CharacterStats)) as CharacterStats;
            _characterStats.Heal(healValue);
            _playerMovment=GetComponentInParent(typeof(PlayerMovement)) as PlayerMovement;
            isActive = true;
        
            _playerMovment.enabled=false;
            // newPowerShield.lifeSpawn = shieldLifeSpan;
            // newPowerShield.firePoint = firePoint;
        }
    }

    private void Update()
    {
        if (isActive)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                _playerMovment.enabled = true;
                isActive = false;
            }

        }
    }


}
