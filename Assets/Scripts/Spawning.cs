using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public float time = 5;
	public int maxSpawn = 5;
	public bool Finished = false;
	public int currentSpawned = 0;

	GameObject enemy;

	// Use this for initialization
	void Start () {
		enemy = (GameObject)(Resources.Load ("Enemy"));
	}

	void spawnEnemies(){
		if ((currentSpawned < maxSpawn) && (time < 0)){
			enemy.transform.position = gameObject.transform.position;
			Instantiate(enemy);
			currentSpawned += 1;
			Debug.Log(currentSpawned);
			time = 5;
		}
		if (currentSpawned == maxSpawn) {
			Finished = true;
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
