using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    public KeyCode startButton;
    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    public Canvas Menu; // Assign in inspector
    private float state =1;

    void Start()
    {
        Menu = GetComponent<Canvas>();
        Menu.enabled = false;
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyUp(startButton))
        {
            Menu.enabled = true;
        }
        if (Menu.enabled)
        {

            Time.timeScale = 0.0f;


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
            if (Input.GetKeyUp(up))
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

            if (Input.GetKeyUp(down))
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


            if (Input.GetKeyUp(select))
            {
                if (state == 1)
                {
                    Time.timeScale = 1;
                    Menu.enabled = false;
                }
                if (state == 2)
                {
                    Time.timeScale = 1;
                    Application.LoadLevel(Application.loadedLevel);
                }

                if (state == 3)
                {
                    Application.LoadLevel("StartMenu");
                }

            }
        }

    }
}