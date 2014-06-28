using UnityEngine;
using System.Collections;

public class GUIFunctions : MonoBehaviour {
	public GameObject TileSetGUI;
	public GameObject AnimalList;

	public bool mainMenuEnabled;
	public bool tileSetsEnabled;
	public bool monsterListEnabled;
	public float width;
	public Camera myCam;
	Transform parent ;
	GameObject temp ;

	void Start(){
		myCam = GameObject.FindWithTag("UI Camera").GetComponent<Camera>();
	}

	void Update(){
		if(tileSetsEnabled){
			//temp.transform.position = myCam.ScreenToWorldPoint(new Vector3(.005f*Screen.width,1f * Screen.height,0f));
		}
	}

	public void OpenTileSets(){


		parent = GameObject.Find ("UI Root").transform;
		temp = Instantiate(TileSetGUI)as GameObject;
		temp.transform.parent = parent;
		temp.transform.position = myCam.ScreenToWorldPoint(new Vector3(.005f*Screen.width,1f * Screen.height,0f));
		temp.transform.localScale = Vector3.one;

		CloseMainMenu();
		EnableBack();
		tileSetsEnabled = true;
	}

	public void OpenMonsters(){
		Transform parent = GameObject.Find ("UI Root").transform;
		GameObject temp = Instantiate(AnimalList)as GameObject;
		temp.transform.parent = parent;
		temp.transform.position = new Vector3(-1.2f, .5f, 0);
		temp.transform.localScale = Vector3.one;
		
		CloseMainMenu();
		EnableBack();
		monsterListEnabled = true;
	}

	public void CloseMainMenu(){
		GameObject myParent = GameObject.Find ("Menu Items");
		int numChildren = myParent.transform.childCount;
		Transform[] temp;
		temp = new Transform[numChildren];
		for(int i = 0;i < numChildren;i++){
			temp[i] = myParent.transform.GetChild(i);
		}
	
		foreach (Transform x in temp){ 
			x.gameObject.GetComponent<UISprite>().enabled = false;
			x.gameObject.GetComponent<UIButton>().enabled = false;
			x.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}

	public void OpenMainMenu(){
		GameObject myParent = GameObject.Find ("Menu Items");
		int numChildren = myParent.transform.childCount;
		Transform[] temp;
		temp = new Transform[numChildren];
		for(int i = 0;i < numChildren;i++){
			temp[i] = myParent.transform.GetChild(i);
		}
		
		foreach (Transform x in temp){ 
			x.gameObject.GetComponent<UISprite>().enabled = true;
			x.gameObject.GetComponent<UIButton>().enabled = true;
			x.gameObject.GetComponent<BoxCollider>().enabled = true;
		}
		if(tileSetsEnabled){
			Destroy(GameObject.Find("StoneyTiles(Clone)"));
		}
		if(monsterListEnabled){
			Destroy(GameObject.Find("Animal List(Clone)"));
		}
	}
    
	public void EnableBack(){
		GameObject.FindWithTag("BackButton").GetComponent<UISprite>().enabled = true;
		GameObject.FindWithTag("BackButton").GetComponent<UIButton>().enabled = true;
		GameObject.FindWithTag("BackButton").GetComponent<BoxCollider>().enabled = true;
	}

	public void DisableBack(){
		GameObject.FindWithTag("BackButton").GetComponent<UISprite>().enabled = false;
	}
	

}
