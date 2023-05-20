using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BlueEnemy blueEnemy;
    [SerializeField] private RedEnemy redEnemy;

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {

    }

    public void PlayerShoot()
    {
        player.Shoot();
    }

}
