﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerController : Unit
{

    [SerializeField] private int maxEnergy;
    [SerializeField] private PlayerProjectile bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Camera cameraObject;
    [SerializeField] private Transform projectileContainer;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    private int currentHealthPoints;
    private int currentEnergy;
    private float bulletSpeed = 50.0f;
    private bool isReadyToShoot = true;

    private void Start()
    {
        SetDefaultStats();
        uiManager.UpdateHealthBar(currentHealthPoints);
        uiManager.UpdateEnergyBar(currentEnergy);
    }

    private void SetDefaultStats()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxPlayerHealth();
        maxEnergy = GameSettings.Instance.GetMaxEnergy();
        damage = GameSettings.Instance.GetDamagePlayer();
        bulletSpeed = GameSettings.Instance.GetPlayerBulletSpeed();
        currentHealthPoints = maxHealthPoints;
        currentEnergy = maxEnergy / 2;
    }


    public void Shoot()
    {
        if (isReadyToShoot)
        {
            StartCoroutine(InstantiateBullet());
        }
    }

    private IEnumerator InstantiateBullet()
    {
        isReadyToShoot = false;

        Vector3 shootDirection = bulletSpawnPos.position - cameraObject.transform.position;
        //var rightCorner = Quaternion.Euler(new Vector3(gun.position.x, gun.transform.position.y, gun.transform.position.z));
        var bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity, transform);
        bullet.SetChanceToRicochet(CheckChanceToRicochet());
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * bulletSpeed, ForceMode.Impulse);
        bullet.SetBulletSpeed(bulletSpeed);
        bullet.transform.parent = projectileContainer;
        uiManager.MoveAim();
        yield return new WaitForSeconds(0.5f);
        isReadyToShoot = true;
    }

    public void UpdateEnergy(int bonusEnergy)
    {
        if (bonusEnergy < 0)
        {
            uiManager.ActivateHitBlueSprite();
        }
        currentEnergy += bonusEnergy;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        uiManager.UpdateEnergyBar(currentEnergy);
    }

    private void RemoveHealthPoint()
    {
        currentHealthPoints -= damage;
        currentHealthPoints = Mathf.Clamp(currentHealthPoints, 0, maxHealthPoints);
        uiManager.UpdateHealthBar(currentHealthPoints);
    }
    private void AddHealthPoint(int addHp)
    {
        currentHealthPoints += addHp;
        currentHealthPoints = Mathf.Clamp(currentHealthPoints, 0, maxHealthPoints);
        uiManager.UpdateHealthBar(currentHealthPoints);
    }

    public void PlayerGetDamage()
    {
        RemoveHealthPoint();
        gameManager.VisualHit();
        uiManager.ActivateHitRedSprite();

        Debug.Log(currentHealthPoints + "player HP");
        if (currentHealthPoints <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        // !!!!!!!!
    }

    public void RewardPlayerForDoubleKill()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            AddHealthPoint(maxHealthPoints / 2);
        }
        else
        {
            UpdateEnergy(25);
        }
    }

    public void UseUltimate()
    {
        if (currentEnergy >= maxEnergy)
        {
            gameManager.DestroyAllEnemies();
            currentEnergy = 0;
        }
    }

    private bool CheckChanceToRicochet()
    {
        float differenceHP = (float)currentHealthPoints / (float)maxHealthPoints;
        if (differenceHP <= 0.1)
        {
            return true;
        }
        float chance = 1f - Random.value;

        if (differenceHP > chance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //private void Update()
    //{
    //    DebugRicochetChance();
    //}

    private void DebugRicochetChance()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                CheckChanceToRicochet();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerGetDamage();
            }
        }
    }

}
