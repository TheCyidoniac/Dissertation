using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	Vector3 tempPos = new Vector3();
	int bulletSpeed = 20;
	Vector3 character;


	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player").transform.position;

	}

	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (gameObject.transform.position, character);
		tempPos = gameObject.transform.position;
		tempPos -= (transform.forward * bulletSpeed) * Time.deltaTime;
		transform.position = tempPos;
		if (distance > 30) {
			Destroy(gameObject);
		}

	}
}
