using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {
    public GameObject Back, Flecha;
    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public KeyCode upJoy;
    public KeyCode downJoy;
    public KeyCode selectJoy;
    private int state = 2;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Party", 2);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(up) || Input.GetKeyUp(upJoy))
        {

            if (state <= 1)
                state = 4;
            else
                state--;

        }

        if (Input.GetKeyUp(down) || Input.GetKeyUp(downJoy))
        {
            if (state >= 4)
                state = 1;
            else
                state++;
        }

        switch (state)
        {
            case 1:
                Back.GetComponent<RectTransform>().sizeDelta = new Vector2(65, 35);
                Flecha.SetActive(false);
                break;
            case 2:
                Back.GetComponent<RectTransform>().sizeDelta = new Vector2(55, 25);
                Flecha.SetActive(true);
                Flecha.GetComponent<RectTransform>().anchoredPosition = new Vector2(-275,55);
                PlayerPrefs.SetInt("Party", 2);
                break;
            case 3:
                Back.GetComponent<RectTransform>().sizeDelta = new Vector2(55, 25);
                Flecha.SetActive(true);
                Flecha.GetComponent<RectTransform>().anchoredPosition = new Vector2(-275, -30);
                PlayerPrefs.SetInt("Party", 3);
                break;
            case 4:
                Back.GetComponent<RectTransform>().sizeDelta = new Vector2(55, 25);
                Flecha.SetActive(true);
                Flecha.GetComponent<RectTransform>().anchoredPosition = new Vector2(-275, -120);
                PlayerPrefs.SetInt("Party", 4);
                break;
        }

        if ((Input.GetKeyUp(select) || Input.GetKeyUp(selectJoy)))
        {
            switch (state)
            {
                case 1:
                    Application.LoadLevel("StartMenu");
                    break;
                case 2:
                    print("load");
                    Application.LoadLevel("CharacterSelect");
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}
