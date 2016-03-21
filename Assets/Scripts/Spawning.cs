using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour {

	public float time = 5;
	public int maxSpawn = 0;
	public bool Finished = false;
	public int currentSpawned = 0;
	public GameObject spawnPoint;
	public bool stopSpawn = false;
	public List<GameObject> currentEnemies =  new List<GameObject> ();

	Enemy Help;
	GameObject enemy;

	// Use this for initialization
	void Start () {
		enemy = (GameObject)(Resources.Load ("Enemy"));
		spawnPoint = this.gameObject;
	}

	void spawnEnemies(){
		if ((currentSpawned < maxSpawn) && (time < 0) && stopSpawn == false){
			enemy.transform.position = gameObject.transform.position;
			Help = enemy.GetComponent<Enemy>();
			Help.spawnPoint = gameObject;
			Instantiate(enemy);
			currentEnemies.Add(this.gameObject);
			currentSpawned += 1;
			time = 5;
		}
		if (currentSpawned == maxSpawn){
			stopSpawn = true;
		}
		if(currentSpawned <= 0 && stopSpawn == true){
			Finished = true;
			Debug.Log (gameObject + " finished = " + Finished);
		}
	}

	// Update is called once per frame
	void Update () {
		if(currentSpawned <= maxSpawn){
			time -= Time.deltaTime;
		}
		Debug.Log (gameObject + " max spawn is " + maxSpawn);
		Debug.Log (gameObject + " the amount currently spawned is " + currentSpawned);
		spawnEnemies ();
	}
}
