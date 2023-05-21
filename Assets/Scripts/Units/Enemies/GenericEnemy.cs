using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : Unit {

    protected int currentHealthPoints;
    protected PlayerController player;
	protected int rewardEnergy { get; set; }
    private EnemiesSpawner spawner;

    public void SetLinkEnemySpawner(EnemiesSpawner _spawner)
    {
        spawner = _spawner;
    }

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

    public void EnemyDieFromPlayer()
    {
        player.UpdateEnergy(rewardEnergy);
        spawner.AddKilledEnemyCount();
        EnemyDie();
    }

    protected void EnemyDie()
    {
        spawner.genericEnemiesList.Remove(this);
        Destroy(gameObject);
    }

}
