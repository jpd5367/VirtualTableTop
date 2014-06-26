using UnityEngine;
using System.Collections;

public enum ModItemSelection{
	None,
	Scale,
	Move,
	Rotate
}

public class SelectItem : MonoBehaviour {

	public GameObject currentSelection;
	public GameObject lastSelection;
	public GameObject selectionMenu;
	public GameObject menu;
	public GameObject ScaleGUI;
	public GameObject MoveGUI;
	public GameObject RotateGUI;
	public GameObject Scaley;
	public GameObject Movey;
	public GameObject Rotatey;

	public Vector3 selectionPos;

	RaycastHit hit;
	Ray ray;
	public bool itemSelected;
	public bool optionSelected;
	public bool menuOpen;
	public bool ScaleGUISelected;
	public bool MoveGUISelected;
	public bool RotateGUISelected;


	public ModItemSelection modSelected;
	// Use this for initialization
	void Start () {
		modSelected = ModItemSelection.None;
		ScaleGUISelected = false;
		MoveGUISelected  = false;
		RotateGUISelected  = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempPos = Vector3.one;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetMouseButtonDown(0)){
			Physics.Raycast(ray,out hit, Mathf.Infinity);
			if(hit.collider != null){
				UISprite[] components = hit.collider.gameObject.GetComponents<UISprite>();
			

				if(components.Length == 0){
					currentSelection = hit.collider.gameObject;
					lastSelection = currentSelection;
					selectionPos = currentSelection.transform.position;
					itemSelected = true;
				}
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

			Scaley = GameObject.Instantiate(ScaleGUI) as GameObject;
			ScaleGUISelected = true;
			GameObject.Find ("Scale Controller").GetComponent<ScaleController>().target = lastSelection;
		}

		if(optionSelected && modSelected == ModItemSelection.Move && MoveGUISelected != true){// display scale adjustment GUI

			Movey = GameObject.Instantiate(MoveGUI) as GameObject;
			MoveGUISelected = true;
			GameObject.Find ("Move X").GetComponent<MoveX>().target = lastSelection;
			GameObject.Find ("Move Y").GetComponent<MoveY>().target = lastSelection;
			GameObject.Find ("Move Z").GetComponent<MoveZ>().target = lastSelection;
		}

		if(optionSelected && modSelected == ModItemSelection.Rotate && RotateGUISelected != true){// display scale adjustment GUI
			
			Rotatey = GameObject.Instantiate(RotateGUI) as GameObject;
			RotateGUISelected = true;
			GameObject.Find ("Rotate X").GetComponent<RotateX>().target = lastSelection;
			GameObject.Find ("Rotate Y").GetComponent<RotateY>().target = lastSelection;
			GameObject.Find ("Rotate Z").GetComponent<RotateZ>().target = lastSelection;
		}


	}

	public void CloseScaleGUI(){
		Debug.Log ("Closing Scale GUI");
		optionSelected = false;
		DestroyObject(Scaley);
		Scaley = null;
		ScaleGUISelected = false;
	}

	public void CloseMoveGUI(){
		Debug.Log ("Closing Move GUI");
		optionSelected = false;
		DestroyObject(Movey);
		Movey = null;
		MoveGUISelected = false;
	}

	public void CloseRotateGUI(){
		Debug.Log ("Closing Rotate GUI");
		optionSelected = false;
		DestroyObject(Rotatey);
		Rotatey = null;
		RotateGUISelected = false;
	}

}
