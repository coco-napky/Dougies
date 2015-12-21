using UnityEngine;
using System.Collections;

public class BalloonUp : MonoBehaviour {

	Rigidbody2D rigidBody;
	public Vector2 upwardForce;
	public float speedLimit;
	bool flipped = false;
	Transform transform;
	float timer = 0;
	// Use this for initialization
	void Start () {
		rigidBody	= GetComponent<Rigidbody2D>();
		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
			timer += Time.deltaTime;
			if(rigidBody.velocity.y < 25f)
				rigidBody.AddForce(upwardForce);

			if(timer > 0.35f){
				timer = 0 ;
				if(flipped){
					transform.rotation = Quaternion.Euler (new Vector3(transform.position.x,0,transform.position.x));
					flipped = false;
				}
				else{
					transform.rotation = Quaternion.Euler (new Vector3(transform.position.x,180,transform.position.x));
					flipped = true;
				}
			}
	}
}
