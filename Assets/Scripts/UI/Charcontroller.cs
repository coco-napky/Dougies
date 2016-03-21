using UnityEngine;
using System.Collections;

public class Charcontroller : MonoBehaviour {
    public GameObject p1, p2, p3, p4;
    public KeyCode back;
    public int party;
	// Use this for initialization
	void Start () {
        party = PlayerPrefs.GetInt("Party");
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        switch (party)
        {
            case 2:
                p1.GetComponent<RectTransform>().anchoredPosition = new Vector2(410, 160);
                p2.GetComponent<RectTransform>().anchoredPosition = new Vector2(430, 160);
                p1.SetActive(true);
                p2.SetActive(true);
                break;
            case 3:
                p1.GetComponent<RectTransform>().anchoredPosition = new Vector2(400, 160);
                p2.GetComponent<RectTransform>().anchoredPosition = new Vector2(420, 160);
                p3.GetComponent<RectTransform>().anchoredPosition = new Vector2(610, 160);
                p1.SetActive(true);
                p2.SetActive(true);
                p3.SetActive(true);
                break;
            case 4:
                p1.GetComponent<RectTransform>().anchoredPosition = new Vector2(370, 160);
                p2.GetComponent<RectTransform>().anchoredPosition = new Vector2(390, 160);
                p3.GetComponent<RectTransform>().anchoredPosition = new Vector2(580, 160);
                p4.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 160);
                p1.SetActive(true);
                p2.SetActive(true);
                p3.SetActive(true);
                p4.SetActive(true);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(back))
        {
            Application.LoadLevel("PlayersQuantity");
        }
    }
}
