using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2Script : MonoBehaviour {

    public GameObject bullet;

    private Camera _cam;
    public float _speed;

	// Use this for initialization
	void Start () {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //Get the cursosr position in world coordinates
        Vector3 m = Input.mousePosition;
        m = _cam.ScreenToWorldPoint(new Vector3(m.x, m.y, 9.5f));
        //Rotate player to face the cursor
        transform.LookAt(m);
        //Move the player farwards when there is input on the vertical axis
        transform.Translate(Vector3.forward * _speed * Time.deltaTime * Input.GetAxisRaw("Vertical"), Space.Self);

        //If lpm is pressed, spawn a bullet with the same rotation as the player's
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
	}

}
