using UnityEngine;
using System.Collections;

public class GetChar : MonoBehaviour {
    private int select;
    public GameObject Dougie;
    public GameObject Dougie2;
    public GameObject Dougie3;
    // Use this for initialization
    void Start () {
        select = PlayerPrefs.GetInt("Player Score");
        GameObject tacoProjectile;
        Vector3 offset;
        offset =new Vector3(-10, -1.55f, 0);

        switch(select)
        {
            case 1: 
                tacoProjectile = (GameObject)Instantiate(Dougie, offset, transform.rotation);
                break;
            case 2:
                tacoProjectile = (GameObject)Instantiate(Dougie2, offset, transform.rotation);
                break;
            default:
                tacoProjectile = (GameObject)Instantiate(Dougie3, offset, transform.rotation);
                break;
        }
        
        tacoProjectile.GetComponent<Transform>().Rotate(0, 180, 0);
        
	}
	
	// Update is called once per frame
	void Update () {
       // print(PlayerPrefs.GetInt("Player Score"));
    }
}
