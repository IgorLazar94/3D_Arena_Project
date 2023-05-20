using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private BlueEnemy blueEnemy;
    [SerializeField] private RedEnemy redEnemy;
    private List<GenericEnemy> genericEnemies = new List<GenericEnemy>();

    private void Start()
    {
        InitializePlayer();
        StartCoroutine(InitializeEnemy());
    }

    private void InitializePlayer()
    {

    }

    private IEnumerator InitializeEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void PlayerShoot()
    {
        player.Shoot();
    }

    public void UseUltimatePower()
    {
        player.UseUltimate();
    }

    public void DestroyAllEnemies()
    {
        Debug.Log("all enemies died");
    }
}
