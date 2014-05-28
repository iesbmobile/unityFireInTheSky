using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)){		

			if (transform.eulerAngles.z < 30f) {
				transform.Rotate(0f, 0f, 1f);	
			}
		}
		
		if (Input.GetKey(KeyCode.D)){
			if (transform.eulerAngles.z > 330f) {
				transform.Rotate(0f, 0f, -1f);
			}

		}

		if (!Input.GetKey(KeyCode.D) && transform.eulerAngles.z > 181f) {
				
			transform.Rotate(0f, 0f, 0.5f);
		}

		if (!Input.GetKey(KeyCode.A) && transform.eulerAngles.z < 180f) {
			
			transform.Rotate(0f, 0f, -0.5f);
		}


	}
}
