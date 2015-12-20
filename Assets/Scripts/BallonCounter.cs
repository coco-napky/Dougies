using UnityEngine;
using System.Collections;

public class BallonCounter : MonoBehaviour {

    public GameObject Balloon1;
    public GameObject Balloon2;
    public GameObject Balloon3;

    public float Balloon_Life;

    // Use this for initialization
    void Start () {
        Balloon1.gameObject.GetComponent<Renderer>().enabled = false;
        Balloon2.gameObject.GetComponent<Renderer>().enabled = false;
        Balloon3.gameObject.GetComponent<Renderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Balloon_Life == 3)
        {
            Balloon3.gameObject.GetComponent<Renderer>().enabled = true;
        }

        if (Balloon_Life == 2)
        {
            Balloon3.gameObject.GetComponent<Renderer>().enabled = false;
            Balloon2.gameObject.GetComponent<Renderer>().enabled = true;
        }

        if (Balloon_Life == 1)
        {
            Balloon2.gameObject.GetComponent<Renderer>().enabled = false;
            Balloon1.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
          
        if (collision.gameObject.tag == "Taco")
        {
            Balloon_Life -= 1;


        }
    }
}
