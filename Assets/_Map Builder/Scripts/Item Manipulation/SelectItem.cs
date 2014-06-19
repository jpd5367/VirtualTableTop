using UnityEngine;
using System.Collections;

public enum ModItemSelection{
	None,
	Scale,
	Move
}

public class SelectItem : MonoBehaviour {

	public GameObject currentSelection;
	public GameObject lastSelection;
	public GameObject selectionMenu;
	public GameObject menu;
	public GameObject ScaleGUI;
	public GameObject MoveGUI;
	public GameObject Scaley;

	public Vector3 selectionPos;

	RaycastHit hit;
	Ray ray;
	public bool itemSelected;
	public bool optionSelected;
	public bool menuOpen;
	public bool ScaleGUISelected;
	public bool MoveGUISelected;


	public ModItemSelection modSelected;
	// Use this for initialization
	void Start () {
		modSelected = ModItemSelection.None;
		ScaleGUISelected = false;
		MoveGUISelected  = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempPos = Vector3.one;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetMouseButtonDown(0)){
			Physics.Raycast(ray,out hit, Mathf.Infinity);
			UISprite[] components;
			components = hit.collider.gameObject.GetComponents<UISprite>();

			if(components.Length == 0){
				currentSelection = hit.collider.gameObject;
				lastSelection = currentSelection;
				selectionPos = currentSelection.transform.position;
				itemSelected = true;
			}
		}
		else if(Input.GetMouseButton(0)&&itemSelected == true){
			itemSelected = true;
		}
		else{  
			itemSelected = false;
			currentSelection = null;
		}

//		if(itemSelected == true && Input.GetMouseButtonUp(0)){
//			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			if(Input.GetMouseButtonUp(0)){
//				Physics.Raycast(ray,out hit, Mathf.Infinity);
//				optionSelection = hit.collider.gameObject;
//				optionSelected = true;
//			}
//			SetModSelection();
//		}
//
		if(itemSelected == true && Input.GetMouseButtonDown(0)){
			OpenOptions();

		}

		if(menuOpen && !Input.GetMouseButton(0)){
			CloseOptions();
		}

		if(optionSelected){
			OpenSelectionGUI();
		}
		if(itemSelected && menu.transform.position != tempPos){
			//	menu.transform.position = selectionPos;
			tempPos = GameObject.FindWithTag("UI Camera").GetComponent<Camera>().ScreenToWorldPoint(GameObject.Find("Main Camera").camera.WorldToScreenPoint(selectionPos));
			tempPos.z = 0f;
			menu.transform.position = tempPos;
		}

	}

	public void OpenOptions(){
		Vector3 tempPos = currentSelection.transform.position;
		menuOpen = true;
		menu = Instantiate(selectionMenu, GameObject.FindWithTag("UI Camera").GetComponent<Camera>().ScreenToWorldPoint(GameObject.Find("Main Camera").camera.WorldToScreenPoint(selectionPos)), Quaternion.identity) as GameObject;
		menu.transform.position = GameObject.FindWithTag("UI Camera").GetComponent<Camera>().ScreenToWorldPoint(GameObject.Find("Main Camera").camera.WorldToScreenPoint(selectionPos));
	}

	public void SetModSelection(ModItemSelection x){
		Debug.Log ("Setting Mod Choice");
		modSelected = x;
		optionSelected = true;
	}

	public void CloseOptions(){
		Destroy (menu);
		menuOpen = false;
	}

	public void OpenSelectionGUI(){
		if(optionSelected && modSelected == ModItemSelection.Scale && ScaleGUISelected != true){// display scale adjustment GUI
			Debug.Log ("Scale Gui");
			Scaley = GameObject.Instantiate(ScaleGUI) as GameObject;
			ScaleGUISelected = true;
			GameObject.Find ("Scale Controller").GetComponent<ScaleController>().target = lastSelection;
		}

		if(optionSelected && modSelected == ModItemSelection.Move){// display position adjustment GUI
			Debug.Log ("Move Gui");
		}

	}

	public void CloseScaleGUI(){
		Debug.Log ("Closing Scale GUI");
		optionSelected = false;
		DestroyObject(Scaley);
		Scaley = null;
		ScaleGUISelected = false;
	}


}
