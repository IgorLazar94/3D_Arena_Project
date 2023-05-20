using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy {

    private int currentHealthPoints;

    private new void Start()
    {
        base.Start();
        SetDefaultState();
    }

    private void SetDefaultState()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxHealhRedEnemy();
        currentHealthPoints = maxHealthPoints;
        damage = GameSettings.Instance.GetDamageRedEnemy();
        rewardEnergy = GameSettings.Instance.GetRewardEnergyRed();
    }

   
}
