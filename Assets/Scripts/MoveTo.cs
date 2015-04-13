using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	
	public Transform goal;
	
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		//agent.destination = goal.position; 
		//InvokeRepeating ("RandomMovement", 1, 1.0F);

	}

	void Update(){
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
	}

	/*public void RandomMovement () 
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		agent.destination = 
		Transform from = agent.transform;
		float angle = Random.Range (-90, 90);
		Debug.Log ("angle : " + angle);
		Quaternion to = Quaternion.AngleAxis(angle, Vector3.up);
		agent.transform.rotation = Quaternion.Slerp(from.rotation, to, 1000F);
	}*/
}
