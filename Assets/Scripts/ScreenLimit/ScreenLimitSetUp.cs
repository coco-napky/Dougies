using UnityEngine;
using System.Collections;

public class ScreenLimitSetUp : MonoBehaviour {

	CameraBounds cameraBounds;

	GameObject leftLimit;
	GameObject rightLimit;
	GameObject topLimit;
	GameObject buttomLimit;

	// Use this for initialization
	void Start () {

		cameraBounds = GetComponent<CameraBounds>();

		leftLimit 	 = transform.FindChild("LeftScreenLimit").gameObject;
		rightLimit   = transform.FindChild("RightScreenLimit").gameObject;
		topLimit 		 = transform.FindChild("TopScreenLimit").gameObject;
		buttomLimit  = transform.FindChild("ButtomScreenLimit").gameObject;

	}

	// Update is called once per frame
	void Update () {

		//Limits are positioned based on an offset taking place from an origin which is the camera's world position.
		float cameraXCoordinate =	cameraBounds.camera.transform.position.x;
		float cameraYCoordinate =	cameraBounds.camera.transform.position.y;

		//Offsets are needed to align vertical limits inside the screen, and Horizontal Limits out of the screen.
		//These are assigned depending on the width of the limits' colliders.
		float topLimitOffset  = -1f;
		float leftLimitOffset = -2.5f;
		float rightLimitOffset = 2.5f;

		//Limits positioning
		Vector3 leftLimitPositionVector    = new Vector3(cameraBounds.boundaryLeft + leftLimitOffset,cameraYCoordinate,0);
		leftLimit.transform.position 		   = leftLimitPositionVector;

		Vector3 rightLimitPositionVector   = new Vector3(cameraBounds.boundaryRight + rightLimitOffset,cameraYCoordinate,0);
		rightLimit.transform.position 		 = rightLimitPositionVector;

		Vector3 topLimitPositionVector  	 = new Vector3(cameraXCoordinate,cameraBounds.boundaryTop + topLimitOffset,0);
		topLimit.transform.position 	  	 = topLimitPositionVector;

		Vector3 buttomLimitPositionVector  = new Vector3(cameraXCoordinate,cameraBounds.boundaryButtom,0);
		buttomLimit.transform.position 	   = buttomLimitPositionVector;

		//Box collider width and set assignment.
		//Limits parallel to each other share same dimensions. Horizontal/Vertical

		//absolute values of the positioning offsets must be added to width
		float horizontalOffsetCompensation = Mathf.Abs(rightLimitOffset) + Mathf.Abs(leftLimitOffset);
		Vector2 verticalLimitDimension = new Vector2((cameraBounds.horizontalExtent*2) + horizontalOffsetCompensation,1);
		Vector2 horizontalLimitDimension 	 = new Vector2(1,(cameraBounds.verticalExtent*2));

		leftLimit.GetComponent<BoxCollider2D>().size 	 =	horizontalLimitDimension;
		rightLimit.GetComponent<BoxCollider2D>().size  =	horizontalLimitDimension;
		topLimit.GetComponent<BoxCollider2D>().size 	 =	verticalLimitDimension;
		buttomLimit.GetComponent<BoxCollider2D>().size =	verticalLimitDimension;
	}
}
