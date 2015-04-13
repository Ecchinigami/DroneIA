using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	public int speed;
	public int turnSpeed;
	public GameObject ground;
	public string comportement;


	// Use this for initialization
	void Start () {
		GameObject[] grounds = GameObject.FindGameObjectsWithTag ("Ground");
		GameObject ground = grounds [0];

		//Vector3 size = ground.BoxCollider.size;
		//boxCollider = gameObject.GetComponent ("BoxCollider") as BoxCollider;
	
		//ground.getComponent.<BoxCollider>().bounds.size;
		//float width = ground.renderer.bounds.size.x;
		//Debug.Log ("width : " + width);
	
		InvokeRepeating ("RandomMovement", 1, 1.0F);

	
	}
	
	// Update is called once per frame
	void Update () {



		//transform.rotation = Random.rotation;

		Movement ();

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, 1))
			print("There is something in front of the object!");

		if (transform.position.z > 19 || transform.position.z < -19 || transform.position.x > 19 || transform.position.x < -19) 
		{
			transform.position = new Vector3(0,1,0);
		}

		if (comportement == "Patrol") {
			float translation = Time.deltaTime * 3;
			transform.Translate (translation, 0, 0);
		}

		if (comportement != "Patrol") {
			CancelInvoke ();
		}

		//float translation = Time.deltaTime * 10;
		//transform.Translate(translation, 0, 0);
		//float rotation = Time.deltaTime * 10;
		//transform.Rotate (new Vector3 (0, 1, 0), rotation);


		//rigidbody.AddForce (transform.rotation.x, transform.rotation.y, transform.rotation.z);

		//Vector3 randomDirection = new Vector3(Random.Range(
		//transform.position = Vector3.forward;
		//Vector3 randomDirection = Random.insideUnitSphere * 10;

	
	}

	//movement controlé par clavier
	void Movement() 
	{
		float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
		
		transform.Translate(Vector3.forward * forwardMovement);
		transform.Rotate(Vector3.up * turnMovement);
	}

	public void RandomMovement () 
	{
		Transform from = this.transform;
		float angle = Random.Range (-90, 90);
		Debug.Log ("angle : " + angle);
		Quaternion to = Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = Quaternion.Slerp(from.rotation, to, 1000F);
	}

	/*public void RandomMovement()
	{
		Vector2 wayPoint = Random.insideUnitCircle * 47;
		Debug.Log ("angle : " + wayPoint);
		transform.LookAt(wayPoint);
	}*/



}
