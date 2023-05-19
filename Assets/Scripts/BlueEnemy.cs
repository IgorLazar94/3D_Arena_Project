using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BlueEnemy : Enemy {

	private int currentHealthPoints;

    private void Start()
	{
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
