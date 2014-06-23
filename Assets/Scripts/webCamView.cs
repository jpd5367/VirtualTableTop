using UnityEngine;
using System.Collections;

public class webCamView : MonoBehaviour {

	// Use this for initialization
	public WebCamTexture webcamTexture;
	public float windowWidth;
	public float windowHeight;

	void Start () {
		Debug.Log (WebCamTexture.devices.Length);
		for(int i = 0; i < WebCamTexture.devices.Length; i++){
			Debug.Log (WebCamTexture.devices[i].name);
		}

		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture();
		if(devices.Length > 0){
			webcamTexture.deviceName = devices[0].name;
			//renderer.material.mainTexture = webcamTexture;

			webcamTexture.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		windowHeight = Screen.height *.25f;
		windowWidth = ((Screen.height *.25f)*16f)/9f;
		GUI.DrawTexture(new Rect(0, 0f,windowWidth , windowHeight),GetComponent<NetworkManagerScript>().Player1Cam);
		GUI.DrawTexture(new Rect(0.0f,Screen.height - windowHeight,windowWidth , windowHeight),GetComponent<NetworkManagerScript>().Player2Cam);

		GUI.DrawTexture(new Rect((Screen.width/2) - (windowWidth /2), 0f, windowWidth , windowHeight),GetComponent<NetworkManagerScript>().DMCam);

		GUI.DrawTexture(new Rect(Screen.width - windowWidth, 0f,windowWidth , windowHeight),GetComponent<NetworkManagerScript>().Player3Cam);
		GUI.DrawTexture(new Rect(Screen.width - windowWidth, Screen.height - windowHeight, windowWidth , windowHeight),GetComponent<NetworkManagerScript>().Player4Cam);

		
	}
}
