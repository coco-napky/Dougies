using UnityEngine;
using System.Collections;

public class HorizontalScreenLimit : MonoBehaviour {

	//GameObject's name for the opposite horizontal limit.
	public string oppositeEnd;
	GameObject oppositeEndGameObject;
	public GameObject wallBrick;
	// Use this for initialization
	void Start () {
		oppositeEndGameObject = GameObject.Find(oppositeEnd);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision ) {

		Transform collisionTransform = collision.transform;
		var renderer = collision.gameObject.GetComponent<Renderer>();
		float widthOffset = renderer.bounds.size.x;

		//check on what end of the screen the collided game object is.
		if(collisionTransform.position.x <= oppositeEndGameObject.transform.position.x)
				widthOffset *= -1.25f;
		else
				widthOffset *= 1.25f;
		Vector3 destination = new Vector3(oppositeEndGameObject.transform.position.x + widthOffset, collisionTransform.position.y,0);
		collisionTransform.position = destination;
		Debug.Log("Width of collision object : " + widthOffset);
	}
}
