using UnityEngine;

public class DougieAttributes : MonoBehaviour {

	public float hp = 3;
	public Vector2  floatingForce,movingforce;
  public float    verticalSpeedLimit 	 = 5f,
                  horizontalSpeed      = 5f,
                  horizontalSpeedTaco  = 12f,
                  tacoFireRate         = 0.8f,
  	              nextTacoShot         = 0;

	// Use this for initialization
	void Start () {
		floatingForce 		= new Vector2(0,7.5f);
        movingforce = new Vector2(5f, 0);
    }
}
