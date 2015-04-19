using UnityEngine;
using System.Collections;

public class SpawnDrone : MonoBehaviour {

	public GameObject drone;
	
	void Start () {
		Instantiate(drone, drone.transform.position + new Vector3(0,0,10), drone.transform.rotation);
		Instantiate(drone, drone.transform.position + new Vector3(10,0,0), drone.transform.rotation);
		Instantiate(drone, drone.transform.position + new Vector3(5,0,10), drone.transform.rotation);
		Instantiate(drone, drone.transform.position + new Vector3(0,0,5), drone.transform.rotation);
		Instantiate(drone, drone.transform.position + new Vector3(5,0,5), drone.transform.rotation);
		
		Instantiate(drone, drone.transform.position + new Vector3(15,0,15), drone.transform.rotation);
		
		Instantiate(drone, drone.transform.position + new Vector3(8,0,15), drone.transform.rotation);
		
		Instantiate(drone, drone.transform.position + new Vector3(15,0,8), drone.transform.rotation);
		
		Instantiate(drone, drone.transform.position + new Vector3(-15,0,-15), drone.transform.rotation);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
