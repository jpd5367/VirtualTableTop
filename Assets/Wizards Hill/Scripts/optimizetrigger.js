

var OutTriggerObjects : GameObject[];
var InTriggerObjects : GameObject[];
var HideObjectsOutTriggerOnStart : boolean = false;
var HideObjectsInTriggerOnStart : boolean = true;

function Start () {
	if ( HideObjectsInTriggerOnStart ) {
		for ( var InObjects in InTriggerObjects ) {
			InObjects.active = false;
		}
	}
	if ( HideObjectsOutTriggerOnStart ) {
		for ( var Objects in OutTriggerObjects ) {
			Objects.active = false;
		}
	}
}

function OnTriggerEnter() {
	for ( var Objects in OutTriggerObjects ) {
		Objects.active = false;
	}
	for ( var InObjects in InTriggerObjects ) {
		InObjects.active = true;
	}
}

function OnTriggerExit() {
	for ( var Objects in OutTriggerObjects ) {
		Objects.active = true;
	}
	for ( var InObjects in InTriggerObjects ) {
		InObjects.active = false;
	}
}