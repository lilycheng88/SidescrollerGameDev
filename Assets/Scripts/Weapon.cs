using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BulletNum.canShoot)
        {
            Shoot();
            BulletNum.scoreValue--;
        } else if (Input.GetKeyDown(KeyCode.Space) && !(BulletNum.canShoot))
        {
            Debug.Log("No Bullets");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
