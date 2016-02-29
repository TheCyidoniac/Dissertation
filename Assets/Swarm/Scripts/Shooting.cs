using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	 
	float bulletSpeed = 20.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if( Physics.Raycast(ray, out hit))
			{
				Debug.Log("HELP");
				Vector3 newpoint = hit.point;
				Debug.DrawLine(transform.position, newpoint, Color.red);
				transform.position = Vector3.MoveTowards(transform.position, newpoint, Time.deltaTime * bulletSpeed);
				//transform.position = Vector3.MoveTowards(transform.position, newpoint, Time.deltaTime * bulletSpeed);

			}

		}
	}
}
