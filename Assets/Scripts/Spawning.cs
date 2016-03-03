using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	float time = 5;

	GameObject enemy;
	public int maxSpawn = 5;
	int currentSpawned = 0;

	// Use this for initialization
	void Start () {
		enemy = (GameObject)(Resources.Load ("Enemy"));
		Instantiate (enemy);
	}

	void spawnEnemies(){
		if ((currentSpawned < maxSpawn) && (time < 0)){
			enemy.transform.position = gameObject.transform.position;
			Instantiate(enemy);
			currentSpawned += 1;
			time = 5;
		}
	}

	// Update is called once per frame
	void Update () {
		if(currentSpawned <= maxSpawn){
			time -= Time.deltaTime;
		}
		spawnEnemies ();
	}
}
