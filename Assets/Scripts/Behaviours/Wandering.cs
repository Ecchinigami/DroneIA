using UnityEngine;
using System.Collections;

public class Wandering : MonoBehaviour {
	
	public float rotationSpeed;
	public float movementSpeed;
	public float rotationTime;
	
	void Start()
	{
		Invoke("ChangeRotation",rotationTime);
	}
	
	void ChangeRotation()
	{
		if(Random.value > 0.5f)
		{
			rotationSpeed = -rotationSpeed;
		}
		Invoke("ChangeRotation",rotationTime);
	}
	
	
	void Update() {
		
		transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime, 0));
		transform.position += transform.forward*movementSpeed*Time.deltaTime;
		
	}

	void run(){

	}

}