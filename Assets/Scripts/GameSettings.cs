using System.Collections;
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
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private int playerBulletSpeed;
    [SerializeField] private float playerReloadTime;

    [Space]
    [Header("BlueEnemyStats")]
    [SerializeField] private int maxHealthBlue;
    [SerializeField] private int getDamageBlue;
    [SerializeField] private int rewardEnergyBlue;
    [SerializeField] private float flySpeedBlueProjectile;
    [SerializeField] private int energyDamage;

    [Space]
    [Header("RedEnemyStats")]
    [SerializeField] private int maxHealthRed;
    [SerializeField] private int getDamageRed;
    [SerializeField] private int rewardEnergyRed;
    [SerializeField] private float heightToUp;
    [SerializeField] private float timeToUp;
    [SerializeField] private float flySpeed;

    [Space]
    [Header("GlobalSettings")]
    [SerializeField] private int timeToSpawnEnemy;
    [SerializeField] private int limitToSpawnEnemy;


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
    public float GetPlayerMoveSpeed()
    {
        return playerMoveSpeed;
    }
    public int GetPlayerBulletSpeed()
    {
        return playerBulletSpeed;
    }
    public float GetPlayerReloadTime()
    {
        return playerReloadTime;
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
    public float GetFlySpeedBlueProjectile()
    {
        return flySpeedBlueProjectile;
    }
    public int GetEnergyDamage()
    {
        return energyDamage;
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

    // Global Settings
    public int GetTimeToSpawnEnemy()
    {
        return timeToSpawnEnemy;
    }
    public int GetLimitToSpawnEnemy()
    {
        return limitToSpawnEnemy;
    }
}
