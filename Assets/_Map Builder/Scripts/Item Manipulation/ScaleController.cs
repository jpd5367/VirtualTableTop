using UnityEngine;
using System.Collections;

public class ScaleController : MonoBehaviour {

	public GameObject target;

	void Start(){
		GameObject.Find ("Back").GetComponent<UIButton>().enabled = true;
	}

	public void SetObject(GameObject x){

	}

	void Update () {

		if(gameObject.GetComponent<UIToggle>().value == true){
			GameObject.Find ("Scale All").GetComponent<ScaleAll>().enabled = false;
			GameObject.Find ("Scale All").GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale All").GetComponent<UISlider>().enabled = false;
			GameObject.Find ("Scale All").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale All").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = false;
			GameObject.Find ("Scale X").GetComponent<ScaleX>().enabled = true;
			GameObject.Find ("Scale X").GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale X").GetComponent<UISlider>().enabled = true;
			GameObject.Find ("Scale X").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale X").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = true;
			GameObject.Find ("Scale Y").GetComponent<ScaleY>().enabled = true;
			GameObject.Find ("Scale Y").GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale Y").GetComponent<UISlider>().enabled = true;
			GameObject.Find ("Scale Y").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale Y").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = true;
			GameObject.Find ("Scale Z").GetComponent<ScaleZ>().enabled = true;
			GameObject.Find ("Scale Z").GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale Z").GetComponent<UISlider>().enabled = true;
			GameObject.Find ("Scale Z").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale Z").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = true;
		}
		else{
			GameObject.Find ("Scale All").GetComponent<ScaleAll>().enabled = true;
			GameObject.Find ("Scale All").GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale All").GetComponent<UISlider>().enabled = true;
			GameObject.Find ("Scale All").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = true;
			GameObject.Find ("Scale All").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = true;
			GameObject.Find ("Scale X").GetComponent<ScaleX>().enabled = false;
			GameObject.Find ("Scale X").GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale X").GetComponent<UISlider>().enabled = false;
			GameObject.Find ("Scale X").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale X").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = false;
			GameObject.Find ("Scale Y").GetComponent<ScaleY>().enabled = false;
			GameObject.Find ("Scale Y").GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale Y").GetComponent<UISlider>().enabled = false;
			GameObject.Find ("Scale Y").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale Y").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = false;
			GameObject.Find ("Scale Z").GetComponent<ScaleZ>().enabled = false;
			GameObject.Find ("Scale Z").GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale Z").GetComponent<UISlider>().enabled = false;
			GameObject.Find ("Scale Z").transform.FindChild("Thumb").gameObject.GetComponent<UISprite>().enabled = false;
			GameObject.Find ("Scale Z").transform.FindChild("Thumb").gameObject.GetComponent<UIButton>().enabled = false;
		}
	}

	void OnDisable(){
		//GameObject.Find ("Back").GetComponent<UIButton>().enabled = false;
	}

}
