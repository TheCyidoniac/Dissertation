using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRounds : MonoBehaviour {
	//The objects that the enemies are spawning on
	List<GameObject> SpawnPoints = new List<GameObject>();
	List<Spawning> SpawnCounters = new List<Spawning> ();

	int time = 20;

	int currentRound;
	// Use this for initialization
	void Start () {
		GameObject spawnPointOne = GameObject.Find ("SpawnOne");
		GameObject spawnPointTwo = GameObject.Find ("SpawnTwo");
		GameObject spawnPointThree = GameObject.Find ("SpawnThree");
		GameObject spawnPointFour = GameObject.Find ("SpawnFour");

		SpawnPoints.Add (spawnPointOne);
		SpawnPoints.Add (spawnPointTwo);
		SpawnPoints.Add (spawnPointThree);
		SpawnPoints.Add (spawnPointFour);
	}

	void updateRound(){
		for (int i = 0; i < SpawnPoints.Count; i ++) {
			SpawnCounters[i] = SpawnPoints[i].GetComponent<Spawning> ();
		}

		if (currentRound == 1) {
			for(int i = 0; i < SpawnCounters.Count; i++){
				SpawnCounters[i].maxSpawn = 2;
			}
		}

		if (currentRound == 2) {
			for(int i = 0; i < SpawnCounters.Count; i++){
				SpawnCounters[i].maxSpawn = 3;
			}
		}

	}

	void roundChanging(){
		for (int i = 0; i < SpawnCounters.Count;) {
			if (SpawnCounters[i].Finished == true) {
				i++;
			}
		}
		currentRound += 1;

	}
	
	// Update is called once per frame
	void Update () {


	
	} 	
}
