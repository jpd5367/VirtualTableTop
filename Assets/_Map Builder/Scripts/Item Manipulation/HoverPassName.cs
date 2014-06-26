using UnityEngine;
using System.Collections;

public class HoverPassName: MonoBehaviour {

	// Use this for initialization
	public void PassThisName(){
		if(gameObject.name == "Scale Icon"){
			GameObject.Find ("Main Camera").GetComponent<SelectItem>().SetModSelection(ModItemSelection.Scale);
		}
		if(gameObject.name == "Move Icon"){ 
			GameObject.Find ("Main Camera").GetComponent<SelectItem>().SetModSelection(ModItemSelection.Move);
		}
		if(gameObject.name == "Rotate Icon"){ 
			GameObject.Find ("Main Camera").GetComponent<SelectItem>().SetModSelection(ModItemSelection.Rotate);
		}
	}


}
