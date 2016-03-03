using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	GameObject enemy;
	public int maxSpawn = 5;
	int currentSpawned = 0;

	// Use this for initialization
	void Start () {
		enemy = (GameObject)Instantiate (Resources.Load ("Enemy"));
	}

	void spawnEnemies(){
		float distance = Vector3.Distance (enemy.transform.position, gameObject.transform.position); 
		if (currentSpawned < maxSpawn && distance > 5){
			Instantiate(enemy);
			currentSpawned += 1;
		}
	}

	// Update is called once per frame
	void Update () {
		spawnEnemies ();
	}
}
