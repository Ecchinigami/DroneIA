﻿using UnityEngine;
using System.Collections;

public class GOSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");
			
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.tag);
				if (hitInfo.transform.gameObject.tag == "Drone")
				{
					Debug.Log ("T'as touché un drone AHAH !");
					GameObject drone = hitInfo.transform.gameObject;

					GameObject simulator = GameObject.FindGameObjectWithTag("Simulator");
					ClickMovement clickMovement = GetComponent<ClickMovement>();
					clickMovement.objectToMove = drone;
				} else {
					Debug.Log ("Raté");
				}
			} else {
				Debug.Log("No hit");
			}
			Debug.Log("Mouse is down");
		}
	
	}
}
