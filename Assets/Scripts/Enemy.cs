using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {

    protected int currentHealthPoints;
    private Player player;
	protected int rewardEnergy { get; set; }

    protected void Start()
	{
        player = FindObjectOfType<Player>();

    }

    private void FixedUpdate()
    {
        transform.LookAt(player.gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
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
            EnemyDies();
        }
    }

    private void EnemyDies()
    {
        player.UpdateEnergy(rewardEnergy);
    }

}
