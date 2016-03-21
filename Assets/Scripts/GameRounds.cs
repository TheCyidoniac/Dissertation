using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRounds : MonoBehaviour {
	//The objects that the enemies are spawning on
	public List<GameObject> SpawnPoints = new List<GameObject>();
	public List<Spawning> SpawnCounters = new List<Spawning> ();
	public float time = 20;

	int currentRound = 1;

	bool complete = false;
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

		time = 20;

		for (int i = 0; i < SpawnPoints.Count; i++) {
			SpawnCounters.Add(SpawnPoints[i].GetComponent<Spawning> ());
		}
	}

	void Awake (){
		Application.targetFrameRate = 60;
	}

	void updateRound(){
		if (currentRound == 0) {
			time -= Time.deltaTime;
		}

		if (currentRound == 1) {
			for(int i = 0; i < SpawnCounters.Count; i++){
				SpawnCounters[i].maxSpawn = 1;
			}
			time -= Time.deltaTime;
		}

		if (currentRound == 2) {
			for(int i = 0; i < SpawnCounters.Count; i++){
				SpawnCounters[i].maxSpawn = 3;
			}
			time -= Time.deltaTime;
		}

	}

	void roundChanging(){
		if ((SpawnCounters [0].Finished == true) && (SpawnCounters [1].Finished == true) && (SpawnCounters [2].Finished == true) && (SpawnCounters [3].Finished == true)) {
			currentRound += 1;
			for(int i = 0; i < SpawnCounters.Count; i++){
				SpawnCounters [i].Finished = false;
			}
			time = 20;

		}

	}
	
	// Update is called once per frame
	void Update () {
		updateRound ();
		roundChanging ();
		Debug.Log (complete);
	
	} 	
}
