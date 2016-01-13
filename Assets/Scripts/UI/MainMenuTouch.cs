using UnityEngine;
using System.Collections;

public class MainMenuTouch : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
	
	}

  public  void Load2Player()
    {
        Application.LoadLevel("2-player");
    }
	
   public void Load3Player()
    {
        Application.LoadLevel("3-player");
    }

   public void Load4Player()
    {
        Application.LoadLevel("4-player");
    }

    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
