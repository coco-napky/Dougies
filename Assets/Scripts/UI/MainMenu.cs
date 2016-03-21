using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public KeyCode upJoy;
    public KeyCode downJoy;
    public KeyCode selectJoy;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject start;
    private bool pressedStart = false;
    private bool flag = false;
    private int state = 2;
    private float second;
    private bool size_flag = true;

    void Start()
    {

        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
    }

    void Update()
    {
        
        //  print(state);
        if (Input.GetKeyUp(select)|| Input.GetKeyUp(selectJoy))
            pressedStart = true;


        if (pressedStart)
        {
            option1.SetActive(true);
            option2.SetActive(true);
            option3.SetActive(true);
            start.SetActive(false);

            switch (state)
            {
                case 1:
                    option1.GetComponent<RectTransform>().sizeDelta = new Vector2(65, 25);
                    option2.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                    option3.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                    break;
                case 2:
                    option2.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 35);
                    option3.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                    option1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 20);
                    break;
                case 3:
                    option3.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 35);
                    option2.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                    option1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 20);
                    break;
            }
          
            if (Input.GetKeyUp(up)|| Input.GetKeyUp(upJoy))
            {
                
                if (state <= 1)
                    state = 3;
                else
                    state--;

            }

            if (Input.GetKeyUp(down)|| Input.GetKeyUp(downJoy))
            {
                if (state >= 3)
                    state = 1;
                else
                    state++;
            }


            if((Input.GetKeyUp(select)|| Input.GetKeyUp(selectJoy))&&flag)
            {
                switch (state)
                {
                    case 1:
                        Application.Quit();
                        break;
                    case 2:
                        print("load");
                        Application.LoadLevel("PlayersQuantity");
                        break;
                    case 3:

                        break;
                }
            }

            flag = true;
        }



    }



    void handleInput(){
       

        
    }
}
