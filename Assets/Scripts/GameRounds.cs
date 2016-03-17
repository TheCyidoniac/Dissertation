using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRounds : MonoBehaviour {
	//The objects that the enemies are spawning on
	public List<GameObject> SpawnPoints = new List<GameObject>();
	public List<Spawning> SpawnCounters = new List<Spawning> ();

	int time = 20;

	int currentRound = 1;
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

		for (int i = 0; i < SpawnPoints.Count; i++) {
			SpawnCounters.Add(SpawnPoints[i].GetComponent<Spawning> ());
			Debug.Log ("Worked");
		}
	}

	void updateRound(){
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
		if ((SpawnCounters [0].Finished == true) && (SpawnCounters [1].Finished == true) && (SpawnCounters [2].Finished == true) && (SpawnCounters [3].Finished == true)) {
			currentRound += 1;
		}
		for (int i = 0; i < SpawnCounters.Count; i++) {
			Debug.Log(SpawnCounters[i].Finished);
		}

	}
	
	// Update is called once per frame
	void Update () {
		updateRound ();
		roundChanging ();

	
	} 	
}
