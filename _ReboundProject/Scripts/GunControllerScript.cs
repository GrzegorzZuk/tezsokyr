using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControllerScript : MonoBehaviour {

    public bool _isFiring;
    public BulletControllerScript bullet;
    public float speedBullet;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (_isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControllerScript newBullet =  Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletControllerScript;
                newBullet._speed = speedBullet;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
}
