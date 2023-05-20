using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {

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
}
