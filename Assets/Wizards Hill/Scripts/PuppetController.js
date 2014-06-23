@script RequireComponent(CharacterController)

var PuppetStats : PuppetStatsClass;
var PuppetSettings : PuppetSettingsClass;
var AnimationSets : AnimationSetsClass;
var Accessories : GameObject[];
var ShowAccessories : boolean = true;

static var gravity : float = 16.0;
private var grounded : boolean = false;
static var jumping : boolean = false;
static var IsAlive : boolean = true;
static var moveDirection = Vector3.zero; 

static var RotateSpeed : float = 3.0;
static var BattleStanceMode : boolean = false;

private var MixIdleAnims : boolean = true;
private var FootstepsPlaying : boolean = false;
private var MixIdleAnimationsActive : boolean = false;
private var GameRunning : boolean = true;
private var DecalSettings : DecalSettings;
private var Decal : Projector;

static var theMainCamera : Camera;
private var ClickableCapsule : GameObject;
private var DecalProjector : GameObject;

private var puppetRenderer : SkinnedMeshRenderer;

var StateData : StateDataClass;

private var AnimationController : AnimationController = new AnimationController();


//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function Start () {	

	StateData.SetLocation ( transform.position, transform.rotation );
	
	// attach all controllable objects
	puppetRenderer = GetComponentInChildren(SkinnedMeshRenderer);
	theMainCamera = Camera.main;
	
	if ( PuppetSettings.UseBlobShadow ) {
		var shadowInstance = Instantiate (PuppetSettings.ShadowPrefab, Vector3(0, 0, 0), Quaternion.Euler(Vector3(0, 0, 0)));
		shadowInstance.parent = transform;
		shadowInstance.name = "creature shadow";
		shadowInstance.localPosition = new Vector3(0, 1, 0);
		shadowInstance.transform.Rotate(90,0,0);	
		PuppetSettings.ShadowPrefab = shadowInstance;
	}	

	Spawn( 0, 0, 0 );
	AnimationSets.InitAnimations( PuppetSettings.puppetInstance );
} 

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function Update () {
	
	if ( PuppetStats.Health > 0 ) {
	
		if ( grounded ) {
			if (!jumping) {
				if (StateData.GetLastState() != "fall") {
					StateData.SetLastState( StateData.GetCreatureState() );  
				}
				doAction();
			}
			jumping = false;
		} else {
			// if ( the y distance between the puppet and the ground is greater than treshold ) {
				//CreatureState = "fall";
				//doAction();
			//}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;  // Apply gravity
		var controller : CharacterController = GetComponent(CharacterController);  // Move the controller
		var flags = controller.Move(moveDirection * Time.deltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
	
	
	} else {
		if ( IsAlive ) {
			IsAlive = false;
		}
	}
	
	if ( ShowAccessories ) {
		if ( !Accessories[0].active ) {
			Accessories[0].active = true;
		}
	} else {
		if ( Accessories[0].active ) {
			Accessories[0].active = false;
		}
	}
		
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function MixIdleAnimations() {
	while (MixIdleAnims) {	
		yield WaitForSeconds ( Random.Range( 8, 12 ) );
		PuppetSettings.puppetInstance.animation[ AnimationSets.IdleAnimationAddonClip1.name ].blendMode = AnimationBlendMode.Additive;
		PuppetSettings.puppetInstance.animation[ AnimationSets.IdleAnimationAddonClip1.name ].enabled = true;
	}
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function Spawn( HealthPenalty : int, PowerPenalty : int, SpiritPenalty : int ) {
	
	transform.position = StateData.GetOriginalPosition();
	transform.rotation = StateData.GetOriginalRotation();
	
	DecalProjector = Instantiate( PuppetSettings.DecalPrefab, transform.position, transform.rotation );
	DecalProjector.transform.parent = transform;
	DecalProjector.transform.eulerAngles.x += 90;
	Decal = DecalProjector.GetComponent("Projector");
	Decal.enabled = false;
	DecalSettings = DecalProjector.GetComponent("DecalSettings");
	
	ClickableCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
	var CharacterControllerData : CharacterController = GetComponent("CharacterController");
	ClickableCapsule.transform.parent = transform;
    ClickableCapsule.transform.localPosition = Vector3(0, 0, 0);
    ClickableCapsule.collider.isTrigger = true;
    ClickableCapsule.renderer.enabled = false;
    ClickableCapsule.collider.radius = CharacterControllerData.radius;
    ClickableCapsule.collider.height = CharacterControllerData.height;
    ClickableCapsule.name = "Clickable Trigger";
    ClickableCapsule.AddComponent ("SelectableTrigger");
	
	IsAlive = true;
	puppetRenderer.enabled = true;
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function doAction() {
	//if (CreatureState == "idle"){
		//if ( !MixIdleAnimationsActive ){
			//StartCoroutine("MixIdleAnimations");
			//MixIdleAnimationsActive = true;
		//}
	//} else {
		//IdleSelected = false;
		//if ( MixIdleAnimationsActive ){
			//StopCoroutine("MixIdleAnimations");
			//MixIdleAnimationsActive = false;
		//}
	//}
	if ( StateData.GetCreatureState() == "run" || StateData.GetCreatureState() == "walk" || StateData.GetCreatureState() == "walkbackward" || StateData.GetCreatureState() == "superrun" || StateData.GetCreatureState() == "runbackward" ) {            
		if (!FootstepsPlaying) { audio.Play(); FootstepsPlaying = true; }	
	} else {
		if (FootstepsPlaying) { audio.Stop(); FootstepsPlaying = false; }
	}
	switch( StateData.GetCreatureState() ) {
  				case "idle" :
					AnimationController.PlayAnimation( 1.0, 0.0, AnimationSets.IdleAnimationClip1.name, 1.0, 0.3, new Vector3(0, 0, 0), 0, this );
					break;
  				case "battlestance" :
					AnimationController.PlayAnimation( 1.0, 0.0, AnimationSets.BattlestanceAnimationClip1.name, 1.0, 0.3, new Vector3(0, 0, 0), 0, this );
					break;
				case "walk" :
					AnimationController.PlayAnimation( 0.954, PuppetStats.walkSpeed, AnimationSets.WalkAnimationClip.name, 1.5, 0.2, new Vector3(0, 0, 1), 0, this );
					break;
  				case "walkbackward" :
					AnimationController.PlayAnimation( 0.954, PuppetStats.walkSpeed, AnimationSets.WalkAnimationClip.name, -1.5, 0.2, new Vector3(0, 0, -1), 0, this );
					break;
				case "run" :
					AnimationController.PlayAnimation( 1.4, PuppetStats.runSpeed, AnimationSets.RunAnimationClip.name, 1.1, 0.2, new Vector3(0, 0, 1), 0, this );
					break;
				case "superrun" :
					AnimationController.PlayAnimation( 2.2, PuppetStats.runSpeed *5, AnimationSets.RunAnimationClip.name, 2.0, 0.2, new Vector3(0, 0, 1), 0, this );
					break;
  				case "runbackward" :
					AnimationController.PlayAnimation( 0.954, PuppetStats.runSpeed, AnimationSets.WalkAnimationClip.name, -1.1, 0.2, new Vector3(0, 0, -1), 0, this );
					break;
  				case "fall" :
  					jumping = true;
  					break;
  				case "jump" :
  					PuppetSettings.puppetInstance.animation.CrossFade(AnimationSets.JumpAnimationClip1.name, 0.2);
					moveDirection.y = PuppetStats.jumpSpeed;
					jumping = true;
  					break;
  				case "death" :
  					//PuppetSettings.puppetInstance.animation.CrossFade(AnimationSets.DeathAnimationClip1.name, 0.2);
  					break;
			}
}


//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function SetDecal ( state : boolean ) {
	if ( Decal != null ) {
		Decal.enabled = state;
	}
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function ApplyDamage( DamageAmount : int , theCaster : PuppetController ) {
	// AC should be checked here
	PuppetStats.Health -= DamageAmount;
	AnimationController.PlayAnimation( 1.0, 0.0, AnimationSets.HitAnimationClip1.name, 1.0, 0.1, new Vector3(0, 0, 0), 1, this );
	
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function faceTarget( target : Transform) {
	var targetVector : Vector3;
	targetVector = Vector3( target.position.x, transform.position.y, target.position.z );
	transform.LookAt(targetVector);	
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function SetBattleStanceMode( theState : boolean ) {
	BattleStanceMode = theState;
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function OnControllerColliderHit (hit : ControllerColliderHit) {
	if (jumping) {
		jumping = false; // switch jumpstate off
		StateData.SetCreatureState( StateData.GetLastState() );
	}
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

function AutoDecalTrigger () {
    var AllCreatures = FindObjectsOfType (PuppetController);
    for (var Creature : PuppetController in AllCreatures) {
    	if ( Creature.PuppetSettings.IsPlayer ) {
    		if ( !PuppetSettings.IsPlayer ) {
    			DecalSettings.SetDecalImage("enemy");
    		} else {
    			DecalSettings.SetDecalImage("self");
    		}
    	}
        Creature.Decal.enabled = false;
    }
    Decal.enabled = true;
}

//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------
















