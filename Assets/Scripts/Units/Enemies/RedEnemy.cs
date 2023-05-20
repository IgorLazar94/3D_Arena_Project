using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RedEnemy : GenericEnemy {

    private float heightToUp;
    private float timeToUp;
    private float flySpeed;
    private bool isReadyToFly = false;
    private new void Start()
    {
        base.Start();
        SetDefaultStates();
        currentHealthPoints = maxHealthPoints;
        StartEnemyRedBehaviour();
    }

    private void SetDefaultStates()
    {
        maxHealthPoints = GameSettings.Instance.GetMaxHealhRedEnemy();
        damage = GameSettings.Instance.GetDamageRedEnemy();
        rewardEnergy = GameSettings.Instance.GetRewardEnergyRed();
        heightToUp = GameSettings.Instance.GetHeightToUp();
        timeToUp = GameSettings.Instance.GetTimeToUp();
        flySpeed = GameSettings.Instance.GetFlySpeed();

    }

    private void StartEnemyRedBehaviour()
    {
        transform.DOMoveY(heightToUp, timeToUp).SetEase(Ease.Linear).OnComplete(() => isReadyToFly = true);
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        if (isReadyToFly)
        {
            FlyToPlayer();
        }

    }

    private void FlyToPlayer()
    {
        Vector3 direction = player.gameObject.transform.position - transform.position;
        float distance = direction.magnitude;
        Vector3 normalizedDirection = direction.normalized;
        Vector3 displacement = normalizedDirection * flySpeed * Time.deltaTime;

        if (displacement.magnitude >= distance)
        {
            transform.position = player.transform.position;
        }
        else
        {
            transform.position += displacement;
        }
    }

    private void RedEnemyFindPlayer(PlayerController player)
    {
        Debug.Log("red enemy find player");
        player.PlayerGetDamage();
        EnemyDie();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == TagList.Bullet)
        {
            EnemyGetDamage();
        }

        if (collision.gameObject.tag == TagList.Player)
        {
            RedEnemyFindPlayer(collision.GetComponent<PlayerController>());
        }
    }
}
