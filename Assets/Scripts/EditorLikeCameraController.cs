using UnityEngine;
using System.Collections;

public class EditorLikeCameraController : MonoBehaviour {

	// Use this for initialization
	public Camera camera;
	public GameObject cameraDolly;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt))&&Input.GetKey(KeyCode.Mouse0)){
			Debug.Log("Angling Camera");
			Vector3 tempRotation = cameraDolly.transform.rotation.eulerAngles;
			tempRotation.x -= Input.GetAxis("Mouse Y")*2f;
			tempRotation.y += Input.GetAxis("Mouse X")*2f;
			cameraDolly.transform.rotation = Quaternion.Euler(tempRotation);
		}


		if((Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt))&&Input.GetKey(KeyCode.Mouse1)){
			Debug.Log("Zooming Camera");
			Vector3 movement = cameraDolly.transform.position;
			Vector3 camEuler = camera.transform.rotation.eulerAngles;
			camEuler.y = 0f;
			camEuler.x = 0f;
			Quaternion normalizedRotation = Quaternion.Euler(camEuler);

			movement = (normalizedRotation.eulerAngles + Vector3.forward) *( (Input.GetAxis("Mouse Y")+Input.GetAxis("Mouse X"))/-2);

			cameraDolly.transform.position += movement;

		}

		if((Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt))&& Input.GetKey(KeyCode.Mouse2)){
			Debug.Log("Panning Camera");
			Vector3 tempPosition = cameraDolly.transform.position;
			tempPosition.x -= Input.GetAxis("Mouse X");
			tempPosition.y -= Input.GetAxis("Mouse Y");
			cameraDolly.transform.position = tempPosition;
		}

		if((Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt))&& Input.GetAxis("Mouse ScrollWheel") !=0f){
			Debug.Log("Zooming Camera");
		}
	}
}
