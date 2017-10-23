using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController2Script : MonoBehaviour {

    public LayerMask collisionMask;

    //public Transform blade;
    public float _speed;
    //public float rotSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
        //Move the bullet farwards
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        //Rotate the blade
        //blade.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
		
        if (Physics.Raycast(ray, out hit, Time.deltaTime * _speed , collisionMask))
        {
            Vector3 reflectDirection = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDirection.z, reflectDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
	}
}
