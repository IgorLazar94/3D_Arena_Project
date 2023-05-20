using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyProjectile", 5.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagList.Environment)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
