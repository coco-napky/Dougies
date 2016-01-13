using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public KeyCode 
                 up_Joy,
                 directionSwitch_Joy,
                 fire_Joy;
  private bool jump,shoot, switchDirection;

  public DougieStates states;

  public void OnjumpButton()
    {
        jump = true;
    }

    public void OffjumpButton()
    {
        jump = false;
    }

    public void OnfireButton()
    {
        shoot= true;
    }

    public void OfffireButton()
    {
        shoot = false;

    }
    public void OnswitchButton()
    {
        switchDirection= true;
    }



    void Awake(){


  }

	void Start(){
	}

	// Update is called once per frame
	void Update () {

		states.goingUp 	= jump   || Input.GetKey(up_Joy);
        states.shooting = shoot || Input.GetKey(fire_Joy);
        if (shoot)
            shoot = false;

        if (switchDirection || Input.GetKeyDown(directionSwitch_Joy))
        {
            states.goingLeft = !states.goingLeft;
            switchDirection = false;
        }
	}
}
