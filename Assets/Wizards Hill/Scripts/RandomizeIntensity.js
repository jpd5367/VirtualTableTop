
var LightSource : Light;

function Start() {
	LightSource = GetComponent(Light);
}

function Update () {
	LightSource.intensity = Random.Range( 0.7, 1.0);
}