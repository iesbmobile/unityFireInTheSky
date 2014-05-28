using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public GameObject cam;

	float speed = 4.9f;
	public float t = 0f;

	// Use this for initialization
	void Start () {

	
	}


	// Update is called once per frame
	void Update () {
		t = t+Time.deltaTime;
		Debug.Log (t);
		if(t<200000){
			transform.Translate(0,0,1f * speed * Time.deltaTime, Space.World);
		}
	}
}
