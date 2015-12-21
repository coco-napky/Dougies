    using UnityEngine;
using System.Collections;

public class TacoCollisionHandler : MonoBehaviour {

	TacoBehavior tacoBehavior;

	// Use this for initialization
	void Start () {
		tacoBehavior = GetComponent<TacoBehavior>();
	}

	void OnCollisionEnter2D(Collision2D collision ) {
		//Tacos shouldnt explode on contact with horizontal screen limits.
			if(collision.gameObject.tag != "HorizontalScreenLimit")
				tacoBehavior.Explode();

			if(collision.gameObject.tag == "Player")
			{
				Debug.Log("Player Hit");
				Controller controller  = collision.gameObject.GetComponent<Controller>();
				controller.ReceiveDamage();

                
			}
	}


}
