
var autodecal : boolean = false;

function OnMouseDown () {
	if ( autodecal ) {
    	gameObject.SendMessageUpwards ("AutoDecalTrigger");
	}
}