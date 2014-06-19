var doorOpen : AudioClip;
var doorShut : AudioClip;
var doorLocked : AudioClip;
var doorTimer : float = 3.0;
@HideInInspector
var hasKey = false;
private var lockedSoundPlaying = false;

function OnControllerColliderHit (hit : ControllerColliderHit) {
	// Open doors we hit tagged "doorClosed"
	if (hit.gameObject.tag == "doorClosed") {
		OpenAndShutDoor(hit.gameObject, hit.transform.position);
	}
	// If we hit a locked door
	else if (hit.gameObject.tag == "lockedDoorClosed") {
		// open if it we have the key
		if (hasKey) {
			OpenAndShutDoor(hit.gameObject, hit.transform.position);
		}
		// otherwise, play the locked door sound if it's not already playing
		else {
			if (!lockedSoundPlaying) {
				// Play sound and wait for it to stop before we can play it again, to prevent overlapping sounds
				audio.PlayClipAtPoint(doorLocked, hit.transform.position);
				lockedSoundPlaying = true;
				yield WaitForSeconds(doorLocked.length);
				lockedSoundPlaying = false;
			}
		}
	}
}

function OpenAndShutDoor (hitObject : GameObject, hitPos : Vector3) {
	if (inside) {
		camera.main.cullingMask = insideMask;
	}
	// Play door open animation at root of object we hit, and set the tag to "doorOpened" so we can't affect it while it's open
	var originalTag = hitObject.tag;
	var hitObjectRoot = hitObject.transform.root;
	hitObject.tag = "doorOpened";
	hitObjectRoot.animation.Play("opening");
	audio.PlayClipAtPoint(doorOpen, hitPos);
	
	yield WaitForSeconds(doorTimer);
	
	// Play door close animation and reset tag
	hitObjectRoot.animation.Play("closing");
	hitObject.tag = originalTag;
	audio.PlayClipAtPoint(doorShut, hitPos);
	while (hitObjectRoot.animation.isPlaying) {yield;}
	if (!inside) {
		camera.main.cullingMask = outsideMask;
	}
}

var insideMask : LayerMask;
var outsideMask : LayerMask;
private var inside = false;

function Start () {
	camera.main.cullingMask = outsideMask;
}

function OnTriggerEnter (col : Collider) {
	if (col.gameObject.tag == "Interior") {
		inside = true;
	}
}

function OnTriggerExit (col : Collider) {
	if (col.gameObject.tag == "Interior") {
		inside = false;
	}
}