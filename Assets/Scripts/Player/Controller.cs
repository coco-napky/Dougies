using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Controller : NetworkBehaviour {

	public KeyCode directionSwitch,
                 up,
	               fire,
                 up_Joy,
                 directionSwitch_Joy,
                 fire_Joy;

  public DougieStates states;

  void Awake(){

  }

	void Start(){
	}

	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
			return;
		states.goingUp 	= Input.GetKey(up)       || Input.GetKey(up_Joy);
    states.shooting = Input.GetKeyDown(fire) || Input.GetKeyDown(fire_Joy);

		if( Input.GetKeyDown(directionSwitch)|| Input.GetKeyDown(directionSwitch_Joy))
			  states.goingLeft = !states.goingLeft;
	}
}
