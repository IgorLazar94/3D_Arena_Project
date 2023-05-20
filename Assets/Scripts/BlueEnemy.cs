using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.PlayerLoop;

public class BlueEnemy : Enemy {


    private new void Start()
	{
		base.Start();
		SetDefaultState();
    }

    private void SetDefaultState()
	{
		maxHealthPoints = GameSettings.Instance.GetMaxHealhBlueEnemy();
		currentHealthPoints = maxHealthPoints;
		damage = GameSettings.Instance.GetDamageBlueEnemy();
		rewardEnergy = GameSettings.Instance.GetRewardEnergyBlue();
	}

	
}
