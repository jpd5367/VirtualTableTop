using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width * .25f,Screen.width * .5f,100f, 100f), "Level Builder")){
			Application.LoadLevel("level builder");
		}
		if(GUI.Button(new Rect(Screen.width * .75f,Screen.width * .5f,100f, 100f), "Fog Of War")){
			Application.LoadLevel("fogOfWarTest");
		}
	}
}
