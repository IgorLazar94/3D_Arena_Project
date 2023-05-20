using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : Unit {

    protected int currentHealthPoints;
    protected PlayerController player;
	protected int rewardEnergy { get; set; }

    protected void Start()
	{
        player = FindObjectOfType<PlayerController>();

    }

    protected void FixedUpdate()
    {
        transform.LookAt(player.gameObject.transform);
    }

    protected void EnemyGetDamage()
    {
        currentHealthPoints -= damage;
        Debug.Log(currentHealthPoints + " enemy HP");
        if (currentHealthPoints <= 0)
        {
            EnemyDieFromPlayer();
        }
    }

    private void EnemyDieFromPlayer()
    {
        player.UpdateEnergy(rewardEnergy);
        EnemyDie();
    }

    protected void EnemyDie()
    {
        Destroy(gameObject);
    }

}
