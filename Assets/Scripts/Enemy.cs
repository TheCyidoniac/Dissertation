using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float movementSpeed = 1.5f;
	int damageTaken;
	Weapon playerWep;
	GameRounds spawnEnemy;

	public int health = 50;

	void lookatPlayer(){
		Vector3 character = GameObject.FindGameObjectWithTag ("Player").transform.position;
		Vector3 lookAt = new Vector3(character.x, character.y, character.z);
		lookAt.y = character.y;
		transform.LookAt(lookAt);
	}

	void chasePlayer(){
		Vector3 character = GameObject.FindGameObjectWithTag ("Player").transform.position;
		float step = movementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, character, step);
	}

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerWep = player.GetComponent<Weapon>();
		damageTaken = playerWep.damage;
	}
	
	// Update is called once per frame
	void Update () {
		lookatPlayer ();
		chasePlayer ();
	}
	
	void OnTriggerEnter(Collider col){
		health -= damageTaken;
		if (health <= 0) {
			Destroy (this.gameObject);
			spawnEnemy.SpawnCounters
		}
	}
}
