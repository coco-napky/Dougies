using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public KeyCode upJoy;
    public KeyCode downJoy;
    public KeyCode selectJoy;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject start;
    private bool pressedStart = false;
    private bool flag = false;
    private float state = 1;

    void Start()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyUp(select)|| Input.GetKeyUp(selectJoy))
        {
            pressedStart = true;

        }
        if (pressedStart)
        {
            option1.SetActive(true);
            option2.SetActive(true);
            option3.SetActive(true);

            start.SetActive(false);



            if (state == 1)
            {
                arrow1.SetActive(true);
                arrow2.SetActive(false);
                arrow3.SetActive(false);
            }
            if (state == 2)
            {
                arrow1.SetActive(false);
                arrow2.SetActive(true);
                arrow3.SetActive(false);

            }

            if (state == 3)
            {
                arrow1.SetActive(false);
                arrow2.SetActive(false);
                arrow3.SetActive(true);
            }
            if (Input.GetKeyUp(up)|| Input.GetKeyUp(up))
            {
                if (state <= 1)
                {
                    state = 3;
                }
                else
                {
                    state--;
                }
            }

            if (Input.GetKeyUp(down)|| Input.GetKeyUp(down))
            {
                if (state >= 3)
                {
                    state = 1;
                }
                else
                {
                    state++;
                }
            }


            if (Input.GetKey(select)&&flag)
            {
                if (state == 1)
                {
                    Application.LoadLevel("2-player");
                }
                if (state == 2)
                {
                    Application.LoadLevel("v1");
                }

                if (state == 3)
                {

                    Application.LoadLevel("4-player");
                }

            }

            flag = true;

        }

    }
}