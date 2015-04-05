using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	public float speed = 3;
	public float maxSpeed = 3;
	
	
	void FixedUpdate () {
		
		Vector3 speedVector = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
		
		if(speedVector.magnitude > maxSpeed) {
			speedVector = speedVector.normalized * maxSpeed;
			rigidbody.velocity = speedVector;
		}		
		
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		
		//Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		
		//rigidbody.AddForce(movement * speed);
	}
}
