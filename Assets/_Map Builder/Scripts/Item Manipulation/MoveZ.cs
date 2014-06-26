using UnityEngine;
using System.Collections;

public class MoveZ : MonoBehaviour {
	
	// Use this for initialization
	public UISlider zSlider; 
	public float zChange;
	public float maxSpeed = 1f;
	public GameObject target;
	
	void zChanged(){
		Debug.Log ("Finished adjusting Z Value");
		
		zSlider.value = .5f;
	}
	
	void Start () {
		
		zSlider.onDragFinished = new UIProgressBar.OnDragFinished(zChanged);
		zSlider.value = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		zChange = (zSlider.value - .5f) * 2 * maxSpeed;
		
		if(zChange != 0){
			Vector3 tempPos = target.transform.position;
			tempPos.z += zChange;
			target.transform.position = tempPos;
		}
		
		//		if(xChange > 0 && Time.frameCount % 30 == 0){
		//			Debug.Log("Moving Object in the Positive X Direction");
		//		}
		//		if(xChange < 0 && Time.frameCount % 30 == 0 ){
		//			Debug.Log("Moving Object in the Negative X Direction");
		//		}
		
	}
}
