using UnityEngine;
using System.Collections;

public class NotifyFunction : MonoBehaviour {

	// Use this for initialization
	public void NotifyCloseScaleGUI(){
		GameObject.Find("Main Camera").GetComponent<SelectItem>().CloseScaleGUI();
		//DestroyObject(gameObject.transform.parent.gameObject);
	}

	public void NotifyCloseMoveGUI(){
		GameObject.Find("Main Camera").GetComponent<SelectItem>().CloseMoveGUI();
		//DestroyObject(gameObject.transform.parent.gameObject);
	}
}
