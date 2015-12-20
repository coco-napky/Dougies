using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	public float verticalExtent;
	public float horizontalExtent;

	public float boundaryLeft;
	public float boundaryRight;
	public float boundaryTop;
	public float boundaryButtom;

	Transform transform;

	public Camera camera;
	// Use this for initialization
	void Start () {
		 camera = Camera.main.GetComponent<Camera>();
		 verticalExtent 	 = camera.orthographicSize;
   	 horizontalExtent  = verticalExtent * Screen.width / Screen.height;
		 transform  			 = Camera.main.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {

		boundaryLeft   = transform.position.x  - horizontalExtent;
		boundaryRight  = transform.position.x  + horizontalExtent;
		boundaryTop 	 = transform.position.y  + verticalExtent;
		boundaryButtom = transform.position.y  - verticalExtent;


/*
		** Debugging code  **

		Debug.Log("Vertical Extent : "   		+ verticalExtent );
		Debug.Log("Horizontal Extent : " 		+ horizontalExtent );
		Debug.Log("Left Boundary : "     		+ boundaryLeft );
		Debug.Log("Right Boundary : "    		+ boundaryRight );
		Debug.Log("Top Boundary : "      		+ boundaryTop );
		Debug.Log("Buttom Boundary : "      + boundaryButtom );

		Vector3 start = new Vector3(boundaryLeft, boundaryButtom,0);
		Vector3 end 	= new Vector3(boundaryRight, boundaryButtom,0);

		Vector3 startY = new Vector3(0, boundaryButtom,0);
		Vector3 endY 	 = new Vector3(0, boundaryTop,0);
		Debug.DrawLine(startY, endY, Color.red);
		Debug.DrawLine(start, end, Color.red);
*/

	}
}
