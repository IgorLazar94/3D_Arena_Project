using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public bool isReadyForDoubleKill { get; private set; }
    private bool chanceToRicochet;
    private Rigidbody bulletBody;
    private float bulletSpeed;

    private void Start()
    {
        isReadyForDoubleKill = false;
        Invoke("DestroyProjectile", 5.0f); // ???
        bulletBody = gameObject.GetComponent<Rigidbody>();
    }


    public void SetBulletSpeed(float _bulletSpeed)
    {
        bulletSpeed = _bulletSpeed;
    }

    public bool GetChanceToRicochet()
    {
        return chanceToRicochet;
    }

    public void SetChanceToRicochet(bool value)
    {
        chanceToRicochet = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagList.Environment)
        {
            if (GetChanceToRicochet())
            {
                ChooseRandomDirection();
            }
            else
            {
                DestroyProjectile();
            }
        }
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    public void ChooseRandomDirection()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        bulletBody.AddForce(randomDirection * bulletSpeed, ForceMode.Impulse);
        isReadyForDoubleKill = true;
    }
}
