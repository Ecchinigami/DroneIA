using UnityEngine;
using System.Collections;

public class Wandering2 : MonoBehaviour {
	
	public float rotationSpeed = 50;
	public float movementSpeed = 20;
	public float rotationTime = 3;

	void Update()
	{
		run ();
	}
	
	public void run()
	{
		Vector3 referenceForward = Vector3.forward;	
		Vector3 directionFromRotation = transform.rotation * referenceForward;
		
		Vector3 newDirection = Quaternion.AngleAxis(Random.Range(0f,90f)-Random.Range(0f,90f), transform.up) * directionFromRotation; 

		//transform.position += newDirection*movementSpeed*Time.deltaTime;
		rigidbody.AddForce(newDirection*movementSpeed);
	}
	
}