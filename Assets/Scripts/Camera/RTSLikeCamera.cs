using UnityEngine;
using UnityEngine;
using System.Collections;

public class RTSLikeCamera : MonoBehaviour {

	//public float distance = 5.0f;

	float distance = 60;
	float sensitivityDistance = 50;
	float damping = 5;
	float minFOV = 10;
	float maxFOV = 150;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		distance = camera.fieldOfView;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 
		float scrollDistance = 5f; 
		float scrollSpeed = 70;
		if (Input.GetMouseButton(0))
		{
			if (mousePosX < scrollDistance) 
			{ 
				transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime); 
			} 
			
			if (mousePosX >= Screen.width - scrollDistance) 
			{ 
				transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime); 
			}
			
			if (mousePosY < scrollDistance) 
			{ 
				transform.Translate(transform.up * -scrollSpeed * Time.deltaTime); 
			} 
			
			if (mousePosY >= Screen.height - scrollDistance) 
			{ 
				transform.Translate(transform.up * scrollSpeed * Time.deltaTime); 
			}
		}
		scrollDistance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * scrollSpeed * Mathf.Abs(scrollDistance);

		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp(distance, minFOV, maxFOV);
		this.camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, distance, Time.deltaTime * damping);
		
	}
}
