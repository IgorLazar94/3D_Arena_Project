using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {

	[SerializeField] private int maxEnergy;
	private int currentHealthPoints;
	private int currentEnergy;

	 private void Start()
	{
		SetDefaultStats();
    }

	private void SetDefaultStats()
	{
		maxHealthPoints = GameSettings.Instance.GetMaxPlayerHealth();
		maxEnergy = GameSettings.Instance.GetMaxEnergy();
		damage = GameSettings.Instance.GetDamagePlayer();
        currentHealthPoints = maxHealthPoints;
		currentEnergy = maxEnergy / 2;
    }
}
