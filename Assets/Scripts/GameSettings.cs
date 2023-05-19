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
    [SerializeField] private int damagePlayer;

    [Space]
    [Header("BlueEnemyStats")]
    [SerializeField] private int maxHealthBlue;
    [SerializeField] private int damageBlue;
    [SerializeField] private int rewardEnergyBlue;

    [Space]
    [Header("RedEnemyStats")]
    [SerializeField] private int maxHealthRed;
    [SerializeField] private int damageRed;
    [SerializeField] private int rewardEnergyRed;


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
        return damagePlayer;
    }

    // Blue enemy Stats
   
    public int GetMaxHealhBlueEnemy()
    {
        return maxHealthBlue;
    }
    public int GetDamageBlueEnemy()
    {
        return damageBlue;
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
        return damageRed;
    }
    public int GetRewardEnergyRed()
    {
        return rewardEnergyRed;
    }


}
