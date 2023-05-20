using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy {


    private new void Start()
    {
        base.Start();
        SetDefaultStates();
    }

    private void SetDefaultStates()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxHealhRedEnemy();
        currentHealthPoints = maxHealthPoints;
        damage = GameSettings.Instance.GetDamageRedEnemy();
        rewardEnergy = GameSettings.Instance.GetRewardEnergyRed();
    }

   
}
