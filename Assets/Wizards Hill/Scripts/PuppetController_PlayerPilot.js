@script RequireComponent(CharacterController)
@script RequireComponent(PuppetController)

private var Controller : PuppetController;

function Start() {
	Controller = GetComponent(PuppetController);
}

function Update() {
	if ( Controller.PuppetStats.Health > 0 ) {
		
				if (Controller.jumping == false) { // if you're not jumping
		
			if (Input.GetMouseButton (0) && Input.GetMouseButton (1)) { // if two mouse buttons are clicked
				if (Controller.StateData.GetMoveMode() == 0) {
					Controller.StateData.SetCreatureState( "walk" );
				} else if (Controller.StateData.GetMoveMode() == 1) {
					Controller.StateData.SetCreatureState( "run" );
				}
			} else if (Input.GetAxis ("Vertical")) {
				 // if the backward key is pressed
				if (Input.GetAxis ("Vertical") < 0) {
					if (Controller.StateData.GetMoveMode() == 0) {
						Controller.StateData.SetCreatureState( "walkbackward" );
					} else if (Controller.StateData.GetMoveMode() == 1) {
						Controller.StateData.SetCreatureState( "runbackward" );
					}
				 // if the forward key is pressed	
				} else {
					if (Controller.StateData.GetMoveMode() == 0) {
						Controller.StateData.SetCreatureState( "walk" );
					} else if (Controller.StateData.GetMoveMode() == 1) {
						//if (Input.GetButton ("shiftrun")) {
							//Controller.StateData.SetCreatureState( "superrun" );
						//} else {
							Controller.StateData.SetCreatureState( "run" );
						//}
					}
				}	
			} else {
				if ( Controller.BattleStanceMode ) {
					Controller.StateData.SetCreatureState( "battlestance" );
				} else {
					Controller.StateData.SetCreatureState( "idle" );
				}
			}
			
			if (Input.GetAxis ("Horizontal")) { // if rotate key is pressed
				if (Input.GetAxis ("Horizontal") < 0) {	
					transform.Rotate((Vector3.up * Time.deltaTime * Controller.RotateSpeed * 20) * -1);
				} else {
					transform.Rotate((Vector3.up * Time.deltaTime * Controller.RotateSpeed * 20) * 1);
				}
			}
			if (Input.GetButton ("Jump")) { // if jump key is pressed
				Controller.StateData.SetCreatureState( "jump" );
			}	
		}

		if (Input.GetKeyDown ("r")) { // if the run key is pressed
			switch(Controller.StateData.GetMoveMode())
			{
				case 0: // if its walk, make it run
					Controller.StateData.SetMoveMode( 1 );
					break;
				case 1: // if its run, make it walk
					Controller.StateData.SetMoveMode( 0 );
					break;
			}
		}
		
		
	}		
}















