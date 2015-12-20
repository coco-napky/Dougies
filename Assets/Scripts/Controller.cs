using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    //Code needs to be refactored into concerns : InputController -> CharacterStates -> CharacterAttributes -> CharacterBehavior

  public float hp = 3;
	public Rigidbody2D rigidbody;
	Transform transform;
	Vector2 floatingForce;

	public GameObject redBalloon,
                    blueBalloon;


  float ballonNumber = 3;
	Vector2 positivePushForce,
	        negativePushForce;


	public KeyCode directionSwitch,
                 up,
	               fire,
                 up_Joy,
                 directionSwitch_Joy,
                 fire_Joy;



  float verticalSpeedLimit 	 = 5f,
	      horizontalSpeed      = 5f;

	public float horizontalSpeedTaco = 12f;

	public bool goingLeft = true;
	bool goingUp   = true;

	public GameObject taco;
	float tacoFireRate = 0.8f,
	      nextTacoShot;

	public short player;
	// Use this for initialization
	void Start () {
		floatingForce 		= new Vector2(0,7.5f);
		positivePushForce = new Vector2(5f,0);
		negativePushForce = new Vector2(-5f,0);

		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		goingUp 	= Input.GetKey(up) || Input.GetKey(up_Joy);
		if( Input.GetKeyDown(directionSwitch)|| Input.GetKeyDown(directionSwitch_Joy))
        {
			goingLeft = !goingLeft;
		}

		HozizontalFlip(goingLeft);

		//If fire key is pressed and cooldown is over.
		if( (Input.GetKeyDown(fire)|| Input.GetKeyDown(fire_Joy)) && Time.time > nextTacoShot){

			//Set time for next taco shot
			nextTacoShot = Time.time + tacoFireRate;

			//set projectiles properties before instantiation
			// Position, Rotation, etc.
			float horizontalProjectileOffset = 1f;
			Vector3 offset;
			if(goingLeft)
					offset = transform.position + new Vector3(horizontalProjectileOffset,0,0);
			else
					offset = transform.position + new Vector3(horizontalProjectileOffset*-1,0,0);

			GameObject tacoProjectile = (GameObject)Instantiate(taco,offset,transform.rotation);
			tacoProjectile.GetComponent<Transform>().Rotate(0,180,0);
			if(goingLeft)
				tacoProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeedTaco,0);
			else
				tacoProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeedTaco*-1,0);
		}

	}

	void FixedUpdate () {

		if (goingUp && Time.time > nextTacoShot)
			if(rigidbody.velocity.y  <= verticalSpeedLimit)
					rigidbody.AddForce(floatingForce);

		if (goingLeft){
				rigidbody.velocity = new Vector2(horizontalSpeed,rigidbody.velocity.y);
			}
		else{
			 	rigidbody.velocity = new Vector2(horizontalSpeed*-1,  rigidbody.velocity.y);
			}
	}

	void HozizontalFlip(bool goingLeft){

		Vector3 temp = transform.rotation.eulerAngles;
		//restore defaults on x and z axis, and toggle rotation on Y axis
		temp.x = 0;
		temp.z = 0;
		if(goingLeft)
				temp.y = 180f;
		else
				temp.y = 0f;

			transform.rotation = Quaternion.Euler(temp);
	}

	public void ReceiveDamage(){
		hp -= 1;
		if(player == 1)
			Instantiate(redBalloon, new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
		else if (player == 2)
			Instantiate(blueBalloon, new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);

			if(hp == 0)
				Destroy(gameObject);
	}

}
