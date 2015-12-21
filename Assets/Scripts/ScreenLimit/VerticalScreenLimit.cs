using UnityEngine;
using System.Collections;

public class VerticalScreenLimit : MonoBehaviour {

    public KeyCode fire;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(fire))
        {
            //   DontDestroyOnLoad(one);
            PlayerPrefs.SetInt("Player Score", 10);
            Application.LoadLevel("v1");
            
        }

    }
}
