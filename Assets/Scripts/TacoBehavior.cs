using UnityEngine;
using System.Collections;

public class TacoBehavior : MonoBehaviour {
	public GameObject tacoExplosion;
	Transform transform;
	TacoBehavior tacoBehavior;
	float start = 0f;
	public float lifespan = 0.25f;

	// Use this for initialization
	void Start () {

			tacoBehavior = GetComponent<TacoBehavior>();
			transform = GetComponent<Transform>();
			start = Time.time;
	}

	void FixedUpdate() {
		//check if taco has been around for less time than its lifespan.
		if(Time.time - start >= lifespan)
			Explode();
	}

	public void Explode(){
		//Show explosion
		Instantiate(tacoExplosion,transform.position,transform.rotation);
		//Clean projectile from memory.
		Destroy(gameObject);
	}
}
