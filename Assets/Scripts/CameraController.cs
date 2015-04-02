using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;
	
	public enum CamMode {
		free, constrainedX, constrainedY, constrainedXY
	}
	public CamMode cameraMode;
	
	public float xSmoothTime = 0.5f;
	public float ySmoothTime = 0.5f;
	
	public float xConstraint = 0.03f;
	public float yConstraint = 0.03f;
	
	private float xVelocity = 0.0f;
	private float yVelocity = 0.0f;
	
	private float zDistance = -10;
	
	void Start () {
		transform.position = new Vector3 (player.position.x, player.position.y, -10);
	}
	
	void LateUpdate () {
		float xPosition, yPosition;
		
		if(cameraMode == CamMode.free) {
			xPosition = Mathf.SmoothDamp(transform.position.x, player.position.x, ref xVelocity, xSmoothTime);
			
			yPosition = Mathf.SmoothDamp(transform.position.y, player.position.y, ref yVelocity, ySmoothTime);
			
			
			transform.position = new Vector3 (xPosition, yPosition, player.position.z+zDistance);
		}
		else if(cameraMode == CamMode.constrainedX) {
			yPosition = Mathf.SmoothDamp(transform.position.y, player.position.y, ref yVelocity, ySmoothTime);
		
			transform.position = new Vector3 (transform.position.x + xConstraint, yPosition, zDistance);
		}
		else if(cameraMode == CamMode.constrainedY) {
			if(player.localScale.x > 0)
				xPosition = Mathf.SmoothDamp(transform.position.x, player.position.x+4, ref xVelocity, xSmoothTime);
			else
				xPosition = Mathf.SmoothDamp(transform.position.x, player.position.x-4, ref xVelocity, xSmoothTime);
			
			transform.position = new Vector3 (xPosition, transform.position.y + yConstraint, zDistance);
		}
		else if(cameraMode == CamMode.constrainedXY) {
			transform.position = new Vector3 (transform.position.x + xConstraint, transform.position.y + yConstraint, zDistance);
		}
	}
}
