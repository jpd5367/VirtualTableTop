
var PlayerControl : GameObject;



function OnTriggerExit(other : Collider){
	if (!other.isTrigger && other.tag != "Player"){
		PlayerControl.GetComponent(PlayerCam).setColl(false);
	}
}