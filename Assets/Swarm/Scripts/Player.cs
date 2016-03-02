using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 0.2f;
	public int Health = 100;
	public float bulletSpeed = 20.0f;

	void movement (){
		Vector3 tempPos = transform.position;

		if (Input.GetButton ("Forward")) {
			tempPos += (-transform.forward * Speed) * Time.deltaTime;
		}

		if (Input.GetButton ("Backward")) {
			tempPos -= (transform.forward * Speed) * Time.deltaTime;
		}
		if(Input.GetButton("Right")){
			tempPos += (transform.right * Speed) * Time.deltaTime;
		}
		if(Input.GetButton("Left")){
			tempPos -= (-transform.right * Speed) * Time.deltaTime;
		}
		transform.position = tempPos;
	}

	void lookat (){

		Vector3 lookAt = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position - Camera.main.transform.position).magnitude));
		lookAt.y = transform.position.y;  // Set it to the players height to avoid any non-y rotations
		transform.LookAt(lookAt);

	}

	void onShoot(){
		Instantiate (GameObject.Find("Bullet"));
		Vector3 tempBulPos = new Vector3();
		tempBulPos = transform.position;
		tempBulPos += transform.forward * bulletSpeed;
	}


	void Start(){
	}

	void Update(){
		movement ();
		lookat ();
		if (Input.GetButtonDown ("Fire1")) {
			onShoot();
		}

	}
}
