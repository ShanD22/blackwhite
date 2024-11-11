using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretScript RightTurret;
    public TurretScript LeftTurret;
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public SpriteRenderer spriteRenderer;
    public float bulletSpeed = 10f; 
    public float fireRate = 1f; 
    private float nextFireTime = 0f; 
    public bool isFacingRight = true;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(isFacingRight == true)
        {
            spriteRenderer.color = RightTurret.Color;
        }
        else{
            spriteRenderer.color = LeftTurret.Color;
        }
    }
    void Update()
    {
     
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    void Shoot()
    {
        GameObject bullet = BulletFactory.GetBullet(isFacingRight);
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(isFacingRight ? bulletSpeed : -bulletSpeed, 0);
    }
}