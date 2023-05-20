﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    public static GameSettings Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Space]
    [Header("PlayerStats")]
    [SerializeField] private int maxHealthPlayer;
    [SerializeField] private int maxEnergyPlayer;
    [SerializeField] private int getDamagePlayer;

    [Space]
    [Header("BlueEnemyStats")]
    [SerializeField] private int maxHealthBlue;
    [SerializeField] private int getDamageBlue;
    [SerializeField] private int rewardEnergyBlue;

    [Space]
    [Header("RedEnemyStats")]
    [SerializeField] private int maxHealthRed;
    [SerializeField] private int getDamageRed;
    [SerializeField] private int rewardEnergyRed;
    [SerializeField] private float heightToUp;
    [SerializeField] private float timeToUp;
    [SerializeField] private float flySpeed;


    // Player Stats
    public int GetMaxPlayerHealth()
    {
        return maxHealthPlayer;
    }
    public int GetMaxEnergy()
    {
        return maxEnergyPlayer;
    }
    public int GetDamagePlayer()
    {
        return getDamagePlayer;
    }

    // Blue enemy Stats
   
    public int GetMaxHealhBlueEnemy()
    {
        return maxHealthBlue;
    }
    public int GetDamageBlueEnemy()
    {
        return getDamageBlue;
    }
    public int GetRewardEnergyBlue()
    {
        return rewardEnergyBlue;
    }
    // Red enemy Stats
    public int GetMaxHealhRedEnemy()
    {
        return maxHealthRed;
    }
    public int GetDamageRedEnemy()
    {
        return getDamageRed;
    }
    public int GetRewardEnergyRed()
    {
        return rewardEnergyRed;
    }
    public float GetHeightToUp()
    {
        return heightToUp;
    }
    public float GetTimeToUp()
    {
        return timeToUp;
    }
    public float GetFlySpeed()
    {
        return flySpeed;
    }


}
