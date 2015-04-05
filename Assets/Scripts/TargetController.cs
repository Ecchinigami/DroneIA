using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	public int speed;
	public int turnSpeed;
	public GameObject ground;


	// Use this for initialization
	void Start () {
		//grounds = GameObject.FindGameObjectsWithTag ("Ground");
		//ground = grounds [0];
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
		if (transform.position.z > 19 || transform.position.z < -19 || transform.position.x > 19 || transform.position.x < -19) 
		{
			transform.position = new Vector3(0,1,0);
		}
		float translation = Time.deltaTime * 3;
		transform.Translate(translation, 0, 0);


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
		float angle = Random.Range (-90, 90);
		Debug.Log ("angle : " + angle);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

	}

}
