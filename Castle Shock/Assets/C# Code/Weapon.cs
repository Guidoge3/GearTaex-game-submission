using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float reloadTime = 0.4f;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && reloadTime <= 0)
        {
            Shoot();
            reloadTime = 0.25f;
        }
        reloadTime -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
