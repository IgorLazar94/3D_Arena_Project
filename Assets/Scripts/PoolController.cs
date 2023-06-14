using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    private int poolCount;
    private bool autoExpand;
    private PlayerProjectile playerBulletPrefab;

    private BulletPool<PlayerProjectile> pool;

    private void Start()
    {
        GetSettingsValues();
        this.pool = new BulletPool<PlayerProjectile>(playerBulletPrefab, poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }
    private void GetSettingsValues()
    {
        poolCount = GameSettings.Instance.GetPoolCount();
        autoExpand = GameSettings.Instance.GetPoolAutoExpand();
        playerBulletPrefab = GameSettings.Instance.GetPlayerBulletPrefab();
    }

    public PlayerProjectile CreateBullet()
    {
        var bullet = this.pool.GetFreeElement();
        return bullet;
    }




}
