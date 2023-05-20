using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueProjectile : MonoBehaviour
{
    private PlayerController playerController;
    private bool isReadyToFly = false;
    private float flySpeed;
    private int energyDamage;


    private void Start()
    {
        flySpeed = GameSettings.Instance.GetFlySpeedBlueProjectile();
        energyDamage = GameSettings.Instance.GetEnergyDamage();
    }

    public void SetPlayer(PlayerController _playerController)
    {
        playerController = _playerController;
        isReadyToFly = true;
    }

    private void FixedUpdate()
    {
        if (isReadyToFly)
        {
            FlyToPlayer();
        }
    }

    private void FlyToPlayer()
    {
        Vector3 direction = playerController.gameObject.transform.position - transform.position;
        float distance = direction.magnitude;
        Vector3 normalizedDirection = direction.normalized;
        Vector3 displacement = normalizedDirection * flySpeed * Time.deltaTime;

        if (displacement.magnitude >= distance)
        {
            transform.position = playerController.transform.position;
        }
        else
        {
            transform.position += displacement;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagList.Player)
        {
            Debug.Log("blue bullet Trigger");
            other.gameObject.GetComponent<PlayerController>().UpdateEnergy(-energyDamage);
            DestroyBullet();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == TagList.Player)
    //    {
    //        Debug.Log("blue bullet Collision");
    //        collision.gameObject.GetComponent<PlayerController>().UpdateEnergy(-energyDamage);
    //        DestroyBullet();
    //    }
    //}

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
