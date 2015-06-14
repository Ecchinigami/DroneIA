﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class behaviourManager : MonoBehaviour, GestureListener {

	List<GameObject> drones;
	public GameObject prefabDrone;
	
	void Start () {		
		for(int i=-20; i <= 20; i+=10) {
			for(int y=-20; y <= 20; y+=10) {
				GameObject drone = Instantiate(prefabDrone, prefabDrone.transform.position + new Vector3(i,0,y), prefabDrone.transform.rotation);
				drones.Add(drone);
			}
		}
	}

	void switchBehaviour(string behaviour)
	{
		switch(behaviour)
		{
		case "clap":
			foreach(GameObject drone in drones)
			{
				Wandering wandering = drone.GetComponent<Wandering>();
				wandering.enabled =! wandering.enabled;
			}

		}

	}

	void OnComplete(DynGesture gesture)
	{
		switchBehaviour(gesture.Name);
	}

	void OnRecomplete(DynGesture gesture)
	{

	}
	
	void OnRelease(DynGesture gesture)
	{

	}
}
