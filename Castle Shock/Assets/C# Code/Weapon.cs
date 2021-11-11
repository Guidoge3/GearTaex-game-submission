using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    //private Animator anim;


    public Transform firePoint;
    public GameObject bulletPrefab;

    private float reloadTime = 0.4f;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }


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
        //anim.SetBool("Fire", true);
    }
}
