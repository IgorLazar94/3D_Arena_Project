using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Unit
{

    [SerializeField] private int maxEnergy;
    [SerializeField] private PlayerProjectile bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Camera cameraObject;
    [SerializeField] private Transform projectileContainer;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemiesSpawner enemiesSpawner;
    private int currentHealthPoints;
    private int currentEnergy;
    private float bulletSpeed = 50.0f;
    private bool isReadyToShoot = true;
    private Rigidbody playerBody;
    private float playerReloadTime;
    private float arenaRadius = 23f;

    public static System.Action<Transform> onPlayerTeleported;
    private void Start()
    {
        SetDefaultStats();
        playerBody = GetComponent<Rigidbody>();
        uiManager.UpdateHealthBar(currentHealthPoints);
        uiManager.UpdateEnergyBar(currentEnergy);


    }



    private void SetDefaultStats()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxPlayerHealth();
        maxEnergy = GameSettings.Instance.GetMaxEnergy();
        damage = GameSettings.Instance.GetDamagePlayer();
        bulletSpeed = GameSettings.Instance.GetPlayerBulletSpeed();
        playerReloadTime = GameSettings.Instance.GetPlayerReloadTime();
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
        yield return new WaitForSeconds(playerReloadTime);
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
        playerBody.isKinematic = false;
        playerBody.useGravity = true;
        playerBody.AddForce(Vector3.back * 5, ForceMode.Impulse);
        StartCoroutine(EnableLoseState());
    }

    private IEnumerator EnableLoseState()
    {
        yield return new WaitForSeconds(1.0f);
        uiManager.EnableLosePanel();
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
        Debug.Log("use ultimate");
        if (currentEnergy >= maxEnergy)
        {
            uiManager.ShowUltimateEffect();
            enemiesSpawner.DestroyAllEnemies();
            currentEnergy = 0;
            uiManager.UpdateEnergyBar(0f);
            gameManager.VisualHit();
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


    private void DebugTesting()
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
            if (Input.GetKeyDown(KeyCode.T))
            {
                TeleportPlayer();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                UpdateEnergy(25);
            }
        }
    }

    Vector3 GetRandomPointInRadius(Vector3 center, float radius)
    {
        Vector2 randomPoint2D = Random.insideUnitCircle * radius;
        Vector3 randomPoint = new Vector3(randomPoint2D.x, 0f, randomPoint2D.y);
        randomPoint = center + randomPoint;

        while (Physics.CheckSphere(randomPoint, 0.1f, LayerMask.NameToLayer("Obstacle")))
        {
            randomPoint2D = Random.insideUnitCircle * radius;
            randomPoint = new Vector3(randomPoint2D.x, 1f, randomPoint2D.y);
            randomPoint = center + randomPoint;
        }

        return randomPoint;
    }

    private void Update()
    {
        DebugTesting();   // Disable (!!!)
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distanceToArenaCenter = Vector3.Distance(transform.position, Vector3.zero);
        if (distanceToArenaCenter > arenaRadius)
        {
            CheckEnemyDistance();
            TeleportPlayer();
        }
    }
    private void TeleportPlayer()
    {
        onPlayerTeleported.Invoke(transform);
        Vector3 newPlayerPos = GetRandomPointInRadius(Vector3.zero, arenaRadius);
        transform.position = newPlayerPos;
    }

    private void CheckEnemyDistance()
    {
        var enemies = enemiesSpawner.genericEnemiesList;
        for (int i = 0; i < enemies.Count; i++)
        {
            float distanceToEnemy = Vector3.Distance(enemies[i].gameObject.transform.position, transform.position);
            if (distanceToEnemy > 6f)
            {
                return;
            }
            else
            {
                Debug.LogWarning("Enemy close to teleport");
            }
        }
    }
}
