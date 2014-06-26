using UnityEngine;
using System.Collections;

public class RotateY : MonoBehaviour {
	
	// Use this for initialization
	public UISlider ySlider; 
	public float yChange;
	public float maxSpeed = 1f;
	public GameObject target;
	
	void yChanged(){
		Debug.Log ("Finished adjusting Y Value");
		
		ySlider.value = .5f;
	}
	
	void Start () {
		
		ySlider.onDragFinished = new UIProgressBar.OnDragFinished(yChanged);
		ySlider.value = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		yChange = (ySlider.value - .5f) * 2 * maxSpeed;
		
		if(yChange != 0){
			target.transform.Rotate(Vector3.up, yChange);
		}
		
		//		if(xChange > 0 && Time.frameCount % 30 == 0){
		//			Debug.Log("Moving Object in the Positive X Direction");
		//		}
		//		if(xChange < 0 && Time.frameCount % 30 == 0 ){
		//			Debug.Log("Moving Object in the Negative X Direction");
		//		}
		
	}
}
