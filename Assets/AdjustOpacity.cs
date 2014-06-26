using UnityEngine;
using System.Collections;

public class AdjustOpacity : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public Color32 texColor;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			target.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
			texColor = target.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
			texColor.a = (byte) (128.0); 
			target.GetComponentInChildren<SkinnedMeshRenderer>().material.color = texColor;
		}
		if(!Input.GetKey(KeyCode.A)){
			target.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Diffuse");
		}
	
	}
}
