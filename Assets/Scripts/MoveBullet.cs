using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	Vector3 tempPos = new Vector3();
	int bulletSpeed = 20;
	Vector3 character;
	GameObject player;


	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player").transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		Physics.IgnoreCollision (player.GetComponent<Collider> (), GetComponent<Collider> ());
		float distance = Vector3.Distance (gameObject.transform.position, character);
		tempPos = gameObject.transform.position;
		tempPos -= (transform.forward * bulletSpeed) * Time.deltaTime;
		transform.position = tempPos;
		if (distance > 30) {
			Destroy(gameObject);
		}

	}
}
