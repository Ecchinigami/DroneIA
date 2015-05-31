using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	public float speed = 1;
	public float maxSpeed = 3;
	
	
	void FixedUpdate () {
		
		Vector3 speedVector = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
		
		if(speedVector.magnitude > maxSpeed) {
			speedVector = speedVector.normalized * maxSpeed;
			rigidbody.velocity = speedVector;
		}		
		
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");
		
		float moveY = 0.0f;
		
		if (Input.GetKey(KeyCode.Space))
			moveY = 1f;
		else if (Input.GetKey(KeyCode.C))
			moveY = -1f;
			
		
		Vector3 movement = new Vector3(moveX, moveY, moveZ);
		
		//rigidbody.AddForce(movement * speed);
		
		rigidbody.velocity = movement * speed;
	}
}
