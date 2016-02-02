using UnityEngine;
using System.Collections;

public class CameraAndroid : MonoBehaviour {
    public int scale;
	// Use this for initialization
	void Start () {
        Camera.main.orthographicSize = Mathf.Max(Screen.width, Screen.height)/scale;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
