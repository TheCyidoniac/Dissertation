using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject bullet;
	public float Speed = 0.2f;
	public int Health = 3;
	public float bulletSpeed = 20.0f;
	

	Spawning roundReset;
	Enemy killEnemies;

	Vector3 tempBulPos = new Vector3();
	Vector3 startPosition;

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
		startPosition = gameObject.transform.position;
	}

	void OnDeath(){
		if (Health > 0) {
			gameObject.transform.position = startPosition;
			roundReset.currentSpawned = 0;
			roundReset.Finished = false;
			roundReset.stopSpawn = false;
			killEnemies.playerDied = true;
			roundReset.time = 5.0f;
			for(int i = 0; i < roundReset.currentEnemies.Count; i++){
				Debug.Log("Got Here");
				Destroy(roundReset.currentEnemies[i]);
			}
		}
		Debug.Log ("DEAD!");
	}


	void Update(){
		movement ();
		lookat ();
		if (Input.GetButtonDown ("Fire1")) {
			onShoot();
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col);
		Health -= 1;
		OnDeath();
		Debug.Log (Health);
	}
}
