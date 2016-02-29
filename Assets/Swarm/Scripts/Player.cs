using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 0.2f;
	public int Health = 100;

	void movement (){
		Vector3 tempPos = transform.position;

		if (Input.GetButton ("Forward")) {
			tempPos.z += Speed * Time.deltaTime;
		}

		if (Input.GetButton ("Backward")) {
			tempPos.z -= Speed * Time.deltaTime;
		}

		if(Input.GetButton("Right")){
			tempPos.x += Speed * Time.deltaTime;
		}

		if(Input.GetButton("Left")){
			tempPos.x -= Speed * Time.deltaTime;
		}

		transform.position = tempPos;
	}
	
	void Update(){
		movement ();
	}
}
