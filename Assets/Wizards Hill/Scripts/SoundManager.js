var SoundTracks : GameObject[];
var AmbientTracks : GameObject[];
var MusicTrack : boolean = true;
private var CurrentTrack1 : GameObject;
private var CurrentTrack2 : GameObject;
private var CurrentTrackActive : int = 1;
private var SoundRunning : boolean = true;
yield setMusic();

function Start () {
	CurrentTrack1 = SoundTracks[0];
	CurrentTrack2 = SoundTracks[0];
	AmbientTracks[0].audio.Play();
}

function SwitchTrack(trackID : int) {
	var tempTrack : GameObject;
	tempTrack = SoundTracks[trackID];
	switch(CurrentTrackActive) {
	case 1:
		CurrentTrack2 = tempTrack;
		CurrentTrackActive = 2;
	  	break;    
	case 2:
		CurrentTrack1 = tempTrack;
		CurrentTrackActive = 1;
	  	break;
	}
}

function GetTrack() {
	return 0;
}

function setMusic() {
//	while (SoundRunning) {
	yield WaitForSeconds (0);
//	if (MusicTrack) {
//		if (CurrentTrackActive == 1 && CurrentTrack2.audio.isPlaying) {
//			//print("fade from 2 to 1");
//			if (CurrentTrack1.audio.isPlaying == false) {
//				CurrentTrack1.audio.volume = 0.0;
//				CurrentTrack1.audio.Play();
//			}
//			if (CurrentTrack2.audio.volume > 0.01) {
//				CurrentTrack2.audio.volume = CurrentTrack2.audio.volume - 0.01;
//			}
//			if (CurrentTrack1.audio.volume < CurrentTrack1.audio.maxVolume) {
//				CurrentTrack1.audio.volume = CurrentTrack1.audio.volume + 0.01;
//			}
//			if (CurrentTrack2.audio.volume < 0.01 && CurrentTrack1.audio.volume >= CurrentTrack1.audio.maxVolume) {
//				CurrentTrack2.audio.Stop();
//			}
//		} 
//		if (CurrentTrackActive == 2 && CurrentTrack1.audio.isPlaying) {
//			//print("fade from 1 to 2");
//			if (CurrentTrack2.audio.isPlaying == false) {
//				CurrentTrack2.audio.volume = 0.0;
//				CurrentTrack2.audio.Play();
//			}
//			if (CurrentTrack1.audio.volume > 0.01) {
//				CurrentTrack1.audio.volume = CurrentTrack1.audio.volume - 0.01;	
//			}
//			if (CurrentTrack2.audio.volume < CurrentTrack2.audio.maxVolume) {
//				CurrentTrack2.audio.volume = CurrentTrack2.audio.volume + 0.01;
//			}
//			if (CurrentTrack1.audio.volume < 0.01 && CurrentTrack2.audio.volume >= CurrentTrack2.audio.maxVolume) {
//				CurrentTrack1.audio.Stop();
//			}
//		} 
//		if (CurrentTrackActive == 1 && CurrentTrack2.audio.isPlaying == false) {
//			//print("start tracks");
//			if (CurrentTrack1.audio.isPlaying == false) {
//				CurrentTrack1.audio.Play();
//			}	
//		}
//	} else if (!MusicTrack && CurrentTrack1.audio.isPlaying || CurrentTrack2.audio.isPlaying) {
//		CurrentTrack1.audio.Stop();
//		CurrentTrack2.audio.Stop();
//	}
//	}
}











