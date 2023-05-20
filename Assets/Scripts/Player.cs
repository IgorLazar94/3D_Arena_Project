using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Player : Unit {

	[SerializeField] private int maxEnergy;
	[SerializeField] private Projectile bulletPrefab;
	[SerializeField] private Transform bulletSpawnPos;
	[SerializeField] private Camera cameraObject;
	[SerializeField] private Transform gun;
	private int currentHealthPoints;
	private int currentEnergy;
	private float bulletSpeed = 50.0f;

	 private void Start()
	{
		SetDefaultStats();
    }

	private void SetDefaultStats()
	{
		maxHealthPoints = GameSettings.Instance.GetMaxPlayerHealth();
		maxEnergy = GameSettings.Instance.GetMaxEnergy();
		damage = GameSettings.Instance.GetDamagePlayer();
        currentHealthPoints = maxHealthPoints;
		currentEnergy = maxEnergy / 2;
    }


	public void Shoot()
	{
		Vector3 shootDirection = bulletSpawnPos.position - cameraObject.transform.position;
		//var rightCorner = Quaternion.Euler(new Vector3(gun.position.x, gun.transform.position.y, gun.transform.position.z));
		var bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity, transform);
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * bulletSpeed, ForceMode.Impulse);
		bullet.transform.parent = null;
    }

	public void UpdateEnergy(int bonusEnergy)
	{
		currentEnergy += bonusEnergy;
		currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
	}

}
