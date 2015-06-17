using UnityEngine;
using System.Collections;

public class CircleMovement : MonoBehaviour {

	public float speed = (2 * Mathf.PI) / 5;
	public float radius = 5;
	public GameObject target;
	
	private float angle = 0;

	void Update()
	{
		angle += speed*Time.deltaTime;		
		float distanceToTarget = Vector3.Distance(target.transform.position, rigidbody.position);
		
		if (distanceToTarget > radius-5 && distanceToTarget < radius+5)
			turnAround ();
		else
			findGoodPosition ();
	}

	void findGoodPosition(){
		
		float distanceToTarget = Vector3.Distance(target.transform.position, rigidbody.position); // distance to goal
		Vector3 direction = target.transform.position - rigidbody.position;
		
		if(distanceToTarget > radius)
			rigidbody.AddForce(direction.normalized * speed);
		else if (distanceToTarget < radius)
			rigidbody.AddForce(direction.normalized * speed * -1);
	}

	void turnAround(){
		Vector3 direction = target.transform.position - rigidbody.position;
		Vector3 up = Vector3.up;
		Vector3 direction2 = Vector3.Cross(direction, up);
		rigidbody.AddForce(direction2.normalized * speed);
	}
}
