
class PuppetStatsClass {
	var strength : float = 3.0;
	var MaxHealth : float = 100;
	var Health : float = 100;
	var HealingRegenerateValue : float = 2;
	var MaxSpirit : float = 100;
	var Spirit : float = 100;
	var SpiritRegenerateValue : float = 2;
	var MaxPower : float = 100;
	var Power : float = 100;
	var PowerRegenerateValue : float = 2;
	var walkSpeed : float = 2.5;
	var runSpeed : float = 5.0;
	var jumpSpeed : float = 8.0;
	
	function Regenerate() {
		if ( Health > 0 ) {
			if ( Health < MaxHealth ) {
				Health += HealingRegenerateValue;
			}
			if ( Power < MaxPower ) {
				Power += PowerRegenerateValue;
			}
			if ( Spirit < MaxSpirit ) {
				Spirit += SpiritRegenerateValue;
			}
			Mathf.Clamp( Health, 0.0, MaxHealth );
			Mathf.Clamp( Power, 0.0, MaxHealth );
			Mathf.Clamp( Spirit, 0.0, MaxHealth );
		}
	}
}

class PuppetSettingsClass {
	var IsPlayer : boolean = false;
	var Name : String;
	var theGender : GenderOptions;
	var puppetInstance : GameObject;
	var UseBlobShadow : boolean = true;
	var ShadowPrefab : Transform;
	var DecalPrefab : GameObject;
}

enum GenderOptions { 
	Male = 0, 
	Female = 1 
}

class AnimationSetsClass {
	var IdleAnimationClip1 : AnimationClip;
	var IdleAnimationAddonClip1 : AnimationClip;
	var BattlestanceAnimationClip1 : AnimationClip;
	var JumpAnimationClip1 : AnimationClip;
	var RunAnimationClip : AnimationClip;
	var WalkAnimationClip : AnimationClip;
	var DefaultAnimationClip : AnimationClip;
	var HitAnimationClip1 : AnimationClip;
	var DeathAnimationClip1 : AnimationClip;
	
	function InitAnimations( targetPuppet : GameObject ) {
		var AnimationControl : AnimationController = new AnimationController();
		AnimationControl.AddAnimation( IdleAnimationClip1, IdleAnimationClip1.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( IdleAnimationAddonClip1, IdleAnimationAddonClip1.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( BattlestanceAnimationClip1, BattlestanceAnimationClip1.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( JumpAnimationClip1, JumpAnimationClip1.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( RunAnimationClip, RunAnimationClip.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( WalkAnimationClip, WalkAnimationClip.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( DefaultAnimationClip, DefaultAnimationClip.name, WrapMode.Loop, 0, targetPuppet );
		AnimationControl.AddAnimation( HitAnimationClip1, HitAnimationClip1.name, WrapMode.Once, 0, targetPuppet );
		targetPuppet.animation.Stop();
	   	targetPuppet.animation.Play( IdleAnimationClip1.name );	
	}
}

class AnimationController {
	function AddAnimation( theAnimation : AnimationClip, AnimationName : String, AnimationWrapMode : WrapMode, AnimationLayer : int, targetPuppet : GameObject ) {
		targetPuppet.animation.AddClip( theAnimation, AnimationName );
 		targetPuppet.animation[AnimationName].wrapMode = AnimationWrapMode;
 		targetPuppet.animation[AnimationName].layer = AnimationLayer;
	}
	function PlayAnimation( AudioPitch : float, PuppetSpeed : float, AnimationName : String, AnimationSpeed : float, AnimationCrossfade : float, MoveVector : Vector3, theLayer : int, theTarget : PuppetController ) {
		theTarget.audio.pitch = AudioPitch;
		theTarget.PuppetSettings.puppetInstance.animation[ AnimationName ].layer = theLayer;
		theTarget.PuppetSettings.puppetInstance.animation[ AnimationName ].speed = AnimationSpeed;
		theTarget.PuppetSettings.puppetInstance.animation.CrossFade( AnimationName, AnimationCrossfade );
		theTarget.moveDirection = MoveVector;
		theTarget.moveDirection = theTarget.transform.TransformDirection(theTarget.moveDirection);
		theTarget.moveDirection *= PuppetSpeed;
	}
}

class ArrayFunctions {
	function ArrayContains ( theArray , theItem ) {
		for ( var i = 0; i < theArray.length; i++ ) {
	       if ( theArray[i] == theItem ) return true;
	   	}
   		return false;
	}
} 

class StateDataClass {
	private var OriginalPosition : Vector3;
	private var OriginalRotation : Quaternion;
	static var moveMode : int = 1;
	private var CreatureState : String = "idle";
	private var lastState : String = "idle";
	
	function SetLocation ( pos : Vector3, rot : Quaternion ) {
		OriginalPosition = pos;
		OriginalRotation = rot;
	}
	
	function GetOriginalPosition() : Vector3 {
		return OriginalPosition;
	}
	
	function GetOriginalRotation() : Quaternion {
		return OriginalRotation;
	}
	
	function SetMoveMode( theMoveMode : int ) {
		moveMode = theMoveMode;
	}
	
	function GetMoveMode() : int {
		return moveMode;
	}
	
	function SetCreatureState( theState : String ) {
		CreatureState = theState;
	}
	
	function GetCreatureState() : String {
		return CreatureState;
	}
	
	function SetLastState( theLastState : String ) {
		lastState = theLastState;
	}
	
	function GetLastState() : String {
		return lastState;
	}
}

















