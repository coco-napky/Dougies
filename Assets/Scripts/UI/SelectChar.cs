using UnityEngine;
using System.Collections;

public class SelectChar : MonoBehaviour {
    public KeyCode up;
    public KeyCode down;
    public KeyCode start;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
    public string player;
    public int select = 1;
    public 
	// Use this for initialization
	void Start () {
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {    
        if(Input.GetKeyDown(up))
        {
            select++;
            if (select > 4)
                select = 1;
        }

        if (Input.GetKeyDown(down))
        {
            select--;
            if (select < 1)
                select = 4;
        }

        switch(select)
        {
            case 1:
                PlayerPrefs.SetInt("Player "+player, 1);
                option1.SetActive(true);
                option2.SetActive(false);
                option3.SetActive(false);
                option4.SetActive(false);
                print("1");
                break;
            case 2:
                PlayerPrefs.SetInt("Player " + player, 2);
                option1.SetActive(false);
                option2.SetActive(true);
                option3.SetActive(false);
                option4.SetActive(false);
                print("2");
                break;
            case 3:
                PlayerPrefs.SetInt("Player " + player, 3);
                option1.SetActive(false);
                option2.SetActive(false);
                option3.SetActive(true);
                option4.SetActive(false);
                print("3");
                break;
            case 4:
                PlayerPrefs.SetInt("Player " + player, 4);
                option1.SetActive(false);
                option2.SetActive(false);
                option3.SetActive(false);
                option4.SetActive(true);
                print("4");
                break;


        }

        if(Input.GetKeyDown(start))
        {
            Application.LoadLevel("EmptyStage");
        }


        
        
    }
}
