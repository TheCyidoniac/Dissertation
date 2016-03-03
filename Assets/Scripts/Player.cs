using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject bullet;
	public float Speed = 0.2f;
	public int Health = 100;
	public float bulletSpeed = 20.0f;

	Vector3 tempBulPos = new Vector3();
	GameObject Bullet;

	void movement (){
		Vector3 tempPos = transform.position;

		if (Input.GetButton ("Forward")) {
			tempPos -= (transform.forward * Speed) * Time.deltaTime;
		}

		if (Input.GetButton ("Backward")) {
			tempPos +=(transform.forward * Speed) * Time.deltaTime;
		}
		transform.position = tempPos;
	}

	void lookat (){
		Vector3 lookAt = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position - Camera.main.transform.position).magnitude));
		lookAt.y = transform.position.y;
		transform.LookAt(lookAt);
	}

	void onShoot(){
		Instantiate (bullet);
		tempBulPos = gameObject.transform.position;
		bullet.transform.position = tempBulPos;
		Vector3 lookAt = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position - Camera.main.transform.position).magnitude));
		lookAt.y = bullet.transform.position.y;
		bullet.transform.LookAt(lookAt);

	}


	void Start(){
		Bullet = (GameObject) (Resources.Load ("Bullet"));
	}

	void Update(){
		movement ();
		lookat ();
		if (Input.GetButtonDown ("Fire1")) {
			onShoot();
		}

	}
}
