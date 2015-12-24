using UnityEngine;
using System.Collections;

public class BallonCounter : MonoBehaviour {

    public GameObject Balloon1;
    public GameObject Balloon2;
    public GameObject Balloon3;
    private int Balloon_Life = 3;
    // Use this for initialization
    void Start () {
        Balloon1.gameObject.GetComponent<Renderer>().enabled = true;
        Balloon2.gameObject.GetComponent<Renderer>().enabled = true;
        Balloon3.gameObject.GetComponent<Renderer>().enabled = true;
    }

	// Update is called once per frame
	void Update () {
      switch(Balloon_Life){
        case 3 :
        Balloon3.gameObject.GetComponent<Renderer>().enabled = true;
        break;

        case 2 :
        Balloon3.gameObject.GetComponent<Renderer>().enabled = false;
        Balloon2.gameObject.GetComponent<Renderer>().enabled = true;
        break;

        case 1 :
        Balloon2.gameObject.GetComponent<Renderer>().enabled = false;
        Balloon1.gameObject.GetComponent<Renderer>().enabled = true;
        break;
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Taco")
            Balloon_Life -= 1;
    }
}
