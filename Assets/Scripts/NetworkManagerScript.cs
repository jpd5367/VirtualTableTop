using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {

	// Use this for initialization
	
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;
	public byte[] TexByteArray;

	GameObject player1;
	GameObject player2;

	GameObject myPlayer;

	public char commonMessage;
	public char myMessage;

	public Texture2D cam;

	public bool check;

	public Texture DMCam;
	public string DMID;
	public Texture Player1Cam;
	public string Player1ID;
	public Texture Player2Cam;
	public string Player2ID;
	public Texture Player3Cam;
	public string Player3ID;
	public Texture Player4Cam;
	public string Player4ID;

	public float windowWidth;
	public float windowHeight;



	struct playerWebcamTexturee{
		public int red;
		public int green;
		public int blue;
		public int alpha;

	}
	//public GameObject target;
	
	private bool  refreshing;
	
	private HostData[] hostData;
	private bool hostLoaded = false;
	private string gameName= "DNDHybrid";
	
	void Start () {
		btnX= Screen.width *.05f;
		btnY= Screen.width *.05f;
	    btnW= Screen.width *.1f;
	    btnH= Screen.width *.1f;
	
	}
	
	void StartServer(){
		
		
		Network.InitializeServer(32, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost(gameName, "Leblanc Group", "Meeting place and tools for online tabletop gaming");
	}
	
	void refreshHostList(){
		MasterServer.RequestHostList(gameName);
		refreshing = true;
		Debug.Log(MasterServer.PollHostList().Length);
	}
	
	void Update(){
		windowHeight = Screen.height *.25f;
		windowWidth = ((Screen.height *.25f)*16f)/9f;
		if(refreshing){
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData = MasterServer.PollHostList();	
				hostLoaded = true;
			}
		}
		DMCam = GetComponent<webCamView>().webcamTexture;
		Player1Cam = GetComponent<webCamView>().webcamTexture;
		Player2Cam= GetComponent<webCamView>().webcamTexture;
		Player3Cam = GetComponent<webCamView>().webcamTexture;
		Player4Cam = GetComponent<webCamView>().webcamTexture;

		if(check)myMessage = 'a';
	}
	
	void OnServerInitialized(){
		Debug.Log("Server Initialized");	
	}
	
	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log ("Registered Server!");
		}
	}
	// Update is called once per frame
	void OnGUI() 
	{
		if (!Network.isClient && !Network.isServer) {
			if(GUI.Button(new Rect(0,windowHeight ,windowWidth , windowHeight/2), "Start Server"))
			{
				Debug.Log("Starting Server");
				StartServer();
			}
			
			if(GUI.Button(new Rect(0,windowHeight*1.5f  ,windowWidth , windowHeight/2), "Find Game Session"))
			{
				Debug.Log("Refreshing");
				refreshHostList();
			}
			
			if(hostLoaded)
			{
				for(int i = 0; i < hostData.Length; i++)
			    {
					GUI.backgroundColor = new Color(0f,150f,20f, 100f);
					if(GUI.Button(new Rect(0,windowHeight*2f  ,windowWidth , windowHeight/2), hostData[i].gameName))
					{
						Network.Connect(hostData[i]);
						//networkView.RPC("GiveServerIpAddress",RPCMode.Server,NetworkViewID.ToString());

				}
				
					}
			    
			}
			
			
			
		}
		if(Network.isClient){

			if(Network.player.ToString() == "0")myPlayer = player1;
			if(Network.player.ToString() == "1")myPlayer = player2;


			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 ,windowWidth , windowHeight/2),Network.player.ToString()))
				{
				//	networkView.RPC("AskForSetWebcamFeed",RPCMode.Server,Network.player.ToString());
				}
			if(GUI.Button(new Rect(100,125,110,25),myMessage.ToString()))
				{
					//networkView.RPC("AskForColorGreen",RPCMode.Server);
				}
				
			if(GUI.Button(new Rect(0,windowHeight ,windowWidth , windowHeight/2),"Logout"))
				{
					Network.Disconnect();
				}
				
			}

		if(Network.isServer){
			
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 ,windowWidth , windowHeight/2),Network.player.ToString()))
			{
				//	networkView.RPC("AskForSetWebcamFeed",RPCMode.Server,Network.player.ToString());
			}

			if(GUI.Button(new Rect(100,125,110,25),myMessage.ToString()))
				{
					//networkView.RPC("AskForColorGreen",RPCMode.Server);
				}
			
			if(GUI.Button(new Rect(0,windowHeight ,windowWidth , windowHeight/2),"Logout"))
			{
				Network.Disconnect();
			}
			
		}
		
	
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 p1syncPosition = Vector3.zero;
		Vector3 p2syncPosition = Vector3.zero;



		if (stream.isWriting)
		{

			if(Network.player.ToString() == "0"){
				p1syncPosition = GameObject.FindWithTag("Player1").rigidbody.position;
				stream.Serialize(ref p1syncPosition);
			}
			if(Network.player.ToString() == "1"){
				p2syncPosition = GameObject.FindWithTag("Player2").rigidbody.position;
				stream.Serialize(ref p2syncPosition);
			}
		}
		else
		{
			if(Network.player.ToString() != "0"){
				stream.Serialize(ref p1syncPosition);
				GameObject.FindWithTag("Player1").rigidbody.position= p1syncPosition ;
			}
			if(Network.player.ToString() != "1"){
				stream.Serialize(ref p2syncPosition);
				GameObject.FindWithTag("Player2").rigidbody.position= p2syncPosition ;
			}
		}

	}
		
	 



	[RPC]
	void AskForSetWebcamFeed()
	{
		//if(Network.isServer)
		//{
		//	if(Player1Info.
		////	networkView.RPC("ChangeWebcamFeed",RPCMode.All);
		//}
	}
	
	[RPC]
	void ChangeColorRed()
	{
	//	DMCam = NetworkView.GetComponent<webCamView>().webcamTexture;
	}
	[RPC]
	void AskForColorGreen()
	{
		if(Network.isServer)
		{
		//	networkView.RPC("ChangeColorGreen",RPCMode.All, Texture );
		}
	}
	
	[RPC]
	void ChangeColorGreen()
	{
		//target.renderer.material.color = Color.green;
	}

	[RPC]
	void GiveServerIpAddress()
	{
		//playerOneIp = NetworkViewID;
	}

	void OnConnectedToServer(){

	}
	
}