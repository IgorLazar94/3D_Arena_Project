using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.PlayerLoop;

public class BlueEnemy : GenericEnemy
{

    [SerializeField] private Transform projectileContainer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;


    private new void Start()
    {
        base.Start();
        SetDefaultStates();
        StartCoroutine(StartBlueShooting());
    }

    private void SetDefaultStates()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxHealhBlueEnemy();
        currentHealthPoints = maxHealthPoints;
        damage = GameSettings.Instance.GetDamageBlueEnemy();
        rewardEnergy = GameSettings.Instance.GetRewardEnergyBlue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagList.Bullet)
        {
            var bulletScript = other.gameObject.GetComponent<PlayerProjectile>();

                EnemyGetDamage();
            if (bulletScript.isReadyForDoubleKill)
            {
                if (currentHealthPoints <= 0)
                {
                    player.RewardPlayerForDoubleKill();
                }
            }

            if (bulletScript.GetChanceToRicochet())
            {
                bulletScript.ChooseRandomDirection();
            }
            else
            {
                bulletScript.DestroyProjectile();
            }
        }
    }

    private IEnumerator StartBlueShooting()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(3.0f);
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity, transform);
        bullet.GetComponent<EnemyBlueProjectile>().SetPlayer(player);
        bullet.transform.parent = projectileContainer;
    }



}
