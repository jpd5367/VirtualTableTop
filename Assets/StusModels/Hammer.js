//For the Hammer:

var Hammer: GameObject;
//thats the hammer cube parented to hammer tip

function OnTriggerEnter(other:Collider){
if(other.gameObject==Hammer)
audio.pitch=Random.Range(1,1.3);
audio.Play();
}