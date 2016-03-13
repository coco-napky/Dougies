using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DougieBehaviour : NetworkBehaviour {

	public  GameObject taco;
	private Rigidbody2D rigidbody;
	private Transform transform;
	public  GameObject balloon;

	private DougieAttributes attributes;
	private DougieStates states;

	// Use this for initialization
	void Awake(){
		transform  = GetComponent<Transform>();
		rigidbody  = GetComponent<Rigidbody2D>();

	}
	void Start () {
		states	   = GetComponent<DougieStates>();
		attributes = GetComponent<DougieAttributes>();
		rigidbody  = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		HozizontalFlip();
	}

	void FixedUpdate () {
		Move();
		CmdShoot();
	}

	void Move(){
		// Y axis displacement
		if (states.goingUp && Time.time > attributes.nextTacoShot)
			if(rigidbody.velocity.y  <= attributes.verticalSpeedLimit)
					rigidbody.AddForce(attributes.floatingForce);

		// X axis displacement
		if (states.goingLeft)
			rigidbody.velocity = new Vector2(attributes.horizontalSpeed,rigidbody.velocity.y);
		else
			rigidbody.velocity = new Vector2(attributes.horizontalSpeed*-1,  rigidbody.velocity.y);
	}


	void CmdShoot(){
		//check if taco shooting cooldown is off, else to do nothing
		if(Time.time < attributes.nextTacoShot || !states.shooting)
				return;
		states.shooting = false;
		//Set time for next taco shot
		attributes.nextTacoShot = Time.time + attributes.tacoFireRate;

		//set projectiles properties before instantiation
		// Position, Rotation, etc.
		float horizontalProjectileOffset = 1f;
		Vector3 offset;
		if(states.goingLeft)
				offset = transform.position + new Vector3(horizontalProjectileOffset,0,0);
		else
				offset = transform.position + new Vector3(horizontalProjectileOffset*-1,0,0);

		GameObject tacoProjectile = (GameObject)Instantiate(taco,offset,transform.rotation);
		tacoProjectile.GetComponent<Transform>().Rotate(0,180,0);

		if(states.goingLeft)
			tacoProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(attributes.horizontalSpeedTaco,0);
		else
			tacoProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(attributes.horizontalSpeedTaco*-1,0);

		NetworkServer.Spawn(tacoProjectile);
	}

	public void ReceiveDamage(){
		attributes.hp -= 1;
		Instantiate(balloon, new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
		if(attributes.hp == 0)
			Destroy(gameObject);
	}

	void HozizontalFlip(){

		Vector3 temp = transform.rotation.eulerAngles;
		//restore defaults on x and z axis, and toggle rotation on Y axis
		temp.x = 0;
		temp.z = 0;
		if(states.goingLeft)
				temp.y = 180f;
		else
				temp.y = 0f;

			transform.rotation = Quaternion.Euler(temp);
	}

}
