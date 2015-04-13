using UnityEngine;
using System.Collections;

public class ShpereCollider : MonoBehaviour {

	public GameObject leader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("OKOK");
		GameObject follower = other.gameObject;
		TargetController otherScript = GetComponent<TargetController>();
		otherScript.comportement = "follow";
		SeekTarget (follower);
		//other.gameObject.SetActive (false);
	}

	void SeekTarget(GameObject follower){
		follower.transform.position = Vector3.MoveTowards (follower.transform.position, leader.transform.position, 0.03f);
		float translation = Time.deltaTime * 3;
		transform.Translate(translation, 0, 0);
	}
}
