using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviourManager : MonoBehaviour {

	List<GameObject> drones;
	public GameObject prefabDrone;
	private string behaviour;
	
	void Start () {		
		drones = new List<GameObject> ();
		for(int i=-20; i <= 20; i+=10) {
			for(int y=-20; y <= 20; y+=10) {
				Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f, 180f), Vector3.up);
				GameObject drone = Instantiate(prefabDrone, prefabDrone.transform.position + new Vector3(i,0,y), orientation) as GameObject;
				drones.Add(drone);
			}
		}
	}

	void Update()
	{
		behaviourController ();
	}

	void switchBehaviour()
	{
		switch(this.behaviour)
		{
		case "Wandering":
			foreach(GameObject drone in drones)
			{
				Wandering2 wandering = drone.GetComponent<Wandering2>();
				wandering.enabled =! wandering.enabled;
			}
		break;

		case "CircleFormation" :
			foreach(GameObject drone in drones)
			{
				CircleFormation circleFormation = drone.GetComponent<CircleFormation>();
				circleFormation.enabled =! circleFormation.enabled;
			}
		break;

		case "Boid" :
			foreach(GameObject drone in drones)
			{
				Boid boid = drone.GetComponent<Boid>();
				boid.enabled =! boid.enabled;
			}
		break;

		}
	}

	void behaviourController()
	{
		if(Input.GetKeyDown(KeyCode.F1))
		{
			disableAllScript();
			this.behaviour = "Wandering";
			Debug.Log("Wandering lancé");
			switchBehaviour();
		}
		else if(Input.GetKeyDown(KeyCode.F2))
		{
			disableAllScript();
			this.behaviour = "CircleFormation"; 
			Debug.Log("CircleFormation lancé");
			switchBehaviour();
		}
		else if(Input.GetKeyDown(KeyCode.F3))
		{
			disableAllScript();
			this.behaviour = "Boid"; 
			Debug.Log("Boid lancé");
			switchBehaviour();

		}
	}

	void disableAllScript()
	{
		foreach(GameObject drone in drones)
		{
			Wandering wandering = drone.GetComponent<Wandering>();
			CircleFormation circleFormation = drone.GetComponent<CircleFormation>();
			Boid boid = drone.GetComponent<Boid>();
			if(wandering.enabled)
				wandering.enabled = false;
			if(circleFormation.enabled)
				circleFormation.enabled = false;
			if(boid.enabled)
				boid.enabled = false;
		}
	}
	
}