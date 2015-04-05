using UnityEngine;
using System.Collections;

public class FleeTarget : MonoBehaviour {

	public int speed;
	public GameObject target;
	public int radius;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			Debug.Log ("Mode flee");
			SeekTarget otherScript = GetComponent<SeekTarget>();
			otherScript.enabled = !otherScript.enabled;
			transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, 0.03f);

		}
	
	}
}
