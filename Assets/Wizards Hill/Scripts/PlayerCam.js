
var PlayerObject : GameObject;
var HeadingAnchor : GameObject;
var TiltAnchor : GameObject;
var ZoomAnchor : GameObject;
var CollisionStop : GameObject;

private var sensitivityX : float = 10.0;
private var sensitivityY : float = 10.0;
var minimumX : float = -360.0;
var maximumX : float = 360.0;
var minimumY : float = -60.0;
var maximumY : float = 60.0;
var minimumZ : float = -10.0;
var maximumZ : float = 0.0;

private var originalRotation : Quaternion;
private var rotationX : float = 0.0;
private var rotationY : float = 0.0;

private var rotationXv : float = 0.0;
private var disLocate : boolean = false;

private var zoomBase : float;
var inCollision : boolean = false;
var inZooming : boolean = false;

function Start (){
	var tempRotation = PlayerObject.transform.localEulerAngles.y;
	PlayerObject.transform.localEulerAngles.y = 0;
	originalRotation = PlayerObject.transform.localRotation;
	rotationX = tempRotation;
	var xQuaternion : Quaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
	PlayerObject.transform.localRotation = originalRotation * xQuaternion;
	zoomBase = ZoomAnchor.transform.localPosition.z;
	setCamCollider();
}

private var CamSelectionGrid : int = 0;
private var CamSelectionStrings : String[] = [ "High cam", "Mid cam", "Low Cam" ];

function OnGUI () {
	//CamSelectionGrid = GUI.SelectionGrid (Rect ( Screen.width - 300, Screen.height - 30, 300, 30), CamSelectionGrid, CamSelectionStrings, 3);
}

function Update () {

		if (Input.GetAxis("Mouse ScrollWheel") != 0){
			setZoom();
		}
		if (Input.GetMouseButton (0)) {
			if (disLocate){
				rotationX += rotationXv;
				panCam();
				rotationXv = 0.0;
				panCamv();
				disLocate = false;
			}
			panCam();
			tiltCam();
		}
		if (Input.GetMouseButton (1) && Input.GetMouseButton (0) == false) {
			panCamv();
			tiltCam();
			disLocate = true;
		}
		if (!inCollision  && inZooming){
			autoZoom();	
		}

	// set cam heights
	switch(CamSelectionGrid) {
  		case 0 :
			HeadingAnchor.transform.localPosition.y = 0.5369873;
			break;
		case 1 :
			HeadingAnchor.transform.localPosition.y = 0.0;
			break;
		case 2 :
			HeadingAnchor.transform.localPosition.y = -0.5;
			break;
	}
}

//-----------------------------------------------------------------------------------------
// CAMERA MOVE FUNCTIONS
//-----------------------------------------------------------------------------------------

function tiltCam(){
	rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
	rotationY = ClampAngle (rotationY, minimumY, maximumY);		
	var yQuaternion : Quaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
	TiltAnchor.transform.localRotation = originalRotation * yQuaternion;
}

function panCam(){
	rotationX += Input.GetAxis("Mouse X") * sensitivityX;
	rotationX = ClampAngle (rotationX, minimumX, maximumX);
	var xQuaternion : Quaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
	PlayerObject.transform.localRotation = originalRotation * xQuaternion;
}

function panCamv(){
	rotationXv += Input.GetAxis("Mouse X") * sensitivityX;
	rotationXv = ClampAngle (rotationXv, minimumX, maximumX);
	var xQuaternion : Quaternion = Quaternion.AngleAxis (rotationXv, Vector3.up);
	HeadingAnchor.transform.localRotation = originalRotation * xQuaternion;
}

//-----------------------------------------------------------------------------------------
// CAMERA ZOOM FUNCTIONS
//-----------------------------------------------------------------------------------------

function setZoom(){
	ZoomZ = Input.GetAxis("Zoomer");	
	// if the position is between the limits, translate
	if (ZoomAnchor.transform.localPosition.z >= minimumZ && ZoomAnchor.transform.localPosition.z <= maximumZ){
		ZoomAnchor.transform.Translate(Vector3.forward * ZoomZ);
		// if it is to far back, hold
		if (ZoomAnchor.transform.localPosition.z < minimumZ)
		ZoomAnchor.transform.Translate(0,0,0.2);
		// if it is to far front, hold
		if (ZoomAnchor.transform.localPosition.z > maximumZ)
		ZoomAnchor.transform.Translate(0,0,-0.2);
	}
	zoomBase = ZoomAnchor.transform.localPosition.z;
	setCamCollider();
}

function autoZoom(){
	if ( ZoomAnchor.transform.localPosition.z > zoomBase) {
		if (ZoomAnchor.transform.localPosition.z >= minimumZ && ZoomAnchor.transform.localPosition.z <= maximumZ){
			ZoomAnchor.transform.Translate(Vector3.forward * -0.2);
			
			// if it is to far back, hold
			if (ZoomAnchor.transform.localPosition.z < minimumZ)
			ZoomAnchor.transform.Translate(0,0,0.2);
			// if it is to far front, hold
			if (ZoomAnchor.transform.localPosition.z > maximumZ)
			ZoomAnchor.transform.Translate(0,0,-0.2);
			
		}
		setCamCollider();
	} else {
		inZooming = false;
	}
}

function evadeCollision(){
	if (ZoomAnchor.transform.localPosition.z >= minimumZ && ZoomAnchor.transform.localPosition.z <= maximumZ){
		ZoomAnchor.transform.Translate(Vector3.forward * 0.2);
		
		// if it is to far back, hold
		if (ZoomAnchor.transform.localPosition.z < minimumZ)
		ZoomAnchor.transform.Translate(0,0,0.2);
		// if it is to far front, hold
		if (ZoomAnchor.transform.localPosition.z > maximumZ)
		ZoomAnchor.transform.Translate(0,0,-0.2);
		
	}
	setCamCollider();
}

function setCamCollider(){
	var Dist = Vector3.Distance(PlayerObject.transform.position, ZoomAnchor.transform.position);
	ZoomAnchor.GetComponent(BoxCollider).size.z = Dist - 1;
	ZoomAnchor.GetComponent(BoxCollider).center.z = Dist/2;
	CollisionStop.GetComponent(BoxCollider).size.z = Dist + 0.5;
	CollisionStop.GetComponent(BoxCollider).center.z = Dist/2;
}

function setColl(state : boolean){
	inCollision = state;
	inZooming = !state;
}

function OnTriggerEnter(other : Collider){
	if (!other.isTrigger && other.tag != "creature"){
		inCollision = true;
	}
}

function OnTriggerStay(other : Collider){
	if (!other.isTrigger && other.tag != "creature"){
		evadeCollision();
	}
}




//-----------------------------------------------------------------------------------------
// HELPER FUNCTIONS
//-----------------------------------------------------------------------------------------

function ClampAngle (angle : float, min : float, max : float) : float {
	if (angle < -360.0)
		angle += 360.0;
	if (angle > 360.0)
		angle -= 360.0;
	return Mathf.Clamp (angle, min, max);
}







