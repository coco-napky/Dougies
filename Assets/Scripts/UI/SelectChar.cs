using UnityEngine;
using System.Collections;

public class SelectChar : MonoBehaviour {
    public KeyCode up;
    public KeyCode down;
    public KeyCode start;
    public int select = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(up))
        {
            select++;
            if (select > 2)
                select = 1;
        }

        if (Input.GetKeyDown(down))
        {
            select--;
            if (select < 1)
                select = 2;
        }

        switch(select)
        {
            case 1:
                PlayerPrefs.SetInt("Player Score", 1);
                print("1");
                break;
            case 2:
                PlayerPrefs.SetInt("Player Score", 2);
                print("2");
                break;


        }

        if(Input.GetKeyDown(start))
        {
            Application.LoadLevel("EmptyStage");
        }


        
        
    }
}
