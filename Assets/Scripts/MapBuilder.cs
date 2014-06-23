using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBuilder:ScriptableObject {
	public static Dictionary<string, GameObject> tiles;

	void OnEnable(){
		tiles = new Dictionary<string, GameObject>();
		tiles.Add("5,0,0", GameObject.Find("5,0,0"));
	}

}
