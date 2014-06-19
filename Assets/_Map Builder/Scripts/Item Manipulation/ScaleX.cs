﻿using UnityEngine;
using System.Collections;

public class ScaleX: MonoBehaviour {
	
	// Use this for initialization
	public GameObject selectedItem;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		selectedItem = GameObject.Find("Scale Controller").GetComponent<ScaleController>().target;
		if(selectedItem != null){
			Vector3 temp = selectedItem.transform.localScale;
			temp.x = gameObject.GetComponent<UISlider>().value * 8f;
			selectedItem.transform.localScale = temp;
		}
	}
}