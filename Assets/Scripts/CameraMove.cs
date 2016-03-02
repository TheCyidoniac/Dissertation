using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform cameraTrans;
	Vector3 cameraTemp = new Vector3();

	// Update is called once per frame
	void Update () {
		cameraTemp = transform.position;
		cameraTemp = cameraTrans.position;
		cameraTemp.y += 7.2f;
		transform.position = cameraTemp;
	}
}
