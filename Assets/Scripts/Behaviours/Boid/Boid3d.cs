using UnityEngine;
using System.Collections;

public class Boid3d : MonoBehaviour{
	
	private int boidsNumber;
	public GameObject[] boidsList;
	private GameObject goal;
	public float speed;
	//public GameObject boid;
	
	
	// Use this for initialization
	void Start () {
		boidsList = GameObject.FindGameObjectsWithTag ("Drone");
		goal = GameObject.FindGameObjectWithTag ("Human");
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (boidsNumber);
		//boid.rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal")*10,0);
		move_all_boids_to_new_positions ();
		//boidsList = GameObject.FindGameObjectsWithTag ("Boid");
		/*foreach (GameObject b in boidsList) {
			b.rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal")*10,0);
		}*/
//		goal.rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")*25,Input.GetAxis("Vertical")*25);

		
		
	}
	
	
	private void move_all_boids_to_new_positions(){
		Vector3 v1 = new Vector3();
		Vector3 v2 = new Vector3();
		Vector3 v3 = new Vector3();
		Vector3 direction = new Vector3 ();
		
		//boidsList = GameObject.FindGameObjectsWithTag ("Boid");
		foreach (GameObject b in boidsList) {
			v1 = rule1 (b);
			v2 = rule2 (b);
			v3 = rule3 (b);
			Vector3 vectorBoids = v1 + v2 + v3;
			//vectorBoids.Normalize();
			//direction = goTo(b);
			//Debug.Log("x: " + v1.x);
			//Debug.Log("y : " + v1.y);
			//Vector3 direction = new Vector3(goal.transform.position.x, goal.transform.position.y);
			//b.rigidbody.velocity = new Vector3((b.rigidbody.velocity.x + v1.x + v2.x + v3.x + direction.x)*Time.deltaTime*speed, (b.rigidbody.velocity.y + v1.y + v2.y + v3.y + direction.y)*Time.deltaTime*speed);
			b.rigidbody.velocity = new Vector3((b.rigidbody.velocity.x + vectorBoids.x + direction.x)*Time.deltaTime*speed, (b.rigidbody.velocity.y + vectorBoids.y + direction.y)*Time.deltaTime*speed, (b.rigidbody.velocity.z + vectorBoids.z + direction.z)*Time.deltaTime*speed);
			
			//b.rigidbody.velocity = new Vector3(b.rigidbody.velocity.x + v1.x + v2.x, b.rigidbody.velocity.y + v1.y + v2.y);
			//b.rigidbody.velocity = new Vector3(b.rigidbody.velocity.x + v1.x, b.rigidbody.velocity.y + v1.y);
			//b.rigidbody.velocity = b.rigidbody.velocity * Time.deltaTime;
			b.transform.position = b.transform.position + b.rigidbody.velocity;
			//b.rigidbody.velocity = new Vector3(v1.x, v1.y);
			//b.transform.position = new Vector3(v1.x, v1.y);
			
		}
	}
	
	
	private Vector3 rule1(GameObject bj){
		Vector3 pcj = new Vector3(0,0,0);
		//boidsList = GameObject.FindGameObjectsWithTag ("Boid");
		
		foreach(GameObject b in boidsList)
		{
			if(b != bj && Vector3.Distance(b.transform.position, bj.transform.position) < 1){
				pcj.x = pcj.x + b.transform.position.x;
				pcj.y = pcj.y + b.transform.position.y;
				pcj.z = pcj.z + b.transform.position.z;
			}
			boidsNumber = boidsNumber +1;
		}
		pcj = pcj / (boidsNumber-1);
		
		Vector3 finalVector = new Vector3 (0, 0, 0);
		finalVector.x = (pcj.x - bj.transform.position.x) / 100;
		finalVector.y = (pcj.y - bj.transform.position.y) / 100;
		finalVector.z = (pcj.z - bj.transform.position.z) / 100;
		return finalVector;
	}
	
	private Vector3 rule2(GameObject bj){
		Vector3 c = new Vector3 (0, 0, 0);
		//boidsList = GameObject.FindGameObjectsWithTag ("Boid");
		
		foreach (GameObject b in boidsList) {
			if (b != bj) 
			{
				Vector3 differenceVector = new Vector3();
				differenceVector = b.transform.position - bj.transform.position;
				float distance = differenceVector.magnitude;
				//if ((b.transform.position.magnitude - bj.transform.position.magnitude) < 1)
				float randDist = Random.Range(2f, 4f);
				if(distance < randDist)
				{
					c.x = c.x - (b.transform.position.x - bj.transform.position.x);
					c.y = c.y - (b.transform.position.y - bj.transform.position.y);
					c.z = c.z - (b.transform.position.z - bj.transform.position.z);
				}
			}
		}
		return c;
	}
	
	private Vector3 rule3(GameObject bj)
	{
		Vector3 pvj = new Vector3 (0, 0, 0);
		//boidsList = GameObject.FindGameObjectsWithTag ("Boid");
		
		foreach (GameObject b in boidsList) {
			if (b != bj) {
				pvj.x = pvj.x + b.rigidbody.velocity.x;
				pvj.x = pvj.y + b.rigidbody.velocity.y;
				pvj.z = pvj.z + b.rigidbody.velocity.z;
			}
			boidsNumber = boidsNumber + 1;
		}
		
		pvj = pvj / (boidsNumber - 1);
		
		Vector3 finalVector = new Vector3 (0, 0, 0);
		finalVector.x = (pvj.x - bj.rigidbody.velocity.x) / 8;
		finalVector.y = (pvj.y - bj.rigidbody.velocity.y) / 8;
		finalVector.z = (pvj.z - bj.rigidbody.velocity.z) / 8;
		
		return finalVector;
	}
	
	private Vector3 goTo(GameObject bj)
	{
		Vector3 direction = new Vector3 (goal.transform.position.x - bj.transform.position.x, goal.transform.position.y - bj.transform.position.y, goal.transform.position.z - bj.transform.position.z);
		direction.Normalize();
		return direction;
	}
}
