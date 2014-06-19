using UnityEngine;
using System.Collections;

public class ScaleAll : MonoBehaviour {

	// Use this for initialization
	public GameObject selectedItem;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		selectedItem = GameObject.Find("Scale Controller").GetComponent<ScaleController>().target;
		if(selectedItem != null){
			selectedItem.transform.localScale = gameObject.GetComponent<UISlider>().value * Vector3.one *8f;
		}
	}
}
