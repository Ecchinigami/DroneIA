﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleFormation : MonoBehaviour {
	
	public GameObject droneLeader;

	public float radius = 10f;
	
	private float angleBetweenDrone;
	private float distanceBetweenDrone;
	
	List<GameObject> drones = new List<GameObject>();
	
	// Use this for initialization
	void Start () {	
		drones.AddRange( GameObject.FindGameObjectsWithTag("Drone") );
		
		float squareRadius = radius * radius;
		
		angleBetweenDrone = 360 / drones.Count;
		distanceBetweenDrone = Mathf.Sqrt(squareRadius*2 - squareRadius*2*Mathf.Cos(angleBetweenDrone)); 
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 goal = new Vector3(0f,0.25f,0f);
		Vector3 goal = droneLeader.rigidbody.position;
		
		float distanceToGoal = Vector3.Distance(goal, rigidbody.position); // distance to goal
		
		Vector3 direction = goal - rigidbody.position;
		
		// Kinematic
		if(distanceToGoal > radius)
			rigidbody.velocity = direction;
		else if (distanceToGoal < radius)
			rigidbody.velocity = direction * -1;
		// Steering
		/*if(distanceToGoal > radius)
			rigidbody.AddForce(direction.normalized);
		else if (distanceToGoal < radius)
			rigidbody.AddForce(direction.normalized * -1);*/

		GameObject nearestDrone = null;
		float nearestDroneDistance = Mathf.Infinity;
		/*GameObject secondNearestDrone = null;
		float secondNearestDroneDistance = Mathf.Infinity;*/
			
		foreach (GameObject d in drones) {
			if(d != this.gameObject) {
				float distanceToDrone = Vector3.Distance(d.transform.position, rigidbody.position); // distance to other drone
				//Debug.Log(distanceToDrone);
				
				if(distanceToDrone < nearestDroneDistance) {
					/*secondNearestDrone = nearestDrone;
					secondNearestDroneDistance = nearestDroneDistance;*/
					nearestDrone = d;
					nearestDroneDistance = distanceToDrone;
				}
			}				
		}
		
		/*Debug.Log("D1 : "+nearestDroneDistance+" D2 : "+secondNearestDroneDistance);
		
		if(nearestDroneDistance != secondNearestDroneDistance) {
			rigidbody.velocity += (secondNearestDrone.rigidbody.position - rigidbody.position).normalized;
		}*/
		
		Vector3 direction2 = nearestDrone.rigidbody.position - rigidbody.position;
		
		// Kinematic
		if(nearestDroneDistance > distanceBetweenDrone)
			rigidbody.velocity += direction2 * 0.9f;
		else if (nearestDroneDistance < distanceBetweenDrone)
			rigidbody.velocity += direction2 * 0.9f * -1;
	}
}