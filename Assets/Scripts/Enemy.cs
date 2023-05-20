using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {

    protected int currentHealthPoints;
    protected Player player;
	protected int rewardEnergy { get; set; }

    protected void Start()
	{
        player = FindObjectOfType<Player>();

    }

    private void FixedUpdate()
    {
        transform.LookAt(player.gameObject.transform);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == TagList.Bullet)
        {
            EnemyGetDamage();
        }
    }

    private void EnemyGetDamage()
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
