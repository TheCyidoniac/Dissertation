using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	 
	float bulletSpeed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}

	void onFire(){
		Instantiate (gameObject);
		Vector3 tempPos = new Vector3();
		tempPos = transform.position;
		tempPos += transform.forward * bulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			onFire();
		}
			/*RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if( Physics.Raycast(ray, out hit))
			{
				Vector3 newpoint = hit.point;
				Debug.DrawLine(transform.position, newpoint, Color.red);
				transform.position = Vector3.MoveTowards(transform.position, newpoint, Time.deltaTime * bulletSpeed);
				}*/
		}
}

