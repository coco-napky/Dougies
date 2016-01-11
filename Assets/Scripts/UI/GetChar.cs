using UnityEngine;
using System.Collections;

public class GetChar : MonoBehaviour {
    private int select;
    public GameObject Dougie;
    public GameObject Dougie2;
    public GameObject Dougie3;
    public GameObject Dougie4;
    public GameObject controller;
    private GameObject BlankDougie;

    public int x;
    public int y;
    public string player;
    // Use this for initialization
    void Start () {
        select = PlayerPrefs.GetInt("Player "+player);
        GameObject tacoProjectile;
        Vector3 offset;
        offset =new Vector3(x, y, 0);

        switch(select)
        {
            case 1: 
                tacoProjectile = (GameObject)Instantiate(Dougie, offset, transform.rotation);
                break;
            case 2:
                tacoProjectile = (GameObject)Instantiate(Dougie2, offset, transform.rotation);
                break;
            case 3:
                tacoProjectile = (GameObject)Instantiate(Dougie3, offset, transform.rotation);
                break;
            case 4:
                tacoProjectile = (GameObject)Instantiate(Dougie4, offset, transform.rotation);
                break;

            default:
                tacoProjectile = (GameObject)Instantiate(BlankDougie, offset, transform.rotation);
                break;
        }
        tacoProjectile.AddComponent<Controller>();
        tacoProjectile.GetComponent<Transform>().Rotate(0, 180, 0);
        
	}
	
	// Update is called once per frame
	void Update () {
       // print(PlayerPrefs.GetInt("Player Score"));
    }
}
