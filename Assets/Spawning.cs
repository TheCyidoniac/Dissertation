using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	GameObject enemy = (GameObject)Instantiate (Resources.Load ("Enemy"));

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
