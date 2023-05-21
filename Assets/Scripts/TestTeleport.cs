using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeleport : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private PlayZone playZone;
    [SerializeField] private GameObject Sphere;
    private int maxAttempts = 10;

    private void Start()
    {

        //StartCoroutine(TESTO());
    }

    //private IEnumerator TESTO()
    //{

    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        Vector3 randomPoint = GetRandomPointInRadius(playZone.transform.position, 22f);
    //        Instantiate(Sphere, randomPoint, Quaternion.identity);
    //    }

    //}

    //Vector3 GetRandomPointInRadius(Vector3 center, float radius)
    //{
    //    int attempts = 0;
    //    Vector3 randomPoint = center;
    //    float maxDistance = 0f;

    //    // Выбор точки, максимально отдаленной от объектов Enemy
    //    while (attempts < maxAttempts)
    //    {
    //        Vector2 randomPoint2D = Random.insideUnitCircle * radius;
    //        Vector3 candidatePoint = center + new Vector3(randomPoint2D.x, 25f, randomPoint2D.y);

    //        // Проверка, что точка не находится в пределах коллайдера другого объекта
    //        if (!Physics.CheckSphere(candidatePoint, 5f, LayerMask.NameToLayer("Obstacle")))
    //        {
    //            // Проверка, что точка максимально отдалена от объектов Enemy
    //            float distance = GetMinDistanceToEnemy(candidatePoint);
    //            if (distance > maxDistance)
    //            {
    //                maxDistance = distance;
    //                randomPoint = candidatePoint;
    //            }
    //        }

    //        attempts++;
    //    }

    //    return randomPoint;
    //}

    float GetMinDistanceToEnemy(Vector3 point)
    {
        Collider[] enemyColliders = Physics.OverlapSphere(point, 25f, LayerMask.NameToLayer("Enemy"));
        float minDistance = Mathf.Infinity;

        foreach (Collider enemyCollider in enemyColliders)
        {
            float distance = Vector3.Distance(point, enemyCollider.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }

        return minDistance;
    }



















































    


















































}
