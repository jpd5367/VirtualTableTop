using UnityEngine;
using System.Collections;

public class MoveX : MonoBehaviour {

	// Use this for initialization
	public UISlider xSlider; 
	public float xChange;
	public float maxSpeed = 1f;
	public GameObject target;

	void xChanged(){
		Debug.Log ("Finished adjusting X Value");

		xSlider.value = .5f;
	}

	void Start () {

		xSlider.onDragFinished = new UIProgressBar.OnDragFinished(xChanged);
		xSlider.value = .5f;
	}

	// Update is called once per frame
	void Update () {
		xChange = (xSlider.value - .5f) * 2 * maxSpeed;

		if(xChange != 0){
			Vector3 tempPos = target.transform.position;
			tempPos.x += xChange;
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
