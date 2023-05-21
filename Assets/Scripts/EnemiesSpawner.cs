using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public List<GenericEnemy> genericEnemiesList = new List<GenericEnemy>();
    [SerializeField] private BlueEnemy blueEnemy;
    [SerializeField] private RedEnemy redEnemy;
    private int killedEnemyCount;
    private int timeToSpawnEnemy;
    private int limitToSpawnEnemy;
    private int countToSpawnEnemy;

    private void Start()
    {
        killedEnemyCount = 0;
        countToSpawnEnemy = 1;
        timeToSpawnEnemy = GameSettings.Instance.GetTimeToSpawnEnemy();
        limitToSpawnEnemy = GameSettings.Instance.GetLimitToSpawnEnemy();
        StartCoroutine(InitializeEnemies());
    }

    public int GetKilledEnemiesCount()
    {
        return killedEnemyCount;
    }

    public void AddKilledEnemyCount()
    {
        killedEnemyCount++;
    }

    private IEnumerator InitializeEnemies()
    {
        while (true)
        {

            yield return new WaitForSeconds(timeToSpawnEnemy);
            if (timeToSpawnEnemy > limitToSpawnEnemy)
            {
                timeToSpawnEnemy--;
                CreateOneEnemy();
            }
            else
            {
                for (int i = 0; i < countToSpawnEnemy; i++)
                {
                    CreateOneEnemy();
                    countToSpawnEnemy++;
                }
            }
        }
    }

    private void CreateOneEnemy()
    {
        Vector3 randomPos = GetRandomPointInRadius(Vector3.zero, 23f);
        int randomNubmer = Random.Range(1, 3);
        if (randomNubmer > 1 && !HasEnoughBlueEnemies())
        {
            var enemy = Instantiate(blueEnemy, randomPos, Quaternion.identity);
            enemy.SetLinkEnemySpawner(this);
            genericEnemiesList.Add(enemy);
        }
        else
        {
            var enemy = Instantiate(redEnemy, randomPos, Quaternion.identity);
            genericEnemiesList.Add(enemy);
        }

    }

    private bool HasEnoughBlueEnemies()
    {
        int counter = 0;
        for (int i = 0; i < genericEnemiesList.Count; i++)
        {
            if (genericEnemiesList[i].GetComponent<BlueEnemy>())
            {
                counter++;
            }
        }
        if (counter > (genericEnemiesList.Count / 4))
        {
            return true;
        }
        else
        {
            return false;
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
    public void DestroyAllEnemies()
    {
        for (int i = 0; i < genericEnemiesList.Count; i++)
        {
            genericEnemiesList[i].EnemyDieFromPlayer();
        }
    }

}
