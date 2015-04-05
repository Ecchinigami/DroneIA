using UnityEngine;
using System.Collections;

public class SeekTarget : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public GameObject target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		//Movement ();
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);

	
	}

	/*void Movement() 
	{
		float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
		
		transform.Translate(Vector3.forward * forwardMovement);
		transform.Rotate(Vector3.up * turnMovement);
	}*/

	/*seek()
	{
		velocity = target.transform.position – this.transform.position;
		transform.Rotate
	}*/
}
