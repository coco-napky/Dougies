using UnityEngine;
using System.Collections;

public class BalloonUp : MonoBehaviour {

	Rigidbody2D rigidBody;
	public Vector2 upwardForce;
	public float speedLimit;
	bool flipped = false;
	Transform transform;
	float timer = 0;
	float timeStamp = 0;
	// Use this for initialization
	void Start () {
		rigidBody	= GetComponent<Rigidbody2D>();
		transform = GetComponent<Transform>();
		timeStamp = Time.time;
	}

	// Update is called once per frame
	void Update () {
		float deltaTime  = Time.time - timeStamp;
		if(deltaTime > 5f)
			Destroy(gameObject);
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
