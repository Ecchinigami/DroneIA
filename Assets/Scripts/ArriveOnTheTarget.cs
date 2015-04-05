using UnityEngine;
using System.Collections;

public class ArriveOnTheTarget : MonoBehaviour {

	public int radius;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 droneVelocity = rigidbody.velocity;
		if (droneVelocity.magnitude > radius) 
		{
			Debug.Log ("Proche");
		}
	
	}
}
