using UnityEngine;
using System.Collections;

public class PauseTouch : MonoBehaviour {
    public Canvas Menu,Botones;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Menu.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        Menu.enabled = true;
        Botones.enabled = false;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Botones.enabled = true;
        Menu.enabled = false;

    }
	
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    public void Home()
    {
        Application.LoadLevel("StartMenu");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
